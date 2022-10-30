using Model.Abstract;
using Model.Base;
using Model.Enums;
using Model.Factory;
using Model.Interface;
using Presentation.Utils;
using Presentation.Views;


namespace SoftwareDesignExam {
    internal class Game {

        private Menu menu;
        private int enemyIndex;
        Game() {
            AttackMenuView attackMenu;
           
        }

        public void Draw() {
            List<string> ListOfAllItems = GetNameOFAllItemsInGame();
            List<ShopItem> shopItems = CreateAllShopItems();
            // PrintAllItemsInGame(shopItems);

            //setting up all shop weapons
            List<IWeapon> weapons = new();
            List<string> allWeapons = LoadNameOfAllWeapons();

            CreateRandomNamedWeapons(weapons, allWeapons);

            //PrintAllWeaponsInGame(weapons);

            Dictionary<GearSpot, ShopItem> invetory = new();
            CreateInventory(shopItems, invetory);


            bool playertrun = true;


            //Ikke i bruk akkurat no

            var test = new Dictionary<GearSpot, Item>();
            test.Add(GearSpot.TRINCKET, Item.RABBITSFOOT);


            Character player = new StartingCharacter("Bjarte", StartingWeapon(), test);
            Character orc = new StartingCharacter("Orc", StartingWeapon(), test);
            //(player.AddItemToInventory(GearSpot.TRINCKET, Item.RABBITSFOOT);

            player = ItemDecoratorFactory.GetItems(invetory.Values.ToList(), player);
            orc = ItemDecoratorFactory.GetItems(invetory.Values.ToList(), orc);
            List<Character> enemyList = new();
            enemyList.Add(orc);
            enemyList.Add(orc);
            string input = "";



            switch (menu) {
                case Menu.ATTACK: {

                        break;
                    }

            }

        }
        public void HandelInput() {
            switch (menu) {
                case Menu.ATTACK: {
                        enemyIndex = int.Parse(Reader.ReadInt());
                        break;
                    }
                
            }
        }

        public void HandelGameMecnaics() {
            switch (menu) {
                case Menu.ATTACK: {
                        enemyIndex = int.Parse(Reader.ReadInt());
                        break;
                    }
                
            }
        }

        public void Update() {

            while (true) {
                Draw();
                HandelInput();
                HandelGameMecnaics();
            }
        }

    }
}
