using SoftwareDesignExam.Abstract;
using SoftwareDesignExam.Factory;
using SoftwareDesignExam.Interface;

namespace SoftwareDesignExam {
    public class Shop {
        
        List<IWeapon> weapons = new();


        public Shop(Character player) {
            weapons.Add(WeaponFactory.GetWeapon("axe","FireAxe",215));
            weapons.Add(WeaponFactory.GetWeapon("axe","Normal Axe",124));
        }
        public void Menu() {
            Console.WriteLine("here is the shop");
            Console.WriteLine("We sell the following");
            int x = 1;
            foreach (var weapon in weapons) {

                Console.WriteLine($"item name is :{weapon.Name}");
                Console.WriteLine($"it does {weapon.Damage} damage");
                Console.WriteLine("");
            }
            foreach (var weapon in weapons) {

                Console.WriteLine($"{x} = {weapon.Name}");
                x++;
            }

            
        }
    }
}
