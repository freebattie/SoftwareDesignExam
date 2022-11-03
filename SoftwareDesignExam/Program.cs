

using Model.Abstract;
using Model.Base;
using Model.Base.Weapons;
using Model.Base.ConcreateDecorators;
using Model.Decorator;
using Model.Enums;
using Model.Factory;
using Model.Interface;

using System.Reflection;
using Persistence.Db;
using Presentation.Views;

namespace SoftwareDesignExam
{     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal partial class Program
    {
        private static UserMenu _userMenu = new();

        static void Main(string[] args) {
            //TableMaker.UsersSchemaAndTableMaker();
           
            Game game = new();
            game.Update();


        }

        private static void CreateRandomNamedWeapons(List<IWeapon> weapons, List<string> allWeapons) {
            string[] names = new[] { "Battel ", "Fire ", "War ", "Destruction " };
            Random random = new Random();

            foreach (var weapon in allWeapons) {
                var index = random.Next(0, names.Length);
                weapons.Add(WeaponFactory.GetWeapon(weapon, names[index] + weapon, 200));
            }
        }

        private static void PrintAllWeaponsInGame(List<IWeapon> weapons) {
            Console.WriteLine("PRINT ALL WEAPONS IN GAME");
            foreach (var item in weapons) {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("DONE!!!");
        }

        private static void PrintAllItemsInGame(List<ShopItem> shopItems) {
            Console.WriteLine("PRINT ALL ITEMS IN GAME");
            foreach (var item in shopItems) {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("DONE!!!");
        }

        private static void CreateInventory(List<ShopItem> shopItems, Dictionary<GearSpot, ShopItem> invetory) {
            foreach (var item in shopItems) {
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
        private static List<string> LoadNameOfAllWeapons() {
            List<string> AllItems = new();
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                if (currentassembly.FullName.Contains("Model"))
                    assembly = currentassembly;

            }
            foreach (var item in assembly.GetTypes()) {
                if (item.GetInterface(typeof(IWeapon).ToString()) != null) {
                    if (item.Name != typeof(NoWeapon).Name) {
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
        private static void InitItems(out List<string> ListOfAllItems, out List<ShopItem> shopItems) {
            ListOfAllItems = GetNameOFAllItemsInGame();
            shopItems = CreateAllShopItems();
            if (ListOfAllItems.Count != shopItems.Count) {
                throw new ArgumentException($"{ListOfAllItems.Count - shopItems.Count} Missing items in Shopitems");
            }
        }

        //TODO: maybe select at random from this list?
        /// <summary>
        /// Sets up the items in the shop
        /// </summary>
        /// <returns>List of all items in game</returns>
        private static List<ShopItem> CreateAllShopItems() {
            List<ShopItem> shopItems = new();

            
            shopItems.Add(CreateNewItem("rabbitsfoot", 1, GearSpot.TRINCKET, 100));
            shopItems.Add(CreateNewItem("ironshield", 2, GearSpot.SHIELD, 200));
            shopItems.Add(CreateNewItem("woodenshield", 2, GearSpot.SHIELD, 100));


            return shopItems;
        }

        private static ShopItem CreateNewItem(string name,int level, GearSpot spot, int price) {
            ShopItem shopItem = new ();
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
        private static List<string> GetNameOFAllItemsInGame() {
            List<string> AllItems = new();
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                if (currentassembly.FullName.Contains("Model"))
                    assembly = currentassembly;

            }
            foreach (var item in assembly.GetTypes()) {
                if (item.IsSubclassOf(typeof(CharacterDecorator)) && !item.IsAbstract) {
                    if (item.Name != typeof(NoItem).Name) {
                        AllItems.Add(item.Name);
                    }
                }

            }
            return AllItems;
        }

        private static GearSpot GetGearLocation(Item item) {
            return (GearSpot)(int)item;
        }
        private static IWeapon StartingWeapon() {
            string[] weapons = { "sword", "axe" };
            Random random = new Random();
            int index = random.Next(0, weapons.Length);
            return WeaponFactory.GetWeapon(weapons[index], "Battel" + weapons[index], 100);
        }
    }
}