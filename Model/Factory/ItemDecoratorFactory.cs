
using Model.Base.Shop;
using Model.Decorator;
using Model.Decorator.Abstract;
using Model.Decorator.Items;
using System.Reflection;

namespace Model.Factory
{
    public static class ItemDecoratorFactory {

        private static Dictionary<string, Type> decoratorItems = new();


        static ItemDecoratorFactory() {
            LoadInAllItemsFromAssambly();
        }

        /// <summary>
        /// dekorere spilleren med alle gitte items på korekt plass(gearspot)
        /// </summary>
        /// <param name="items"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public static CharacterInfo GetItems(List<ShopItem> items, CharacterInfo original) {

            
            foreach (var item in items) {
                if (decoratorItems.ContainsKey(item.Name.ToLower())) {
                    Type decoratorItem = decoratorItems[item.Name.ToLower()];
                    var characterGear = Activator.CreateInstance(decoratorItem, original) as CharacterGearDecorator;
                    if (characterGear != null) 
                        original = characterGear;
        
                }
                else
                    return new NoItem(original);
            }



            return original;
        }
        /// <summary>
        /// Henter ut en gitt item, hvis den ikke finnes retunere en NoItem decorator slik at vi aldri får null
        /// tilbake fra Decorator Factoryen
        /// </summary>
        /// <param name="item"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public static CharacterInfo GetItem(string item, CharacterInfo original) {

            if (decoratorItems.ContainsKey(item)) {
                Type decoratorItem = decoratorItems[item.ToLower()];
                var geardecorator = Activator.CreateInstance(decoratorItem, original) as CharacterGearDecorator;
                if (geardecorator != null) 
                    return geardecorator;
                else
                    return new NoItem(original);

            }
            else
            return new NoItem(original);



           
        }
        /// <summary>
        /// Laster inn alle Items fra Model Class libraryen ved hjelp av reflaction
        /// vi leter først gjennom alle Asambly som er lastet inn i minne 
        /// så finner vi Model og finner alle Typer den har 
        /// legger så til alle typer som arver fra CharacterGearDecorator til i en Dictionary
        /// bassert på Gearspot som key og type som value
        /// </summary>
        public static void LoadInAllItemsFromAssambly() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                assembly = CheckForNullName(assembly, currentassembly);

            }

            foreach (var item in assembly.GetTypes()) {

                if (item.IsSubclassOf(typeof(CharacterGearDecorator)) && !item.IsAbstract) {
                    if (item.Name != typeof(NoItem).Name) {
                        decoratorItems.Add(item.Name.ToLower(), item);
                    }
                }
            }
        }

        /// <summary>
        /// Henter ut navna på alle items vi har
        /// </summary>
        /// <returns></returns>
        public static List<string> GetNameOFAllItemsInGame() {
            List<string> AllItems = new();
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {
                assembly = CheckForNullName(assembly, currentassembly);

            }

            foreach (var item in assembly.GetTypes()) {
                if (item.IsSubclassOf(typeof(CharacterGearDecorator)) && !item.IsAbstract) {
                    if (item.Name != typeof(NoItem).Name) {
                        AllItems.Add(item.Name);
                    }
                }
            }

            return AllItems;
        }
        /// <summary>
        /// Sjekker at Model class library er lastet inn i minne slik vi kan finne alle items
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="currentassembly"></param>
        /// <returns></returns>
        private static Assembly CheckForNullName(Assembly assembly, Assembly currentassembly) {
            var name = currentassembly.FullName;
            if (name != null) {
                if (name.Contains("Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"))
                    assembly = currentassembly;
            }

            return assembly;
        }
    }
}
