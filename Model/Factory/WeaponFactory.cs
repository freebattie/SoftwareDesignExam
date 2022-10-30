


using Model.Base.ConcreateDecorators;
using Model.Base.Weapons;
using Model.Interface;
using System.Reflection;

namespace Model.Factory
{
    //TODO: fix null return value
    //TODO: create abstract factory
    public static class WeaponFactory
    {
        private static Dictionary<string, Type> weapons = new();

        static WeaponFactory() {
            LoadInWeapons();
        }
        public static IWeapon GetWeapon(string weaponName, string name, int dmg)
        {
            Type weaponType = weapons[weaponName.ToLower()];
            if (weaponType == null) return new NoWeapon();
            var weapon = Activator.CreateInstance(weaponType) as IWeapon;
            weapon.Damage = dmg;
            weapon.Name = name;
            return weapon;

          
        }
        public static void LoadInWeapons() {
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                if (currentassembly.FullName.Contains("Model"))
                    assembly = currentassembly;

            }
            foreach (var item in assembly.GetTypes()) {
                if (item.GetInterface(typeof(IWeapon).ToString()) != null) {
                    if (item.Name != typeof(NoWeapon).Name) {
                       weapons.Add(item.Name.ToLower(), item);
                    }
                }
            }
        }
    }
}
