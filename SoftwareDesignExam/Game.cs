using Model.Base.Enemies;
using Model.Base.Enums;
using Model.Base.Player;
using Model.Base.Shop;
using Model.Decorator.Abstract;
using Model.Interface;
using Persistence.Db;
using Presentation;

namespace SoftwareDesignExam {
    public class Game {

        #region Private fileds
        private string _input = "";
        private PlayerHandler _playerHandler;
        private bool _gameIsRunning = true;
        private List<ShopItem> _allItems;
        public UserDao _userDao;
        private IUI _ui;
        private Dictionary<Menu, Delegate> _gameMeckanics;
        private List<CharacterInfo> _enemyList;
        private Menu _lastMenu = Menu.MAINMENU;
        private Menu _menu = Menu.MAINMENU;
        private List<User> _users;
        private ItemDao _itemDao;
        private int roomNr = 1;
        #endregion

        #region Constructor
        public Game() {
            _itemDao = new ItemDao();
            _allItems = _itemDao.GetAllItems();
            ShopItemSpawner.SetAllShopItems(_allItems);
            _userDao = new();
            _gameMeckanics = new Dictionary<Menu, Delegate>();
            _playerHandler = new();
            _enemyList = new();
            _allItems = new List<ShopItem>();
            _users = new();
          
            _ui = new UI();
            
            
            _gameMeckanics.Add(Menu.ERROR, HandelErrorMeckanics);
            _gameMeckanics.Add(Menu.MAINMENU, HandelMainMenuMeckanics);
            _gameMeckanics.Add(Menu.LOGIN, HandelLoginMeckanics);
            _gameMeckanics.Add(Menu.ATTACK, HandelAttackMeckanics);
            _gameMeckanics.Add(Menu.INVETORY, HandelInventoryMeckanics);
            _gameMeckanics.Add(Menu.NEXTROOM, HandelNextRoomMeckanics);
            _gameMeckanics.Add(Menu.HIGHSCORE, HandelMaxScoreMeckanics);
            _gameMeckanics.Add(Menu.ENEMYTURN, HandelCheckIfGameOverMeckanics);
            _gameMeckanics.Add(Menu.GAMEOVER, HandelGameOverMeckanics);

        }
        #endregion

        #region Game flow
        public void Update() {
            while (_gameIsRunning) {

                Draw();
                HandelInput();
                HandelGameMecknaics();

            }
        }

        private void Draw() {
            _ui.SetActiveModels(_playerHandler, _enemyList, _users, roomNr);
            _ui.Draw(_menu);
        }

        private void HandelInput() {
            _input = _ui.HandelPlayerInput(_menu);
            HandelErrorInput();
        }
        /// <summary>
        /// for Database hantering og spill relaterte opprasjoner
        /// </summary>
        public void HandelGameMecknaics() {
            _gameMeckanics[_menu].DynamicInvoke();
        }
        #endregion

        #region Game Meckanics
        private void HandelInventoryMeckanics() {
            _lastMenu = _menu;
            if (int.Parse(_input) <= _playerHandler.GetInventory().Count) {
                SelectActiveItems();

            }
            else if (int.Parse(_input) == _playerHandler.GetInventory().Count + 1) {
                _playerHandler.EquiptAllActiveItems();
                _menu = Menu.ATTACK;

            }
            else
                _menu = Menu.ERROR;
        }

        private void SelectActiveItems() {
            var items = _playerHandler.GetInventory();

            var item = items[int.Parse(_input) - 1];
            _playerHandler.removeItem(item);
            _playerHandler.SetActiveGearItem(item.GearSpot, item);
        }

        private void HandelMaxScoreMeckanics() {
            _lastMenu = _menu;
            _menu = Menu.MAINMENU;
        }

        private void HandelNextRoomMeckanics() {
            _lastMenu = _menu;
            if (_input == "1") {
                CreateNextRoom();
            }
            else
                _menu = Menu.MAINMENU;
        }

        private void CreateNextRoom() {
            Random random = new Random();
            int nrEnemies = random.Next(1, 3);
            int level = random.Next(1, _playerHandler.GetUser().Level);
            _enemyList = EnemySpawner.SpawnEnemies(nrEnemies, level);
            roomNr++;
            _menu = Menu.ATTACK;
        }

        private void HandelCheckIfGameOverMeckanics() {
            if (!_playerHandler.PlayerIsAlive()) {
                SavePlayerToDB();
                _menu = Menu.GAMEOVER;
            }

            else
                _menu = Menu.ATTACK;
        }

        private void HandelErrorInput() {
            if (_input == "ERROR" && _menu != Menu.ERROR) {
                _lastMenu = _menu;
                _menu = Menu.ERROR;
                _input = "";
            }
        }
        private void HandelLoginMeckanics() {
            _lastMenu = _menu;
            HandelSettingActivePlayer();
            _menu = Menu.ATTACK;
        }


        private void HandelMainMenuMeckanics() {
            _lastMenu = _menu;
            HandelMenuSelection();
            HandleHighScoreInput();
        }

        private void HandelErrorMeckanics() {
            if (_input == "1") {
                _menu = _lastMenu;
            }
            else if (_input == "2") {
                _gameIsRunning = false;
            }

        }
        private void HandelGameOverMeckanics() {
            if (!_playerHandler.PlayerIsAlive()) { SavePlayerToDB();}
            HandelMenuSelection();



        }

        private void HandelSettingActivePlayer() {
            IUserDao userDao = new UserDao();
            _playerHandler.SetUser(userDao.GetUser(_input));
            _enemyList = EnemySpawner.SpawnEnemies(1, 1);


        }

        private void HandelAttackMeckanics() {
            // se om du har valgt å angripe en fiende eller gå til inventory
            _lastMenu = _menu;
            if (_enemyList.Count >= 1 && int.Parse(_input) <= _enemyList.Count) {
                AttackSelectedTarget();
                HandelEnemiesTurn();
                //TODO: add leves some how

                _menu = Menu.ENEMYTURN;
            }
            else if (int.Parse(_input) == _enemyList.Count + 1) {
                _menu = Menu.INVETORY;
            }
            else
                _menu = Menu.ERROR;

            if (_enemyList.Count == 0) {

                _menu = Menu.NEXTROOM;
            }


        }

        private void PlayerStatsUpdate() {
            var user = _playerHandler.GetUser();
            var lvl = user.Level;
            user.CurrentScore += 100;
            user.Level += 1;
            _playerHandler.SetUser(user);
        }

        private void AttackSelectedTarget() {
            var index = int.Parse(_input) - 1;
            _playerHandler.setTarget(_enemyList[index]);
            _playerHandler.Attack();
        }
        private void HandelEnemiesTurn() {
            List<CharacterInfo> remove = new();
            foreach (var enemy in _enemyList) {
                if (enemy.GetHealth() <= 0) {
                    remove.Add(enemy);


                }
                else {
                    var player = _playerHandler.GetPlayer();
                    if (player != null) {
                        enemy.Attack(player);
                    }
                }


            }
            foreach (var enemy in remove) {
                _enemyList.Remove(enemy);
                PlayerStatsUpdate();
            }
        }

        private void HandleHighScoreInput() {
            if (_input == "3") {
                _menu = Menu.HIGHSCORE;
            }

        }
        private void HandelMenuSelection() {
            _lastMenu = _menu;
            _users = _userDao.GetAllUsers();
            if (_input == "1") {
                _playerHandler = new PlayerHandler();

                _menu = Menu.LOGIN;

            }
            else if (_input == "2") {
                SavePlayerToDB();
                _gameIsRunning = false;
            }

        }

        private void SavePlayerToDB() {
            var user = _playerHandler.GetUser();
            _userDao.UpdateUser(user, user.Name);
        }



    }
    #endregion
}