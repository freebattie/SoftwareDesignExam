using Model.Base.Enemies;
using Model.Base.Enums;
using Model.Base.Player;
using Model.Base.Shop;
using Model.Decorator.Abstract;
using Model.Interface;
using Persistence.Db;
using Presentation;

namespace SoftwareDesignExam
{
    public class Game {
        private string _input;
        private PlayerHandler _playerHandler;
        private bool _gameIsRunning = true;
        private List<ShopItem> _allItems;
        public UserDao _userDao;
        private IUI _ui;

        private List<Character> _enemyList;
       
        private Menu _lastMenu;
        private Menu _menu = Menu.MAINMENU;
        private List<User> _users;

        private int roomNr = 1;

        public Game() {
            //Load all items
            IItemDao dao = new ItemDao();
             _allItems = dao.GetAllItems();
            ShopItemSpawner.SetAllShopItems(_allItems);

            //TODO: kanskje bruke singelton pattern?
            _userDao = new UserDao();
            _playerHandler = new PlayerHandler();
            _enemyList = new List<Character>();
            _ui = new UI();
        }

        public void Update() {
            while (_gameIsRunning) {
                
                Draw();
                HandelInput();
                HandelGameMecknaics();
                
            }
        }

        public void Draw() {
            _ui.SetActiveModels(_playerHandler, _enemyList, _users, roomNr);
            _ui.Draw(_menu);
        }

        public void HandelInput() {
            _input = _ui.HandelPlayerInput(_menu);
            HandelErrorInput();
        }

        

        /// <summary>
        /// for Database hantering og spill relaterte opprasjoner
        /// </summary>
        public void HandelGameMecknaics() {
            
            switch (_menu) {
                case Menu.ATTACK: {
                    _lastMenu = _menu;
                        HandelAttackMeckanics();
                        break;
                    }
                case Menu.GAMEOVER: {
                        _lastMenu = _menu;
                        HandelMenuSelection();
                        break;
                    }
                case Menu.MAINMENU: {
                        _lastMenu = _menu;
                        HandelMainMenuMeckanics();
                        break;
                    }
                case Menu.HIGHSCORE: {
                        _lastMenu = _menu;
                        _menu = Menu.MAINMENU;
                        break;
                    }

                case Menu.LOGIN: {
                        _lastMenu = _menu;
                        HandelLoginMeckanics();
                        break;
                    }
                case Menu.ERROR: {
                        HandelErrorMeckanics();
                        break;
                    }
                case Menu.NEXTROOM: {
                        _lastMenu = _menu;
                        if (_input == "1") {

                            Random random = new Random();
                            int nrEnemies = random.Next(1, 3);
                            int level = random.Next(1, _playerHandler.GetUser().Level);
                            _enemyList = EnemySpawner.SpawnEnemies(nrEnemies, level);
                            roomNr++;
                            _menu = Menu.ATTACK;
                        }
                        else
                            _menu = Menu.MAINMENU;
                        break;
                    }
                case Menu.ENEMYTURN: {
                        CheckIfGameOver();
                        break;
                    }

                case Menu.INVETORY: {
                        _lastMenu = _menu;
                        if (int.Parse(_input) <= _playerHandler.GetInventory().Count) {
                            var items = _playerHandler.GetInventory();

                            var item = items[int.Parse(_input) - 1];
                            _playerHandler.removeItem(item);
                            _playerHandler.SetActiveGearItem(item.GearSpot, item);
                            break;
                        }
                        else if(int.Parse(_input) == _playerHandler.GetInventory().Count+1) {
                            _playerHandler.EquiptAllActiveItems();
                            _menu = Menu.ATTACK;
                            break;
                        }
                        else
                            _menu = Menu.ERROR;
                        break;
                    }

            }
        }

        private void CheckIfGameOver() {
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
            HandelSettingActivePlayer();
            _menu = Menu.ATTACK;
        }


        private void HandelMainMenuMeckanics() {
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

        private void HandelSettingActivePlayer() {
            IUserDao userDao = new UserDao();
            _playerHandler.SetUser(userDao.GetUser(_input));
            _enemyList = EnemySpawner.SpawnEnemies(1, 1);
            

        }

        private void HandelAttackMeckanics() {
            // se om du har valgt å angripe en fiende eller gå til inventory
            
            if (_enemyList.Count >= 1 && int.Parse(_input) <= _enemyList.Count) {
                AttackSelectedTarget();
                HandelEnemiesTurn();
                //TODO: add leves some how
               
                _menu = Menu.ENEMYTURN;
            }
            else if(int.Parse(_input) == _enemyList.Count + 1) {
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
            List<Character> remove = new();
            foreach (var enemy in _enemyList) {
                if (enemy.GetHealth() <= 0) {
                    remove.Add(enemy);
                   

                }
                else
                    enemy.Attack(_playerHandler.GetPlayer());

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
}