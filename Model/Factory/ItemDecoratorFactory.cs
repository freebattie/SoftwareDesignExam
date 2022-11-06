﻿
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

        public static Character GetItems(List<ShopItem> items, Character original) {

           
            foreach (var item in items) {
                if (decoratorItems.ContainsKey(item.Name.ToLower())) {
                    Type decoratorItem = decoratorItems[item.Name.ToLower()];
                    original = Activator.CreateInstance(decoratorItem, original) as CharacterDecorator;
                }
                else
                    return new NoItem(original);
            }



            return original;
        }
        public static Character GetItem(string item, Character original) {

            if (decoratorItems.ContainsKey(item)) {
                Type decoratorItem = decoratorItems[item.ToLower()];
                return Activator.CreateInstance(decoratorItem, original) as CharacterDecorator;
            }
            else
            return new NoItem(original);



           
        }

        public static void LoadInAllItemsFromAssambly() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                if (currentassembly.FullName.Contains("Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"))
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
                if (currentassembly.FullName.Contains("Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"))
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
