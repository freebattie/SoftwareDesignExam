using Model.Base;
using Model.Base.Shop;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views.ShopView
{
    internal class ShopWeaponView : IView
    {
        public ShopWeaponView() {

        }
        public ShopWeaponView(List<Weapon> allWeapons) {
            this.allWeapons = allWeapons;
        }
        int index = 0;
        private List<Weapon> allWeapons;

        public void Draw() {
            foreach (var item in allWeapons) {
                Writer.PrintLine($"{index}. Name: {item.Name} Lvl: {item.Damage} Price: {item.Price}" +
                    $"/nDecription: {item.Description}");
                Writer.PrintLine("");
                index++;
            }

        }
    }
}
