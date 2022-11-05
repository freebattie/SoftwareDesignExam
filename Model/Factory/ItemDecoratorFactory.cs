
using Model.Abstract;
using Model.Base;
using Model.Base.ConcreateDecorators;
using Model.Base.Weapons;
using Model.Decorator;
using Model.Enums;
using Model.Interface;
using System.Reflection;

namespace Model.Factory {
    public static class ItemDecoratorFactory {

        private static Dictionary<string, Type> decoratorItems = new();


        static ItemDecoratorFactory() {
            LoadInAllItemsFromAssambly();
        }

        public static Character GetItems(List<ShopItem> items, Character original) {

           
            foreach (var item in items) {

                Type decoratorItem = decoratorItems[item.Name.ToLower()];
                if (decoratorItem == null) return new NoItem(original);
                original = Activator.CreateInstance(decoratorItem, original) as CharacterDecorator;


            }



            return original;
        }

        public static void LoadInAllItemsFromAssambly() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                if (currentassembly.FullName.Contains("Model"))
                    assembly = currentassembly;

            }

            foreach (var item in assembly.GetTypes()) {

                if (item.IsSubclassOf(typeof(CharacterDecorator)) && !item.IsAbstract) {
                    if (item.Name != typeof(NoItem).Name) {
                        decoratorItems.Add(item.Name.ToLower(), item);
                    }
                }
            }
        }
        public static List<string> GetNameOFAllItemsInGame() {
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
    }
}
