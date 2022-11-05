

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
        private string input;
        private PlayerHandler playerHandler;
        private bool gameIsRunning = true;

        public UserDao _userDao;
        private IUI ui;

        private List<Character> enemyList;
       
        private Menu lastMenu;
        private Menu menu = Menu.LOGIN;

        public Game() {
            playerHandler = new PlayerHandler();
            enemyList = new List<Character>();
            ui = new UI();
        }

        public void Update() {
            while (gameIsRunning) {
                Draw();
                HandelInput();
                HandelGameMecknaics();
            }
        }

        public void Draw() {
            ui.SetActiveModels(playerHandler, enemyList);
            ui.Draw(menu);
        }

        public void HandelInput() {
            input = ui.HandelPlayerInput(menu);
            if (input == "ERROR") {
                lastMenu = menu;
                menu = Menu.ERROR;
                input = "";
            }
        }

        /// <summary>
        /// for Database hantering og spill relaterte opprasjoner
        /// </summary>
        public void HandelGameMecknaics() {
            
            switch (menu) {
                case Menu.ATTACK: {
                        lastMenu = menu;
                        HandelAttackMeckanics();
                        break;
                    }
                case Menu.GAMEOVER: {
                        lastMenu = menu;
                        handleGameOverMeckanics();
                        break;
                    }
                case Menu.MAINMENU: {
                        lastMenu = menu;
                        handelMainMenuMeckanics();
                        break;
                    }

                case Menu.LOGIN: {
                        lastMenu = menu;
                        HandelLoginMeckanics();
                        break;
                    }
                case Menu.ERROR: {
                        HandelErrorMeckanics();
                        break;
                    }
                case Menu.NEXTROOM: {
                        lastMenu = menu;
                        break;
                    }
                case Menu.INVETORY: {
                        lastMenu = menu;
                        if (int.Parse(input) <= playerHandler.GetInventory().Count) {
                            var items = playerHandler.GetInventory();

                            var item = items[int.Parse(input) - 1];
                            playerHandler.removeItem(item);
                            playerHandler.SetActiveGearItem(item.GearSpot, item);
                            break;
                        }
                        else if(int.Parse(input) == playerHandler.GetInventory().Count+1) {
                            playerHandler.EquiptAllActiveItems();
                            menu = Menu.ATTACK;
                            break;
                        }
                        else
                            menu = Menu.ERROR;
                        break;
                    }

            }
        }

        private void HandelLoginMeckanics() {
            HandelSettingActivePlayer();
            menu = Menu.ATTACK;
        }

        private void handelMainMenuMeckanics() {
            handleGameOverMeckanics();
            handleHighScoreInput();
        }

        private void HandelErrorMeckanics() {
            if (input == "1") {
                menu = lastMenu;
            }
            else if (input == "2") {
                gameIsRunning = false;
            }
           
        }

        private void HandelSettingActivePlayer() {
            IUserDAO userDAO = new UserDao();
            playerHandler.SetUser(userDAO.GetUser(input));
            enemyList = EnemySpawner.SpawnEnemies(3, 2);
            //ui.SetActiveModels(playerHandler, enemyList);

        }

        private void HandelAttackMeckanics() {
            // se om du har valgt å angripe en fiende eller gå til inventory
            
            if (enemyList.Count >= 1 && int.Parse(input) <= enemyList.Count) {
                AttackSelectedTarget();
                HandelEnemiesTurn();
            }
            else if(int.Parse(input) == enemyList.Count + 1) {
                menu = Menu.INVETORY;
            }
            else
                menu = Menu.ERROR;
        }

        private void AttackSelectedTarget() {
            var index = int.Parse(input) - 1;
            playerHandler.setTarget(enemyList[index]);
            playerHandler.Attack();
        }
        private void HandelEnemiesTurn() {
            List<Character> remove = new();
            foreach (var enemy in enemyList) {
                if (enemy.GetHealth() <= 0) {
                    remove.Add(enemy);
                }else
                    enemy.Attack(playerHandler.GetPlayer());

            }
            foreach (var enemy in remove) { 
                enemyList.Remove(enemy);
            }
        }

        private void handleHighScoreInput() {
            if (input == "3") {
                Console.Clear();
                Console.WriteLine("here is the topsore");
                Console.ReadLine();
            }

        }
        private void handleGameOverMeckanics() {
            if (input == "1") {
                menu = Menu.LOGIN;

            }
            if (input == "2") {
                gameIsRunning = false;
            }
        }
     

       

    }
}