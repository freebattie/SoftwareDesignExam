

using Model.Base;
using Model.Interface;

namespace Model.Factory
{
    //TODO: fix null return value
    //TODO: create abstract factory
    public class WeaponFactory
    {

        public static IWeapon GetWeapon(string weaponName, string name, int dmg)
        {

            switch (weaponName)
            {
                case "axe": return new Axe(dmg, name);
                case "sword": return new Sword(dmg, name);
            }

            return null;
        }
    }
}
