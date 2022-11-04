using System.Reflection;
using System.Reflection.Metadata;
using Model.Abstract;
using Model.Base;
using Model.Base.ConcreateDecorators;
using Model.Base.Weapons;
using Model.Decorator;
using Model.Enums;
using Model.Factory;
using Model.Interface;
using Persistence.Db;
using Presentation;
using Presentation.Views;

namespace SoftwareDesignExam
{
    internal class Game
    {

        private Menu lastMenu;
        private Menu menu = Menu.MAINMENU;


        private int enemyIndex;

        private string input;
        private Character player = new StartingCharacter();
        private AttackMenuView attackMenu;
        private List<Character> enemyList;

        public User _user = new();
        public UserDao _userDao = new();


        private IUI ui;
        private Character target;
        private Dictionary<GearSpot, ShopItem> invetory;
        private bool gameIsRunning = true;


        public Game()
        {
            List<string> ListOfAllItems = GetNameOFAllItemsInGame();
            List<ShopItem> shopItems = CreateAllShopItems();
            // PrintAllItemsInGame(shopItems);

            //setting up all shop weapons
            List<IWeapon> weapons = new();
            List<string> allWeapons = LoadNameOfAllWeapons();

            CreateRandomNamedWeapons(weapons, allWeapons);

            var test = new Dictionary<GearSpot, Item>();
            test.Add(GearSpot.TRINCKET, Item.RABBITSFOOT);
            player.SetWeapon(StartingWeapon());


            invetory = new();

            CreateInventory(shopItems, invetory);
            User enemyUser = new User();
            enemyUser.Name = "orc";
            enemyUser.Level = 1;
            enemyUser.Topscore = 0;
            
            Character orc = new StartingCharacter(enemyUser, StartingWeapon(), test);


            orc = ItemDecoratorFactory.GetItems(invetory.Values.ToList(), orc);
            Character orc2 = new StartingCharacter(enemyUser, StartingWeapon(), test);


            orc2 = ItemDecoratorFactory.GetItems(invetory.Values.ToList(), orc2);
            enemyList = new List<Character>();
            enemyList.Add(orc);
            enemyList.Add(orc2);


            ui = new UI(player, enemyList);
            
        }

        public void Draw()
        {
            ui.Draw(menu);
        }

        public void HandelInput()
        {
            switch (menu)
            {
                case Menu.ATTACK:
                {
                    lastMenu = menu;
                    input = ui.ReadIntInput();
                    if (input == "1" || input == "2")
                    {
                        SelectEnemyTarget();
                        EquiptSelectedItems();
                        AttackSelectedTarget();
                    }
                    else
                    {
                        menu = Menu.ERROR;
                    }
                    break;
                }
                case Menu.LOGIN:
                {
                    lastMenu = menu;
                    input = ui.ReadStringInput();
                    if (input.Length == 0 )
                    {
                        menu = Menu.ERROR;
                    }
                    break;
                }
                case Menu.ERROR:
                {
                    input = ui.ReadIntInput();
                    break;
                }
                case Menu.GAMEOVER:
                {
                    input = ui.ReadStringInput();
                    break;
                }

                case Menu.MAINMENU:
                {
                    input = ui.ReadStringInput();
                    break;
                }
            }
        }

        private void EquiptSelectedItems()
        {
            player = ItemDecoratorFactory.GetItems(invetory.Values.ToList(), player);
        }

        private void AttackSelectedTarget()
        {
            var index = int.Parse(input) - 1;

            target = enemyList[index];
        }

        private void SelectEnemyTarget()
        {
            var index = int.Parse(input) - 1;

            target = enemyList[index];
        }

        /// <summary>
        /// for Database hantering og spill relaterte opprasjoner
        /// </summary>
        public void HandelGameMecnaics()
        {
            switch (menu)
            {
                case Menu.ATTACK:
                {
                    player.Attack(target);
                    break;
                }

                case Menu.GAMEOVER:
                {
                    handleGameOverInput();
                    break;
                }
                case Menu.MAINMENU:

                {
                    handleGameOverInput();
                    handleHighScoreInput();
                    break;
                }

                case Menu.LOGIN:
                {
                    IUserDAO userDAO = new UserDao();
                    User user = userDAO.GetUser(input);
                    player = new StartingCharacter(user, StartingWeapon(), new Dictionary<GearSpot, Item>());
                    ui.SetPlayer(player, enemyList);
                    menu = Menu.ATTACK;
                    break;
                }
                case Menu.ERROR:
                {
                    if (input == "1" )
                    {
                        menu = lastMenu;
                    }else if(input == "2")
                    {
                        //menu = Menu.GAMEOVER
                    }else if (input.Length < 0)
                    {
                        //Fungerer ikke akkurat nå
                        menu = Menu.ERROR;
                    }
                    break;
                }
                 
            }
        }

        private void handleHighScoreInput()
        {
            if (input == "3")
            {
                Console.Clear();
                Console.WriteLine("here is the topsore");
                Console.ReadLine();
            }
          
        }


        private void handleGameOverInput()
        {
            if (input == "1")
            {
                menu = Menu.LOGIN;
                
            }
            if (input == "2")
            {
                gameIsRunning = false;
            }
        }
        public void Update()
        {
            while (gameIsRunning)
            {
                Draw();
                HandelInput();
                HandelGameMecnaics();
            }
        }


        private static void CreateRandomNamedWeapons(List<IWeapon> weapons, List<string> allWeapons)
        {
            string[] names = new[] { "Battel ", "Fire ", "War ", "Destruction " };
            Random random = new Random();

            foreach (var weapon in allWeapons)
            {
                var index = random.Next(0, names.Length);
                weapons.Add(WeaponFactory.GetWeapon(weapon, names[index] + weapon, 200));
            }
        }

        private static void PrintAllWeaponsInGame(List<IWeapon> weapons)
        {
            Console.WriteLine("PRINT ALL WEAPONS IN GAME");
            foreach (var item in weapons)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("DONE!!!");
        }

        private static void PrintAllItemsInGame(List<ShopItem> shopItems)
        {
            Console.WriteLine("PRINT ALL ITEMS IN GAME");
            foreach (var item in shopItems)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("DONE!!!");
        }

        private static void CreateInventory(List<ShopItem> shopItems, Dictionary<GearSpot, ShopItem> invetory)
        {
            foreach (var item in shopItems)
            {
                if (!invetory.ContainsKey(item.GearSpot))
                    invetory.Add(item.GearSpot, item);
                else
                    invetory[item.GearSpot] = item;
            }
        }

        /// <summary>
        /// loops all loaded Assembly and find the Model Assmbly(dll)
        /// then we loop all types in the assambly and look for types that has IWeapon interface attached 
        /// </summary>
        /// <returns>List of weapon names </returns>
        private static List<string> LoadNameOfAllWeapons()
        {
            List<string> AllItems = new();
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (currentassembly.FullName.Contains("Model"))
                    assembly = currentassembly;
            }

            foreach (var item in assembly.GetTypes())
            {
                if (item.GetInterface(typeof(IWeapon).ToString()) != null)
                {
                    if (item.Name != typeof(NoWeapon).Name)
                    {
                        AllItems.Add(item.Name);
                    }
                }
            }

            return AllItems;
        }


        /// <summary>
        /// Creates Shop items and gets all Items in esembly
        /// if there is a miss match in count, 
        /// we forgot too add item to CreateAllShopItem and we throw
        /// This is to make sure we set all items price,name and level
        /// </summary>
        /// <param name="ListOfAllItems"></param>
        /// <param name="shopItems"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void InitItems(out List<string> ListOfAllItems, out List<ShopItem> shopItems)
        {
            ListOfAllItems = GetNameOFAllItemsInGame();
            shopItems = CreateAllShopItems();
            if (ListOfAllItems.Count != shopItems.Count)
            {
                throw new ArgumentException($"{ListOfAllItems.Count - shopItems.Count} Missing items in Shopitems");
            }
        }

        //TODO: maybe select at random from this list?
        /// <summary>
        /// Sets up the items in the shop
        /// </summary>
        /// <returns>List of all items in game</returns>
        private static List<ShopItem> CreateAllShopItems()
        {
            List<ShopItem> shopItems = new();


            shopItems.Add(CreateNewItem("rabbitsfoot", 1, GearSpot.TRINCKET, 100));
            shopItems.Add(CreateNewItem("ironshield", 2, GearSpot.SHIELD, 200));
            shopItems.Add(CreateNewItem("woodenshield", 2, GearSpot.SHIELD, 100));


            return shopItems;
        }

        private static ShopItem CreateNewItem(string name, int level, GearSpot spot, int price)
        {
            ShopItem shopItem = new();
            shopItem.Name = name;
            shopItem.ItemLevel = level;
            shopItem.GearSpot = spot;
            shopItem.Price = price;

            return shopItem;
        }

        /// <summary>
        /// Looks thru all the assemblys that are loaded
        /// and finds Model Assembly
        /// then looks for childeren of CharacterDecorator 
        /// </summary>
        /// <returns>List of all items in Model dll</returns>
        private static List<string> GetNameOFAllItemsInGame()
        {
            List<string> AllItems = new();
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (currentassembly.FullName.Contains("Model"))
                    assembly = currentassembly;
            }

            foreach (var item in assembly.GetTypes())
            {
                if (item.IsSubclassOf(typeof(CharacterDecorator)) && !item.IsAbstract)
                {
                    if (item.Name != typeof(NoItem).Name)
                    {
                        AllItems.Add(item.Name);
                    }
                }
            }

            return AllItems;
        }

        private static GearSpot GetGearLocation(Item item)
        {
            return (GearSpot)(int)item;
        }

        private static IWeapon StartingWeapon()
        {
            string[] weapons = { "sword", "axe" };
            Random random = new Random();
            int index = random.Next(0, weapons.Length);
            return WeaponFactory.GetWeapon(weapons[index], "Battel" + weapons[index], 100);
        }
    }
}