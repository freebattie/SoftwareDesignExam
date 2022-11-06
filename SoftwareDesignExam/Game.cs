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
        private PlayerHandler playerHandler;
        private bool _gameIsRunning = true;

        public UserDao _userDao;
        private IUI ui;

        private List<Character> _enemyList;
       
        private Menu _lastMenu;
        private Menu _menu = Menu.LOGIN;

        public Game() {
            playerHandler = new PlayerHandler();
            _enemyList = new List<Character>();
            ui = new UI();
        }

        public void Update() {
            while (_gameIsRunning) {
                Draw();
                HandelInput();
                HandelGameMecknaics();
            }
        }

        public void Draw() {
            ui.SetActiveModels(playerHandler, _enemyList);
            ui.Draw(_menu);
        }

        public void HandelInput() {
            _input = ui.HandelPlayerInput(_menu);
            if (_input == "ERROR") {
                _lastMenu = _menu;
                _menu = Menu.ERROR;
                _input = "";
            }
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
                        HandleGameOverMeckanics();
                        break;
                    }
                case Menu.MAINMENU: {
                        _lastMenu = _menu;
                        HandelMainMenuMeckanics();
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
                        break;
                    }
                case Menu.ENEMYTURN: {
                        
                        _lastMenu = _menu;
                        if(playerHandler.GetIsDead())
                        _menu = Menu.GAMEOVER;
                        else
                            _menu = Menu.ATTACK;
                        break;
                    }

                case Menu.INVETORY: {
                        _lastMenu = _menu;
                        if (int.Parse(_input) <= playerHandler.GetInventory().Count) {
                            var items = playerHandler.GetInventory();

                            var item = items[int.Parse(_input) - 1];
                            playerHandler.removeItem(item);
                            playerHandler.SetActiveGearItem(item.GearSpot, item);
                            break;
                        }
                        else if(int.Parse(_input) == playerHandler.GetInventory().Count+1) {
                            playerHandler.EquiptAllActiveItems();
                            _menu = Menu.ATTACK;
                            break;
                        }
                        else
                            _menu = Menu.ERROR;
                        break;
                    }

            }
        }

        private void HandelLoginMeckanics() {
            HandelSettingActivePlayer();
            _menu = Menu.ATTACK;
        }

        private void HandelMainMenuMeckanics() {
            HandleGameOverMeckanics();
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
            playerHandler.SetUser(userDao.GetUser(_input));
            _enemyList = EnemySpawner.SpawnEnemies(3, 1);
            //ui.SetActiveModels(playerHandler, enemyList);

        }

        private void HandelAttackMeckanics() {
            // se om du har valgt å angripe en fiende eller gå til inventory
            
            if (_enemyList.Count >= 1 && int.Parse(_input) <= _enemyList.Count) {
                AttackSelectedTarget();
                HandelEnemiesTurn();
                //playerHandler.GetPlayer().GetHealth()
                if (playerHandler.GetPlayer().GetHealth() <0) {
                    var user = playerHandler.GetUser();
                    if (user.CurrentScore > user.Topscore) {
                        user.Topscore = user.CurrentScore;
                    }
                    UserDao dao = new();
                    
                    dao.UpdateUser(user, user.Name);
                    playerHandler.SetIsDead(true);

                }
                _menu = Menu.ENEMYTURN;

            }
            else if(int.Parse(_input) == _enemyList.Count + 1) {
                _menu = Menu.INVETORY;
            }
            else
                _menu = Menu.ERROR;
        }

        private void AttackSelectedTarget() {
            var index = int.Parse(_input) - 1;
            playerHandler.setTarget(_enemyList[index]);
            playerHandler.Attack();
        }
        private void HandelEnemiesTurn() {
            List<Character> remove = new();
            foreach (var enemy in _enemyList) {
                if (enemy.GetHealth() <= 0) {
                    remove.Add(enemy);
                }else
                    enemy.Attack(playerHandler.GetPlayer());

            }
            foreach (var enemy in remove) { 
                _enemyList.Remove(enemy);
            }
        }

        private void HandleHighScoreInput() {
            if (_input == "3") {
                Console.Clear();
                Console.WriteLine("here is the topsore");
                Console.ReadLine();
            }

        }
        private void HandleGameOverMeckanics() {
            if (_input == "1") {
                playerHandler = new PlayerHandler();

                _menu = Menu.LOGIN;

            }
            if (_input == "2") {
                _gameIsRunning = false;
            }
        }
     

       

    }
}