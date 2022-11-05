
using Model.Abstract;
using Model.Base;
using Model.Enums;
using Model.Interface;
using Persistence.Db;
using Presentation;

namespace SoftwareDesignExam {
    public class Game {
        private string input;
        private PlayerHandler playerHandler;
        private bool gameIsRunning = true;

        public UserDao _userDao;
        private IUI ui;

        private List<Character> enemyList;
        private List<ShopItem> shopItems;

        private Menu lastMenu;
        private Menu menu = Menu.LOGIN;

        public Game() {
            playerHandler = new Model.Base.PlayerHandler();
            enemyList = new List<Character>();
            ui = new UI(playerHandler.GetPlayer(), enemyList);
        }

        public void Update() {
            while (gameIsRunning) {
                Draw();
                HandelInput();
                HandelGameMecknaics();
            }
        }

        public void Draw() {
            ui.Draw(menu);
        }

        public void HandelInput() {
            input = ui.HandelPlayerInput(menu);
        }

        /// <summary>
        /// for Database hantering og spill relaterte opprasjoner
        /// </summary>
        public void HandelGameMecknaics() {
            switch (menu) {
                case Menu.ATTACK: {
                        HandelAttackMeckanics();
                        break;
                    }
                case Menu.GAMEOVER: {
                        handleGameOverMeckanics();
                        break;
                    }
                case Menu.MAINMENU: {
                        handelMainMenuMeckanics();
                        break;
                    }

                case Menu.LOGIN: {
                        HandelLoginMeckanics();
                        break;
                    }
                case Menu.ERROR: {
                        HandelErrorMeckanics();
                        break;
                    }
                case Menu.NEXTROOM: {

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
                //menu = Menu.GAMEOVER
            }
            else if (input.Length < 0) {
                //Fungerer ikke akkurat nå
                menu = Menu.ERROR;
            }
        }

        private void HandelSettingActivePlayer() {
            IUserDAO userDAO = new UserDao();
            playerHandler.SetUser(userDAO.GetUser(input));

        }

        private void HandelAttackMeckanics() {
            if (enemyList.Count > 1) {
                AttackSelectedTarget();
                HandelEnemiesTurn();
            }
            else
                menu = Menu.NEXTROOM;
        }

        private void AttackSelectedTarget() {
            var index = int.Parse(input) - 1;
            playerHandler.setTarget(enemyList[index]);
            playerHandler.Attack();
        }
        private void HandelEnemiesTurn() {
            foreach (var enemy in enemyList) {
                enemy.Attack(playerHandler.GetPlayer());
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
        private static List<ShopItem> CreateAllShopItems() {
            List<ShopItem> shopItems = new();


            shopItems.Add(CreateNewItem("rabbitsfoot", 1, GearSpot.TRINCKET, 100));
            shopItems.Add(CreateNewItem("ironshield", 2, GearSpot.SHIELD, 200));
            shopItems.Add(CreateNewItem("woodenshield", 2, GearSpot.SHIELD, 100));


            return shopItems;
        }

        private static ShopItem CreateNewItem(string name, int level, GearSpot spot, int price) {
            ShopItem shopItem = new();
            shopItem.Name = name;
            shopItem.ItemLevel = level;
            shopItem.GearSpot = spot;
            shopItem.Price = price;

            return shopItem;
        }

    }
}