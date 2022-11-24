using Model.Base.Weapons;
using Model.Base.Weapons.Abstract;
using System.Reflection;

namespace Model.Factory
{
    //TODO: fix null return value
    //TODO: create abstract factory
    public static class WeaponFactory
    {
        #region pivate fildes
        /// <summary>
        /// brukt til å lagre alle våpen som finnes i Model Class library
        /// </summary>
        private static Dictionary<string, Type> _weapons = new();
        private static string[] itemDescription =  { "Glowing ", "Burning ","Dragon ","Gold "  };
        private static int[] damageRange = { 100, 120, 170, 190, 220,340,440,550,700,1230,2200 };
        private static int[] priceRange = { 100, 150, 170,400};
        #endregion

        #region constructor
        static WeaponFactory() {
            LoadInWeapons();
        }

        #endregion 

        #region public static methods
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
            if (_weapons.ContainsKey(weaponName.ToLower())) {
                Type weaponType = _weapons[weaponName.ToLower()];
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
        /// henter et tilfeldig våpen og bygger det ved hjelp av
        /// arrayene itemDescription og damageRange
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static Weapon GenerateRandomWeapon(int level) {
            level = level < damageRange.Length ? level : damageRange.Length - 1;
            var weaponNames = LoadNameOfAllWeapons();
            Random random = new Random(); 
            var descriptionIndex = random.Next(itemDescription.Length);
            var weaponNameIndex = random.Next(weaponNames.Count);
            var dmg = damageRange[level];
            var priceIndex = random.Next(priceRange.Length);
            var price = priceRange[priceIndex];
            var weapon = GetWeapon(weaponNames[weaponNameIndex], itemDescription[descriptionIndex], dmg);
            weapon.Price = price;
            return weapon;

        }
        public static List<Weapon> GenerateOneOfEachWeaponRandom(int level) {
            level = level < damageRange.Length ? level : damageRange.Length - 1;
            var weaponNames = LoadNameOfAllWeapons();
            var weapons = new List<Weapon>();
            Random random = new Random();
           
            var index = 0;
            while(index < weaponNames.Count) {
                var descriptionIndex = random.Next(itemDescription.Length);
                var priceIndex = random.Next(priceRange.Length);
                var price = priceRange[priceIndex];
                var dmg = damageRange[level];
                var weapon = GetWeapon(weaponNames[index], itemDescription[descriptionIndex], dmg);
                weapon.Price = price;
                weapons.Add(weapon);
                index++;
            }
            return weapons;
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
        #endregion

        #region private static methods
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
                        _weapons.Add(item.Name.ToLower(), item);
                    }
                }
            }
        }
        private static Assembly CheckForNullName(Assembly assembly, Assembly currentassembly) {
            var name = currentassembly.FullName;
            if (name != null) {
                if (name.Contains("Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"))
                    assembly = currentassembly;
            }

            return assembly;
        }
        #endregion
    }
}
