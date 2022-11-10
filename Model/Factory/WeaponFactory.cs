
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

        
        private static string[] itemDescription =  { "Glowing ", "Burning ","Dragon ","Gold "  };
        private static int[] damageRange = { 100, 120, 170, 190, 220,340,440,550,700,1230,2200 };
        static WeaponFactory() {
            LoadInWeapons();
        }

        /// <summary>
        /// WeaponName er key verdi for å finne rett type IWeapon i Dictionary 
        /// itemDescription i lag med weaponName blir navne på våpenet døme : Golden axe
        /// dmg: hvor mye skade våpenet gjør 
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="itemDescription"></param>
        /// <param name="dmg"></param>
        /// <returns></returns>
        public static Weapon GetWeapon(string weaponName, string itemDescription, int dmg)
        {
            if (weapons.ContainsKey(weaponName.ToLower())) {
                Type weaponType = weapons[weaponName.ToLower()];
                var weapon = Activator.CreateInstance(weaponType) as Weapon;
                if (weapon != null) {
                    weapon.Damage = dmg;
                    weapon.Name = $"{itemDescription} {weaponName}";
                    return weapon;
                }
               else
                    return new NoWeapon();
            }
            else return new NoWeapon();
            

          
        }

        /// <summary>
        /// sjekker gjennom dll filer som er lastet inn i prosjektet og leiter etter Model dll filen,
        /// så ser vi gjennom alle Types som finnes i denne og legger til alle IWeapon klasser til i en dictionary
        /// med navn som key og Type som value
        /// </summary>
        private static void LoadInWeapons() {
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {

                assembly = CheckForNullName(assembly, currentassembly);

            }
            foreach (var item in assembly.GetTypes()) {
                if (item.IsSubclassOf(typeof(Weapon)) && !item.IsAbstract) {
                    if (item.Name != typeof(NoWeapon).Name) {
                       weapons.Add(item.Name.ToLower(), item);
                    }
                }
            }
        }
        /// <summary>
        /// henter et tilfeldig våpen og bygger det ved hjelp av
        /// arrayene itemDescription og damageRange
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static Weapon GenerateRandomWeapon(int level) {
            var weaponNames = LoadNameOfAllWeapons();
            var weapons = new List<Weapon>();
            Random random = new Random(); 
            var descriptionIndex = random.Next(itemDescription.Length);
            var weaponNameIndex = random.Next(weaponNames.Count);
            var dmg = damageRange[level];
            return GetWeapon(weaponNames[weaponNameIndex], itemDescription[descriptionIndex], dmg);

        }
        /// <summary>
        /// gjør det samme som LoadInWeapons men lagrer kun navne på klassene i en liste slik vi kan 
        /// få ut alle Keys til LoadInWeapons
        /// </summary>
        /// <returns>Liste av streng med navn på alle våpen i spillet</returns>
        public static List<string> LoadNameOfAllWeapons() {
            List<string> AllItems = new();
            Assembly? assembly = Assembly.GetExecutingAssembly();
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {
                assembly = CheckForNullName(assembly, currentassembly);
            }

            foreach (var item in assembly.GetTypes()) {
                if (item.IsSubclassOf(typeof(Weapon)) && !item.IsAbstract) {
                    if (item.Name != typeof(NoWeapon).Name) {
                        AllItems.Add(item.Name);
                    }
                }
            }

            return AllItems;
        }
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
