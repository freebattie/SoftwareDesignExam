
using Model.Abstract;
using Model.Base;
using Model.Decorator;
using Model.Enums;

namespace Model.Factory {
    public class ItemDecoratorFactory {

        public static Character GetItems(List<Item> items, Character original) {

            foreach (var item in items) {
                switch (item) {

                    case Item.WOODENSHIELD:
                    original = new WoodenShiled(original);
                    break;
                    case Item.IRONSHILED:
                    original = new IronShield(original);
                    break;
                    case Item.RABBITSFOOT:
                    original = new RabbitsFoot(original);
                    break;
                    default:
                    original = new NoItem(original);
                    break;
                }
            }
            return original;
            

        }
    }
}
