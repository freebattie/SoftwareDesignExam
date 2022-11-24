using Model.Decorator.Abstract;
using Model.Factory;
using Model.Base.Weapons.Abstract;

namespace SoftwareDesignExam
{
    public class Shop {
        
        List<Weapon> weapons = new();


        public Shop(CharacterInfo player) {
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
