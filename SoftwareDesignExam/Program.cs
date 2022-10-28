

using Model.Abstract;
using Model.Base;
using Model.Enums;
using Model.Factory;
using Model.Interface;

namespace SoftwareDesignExam {     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal partial class Program {
        static void Main(string[] args) {


            bool playertrun = true;
            string[] room = { @"
$$$$$$$\                                                $$$$$$$\                                                                    
$$  __$$\                                               $$  __$$\                                                                   
$$ |  $$ | $$$$$$\   $$$$$$\  $$\   $$\  $$$$$$\        $$ |  $$ |$$\   $$\ $$$$$$$\   $$$$$$\   $$$$$$\   $$$$$$\  $$$$$$$\        
$$$$$$$  |$$  __$$\ $$  __$$\ $$ |  $$ |$$  __$$\       $$ |  $$ |$$ |  $$ |$$  __$$\ $$  __$$\ $$  __$$\ $$  __$$\ $$  __$$\       
$$  __$$< $$ /  $$ |$$ /  $$ |$$ |  $$ |$$$$$$$$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ /  $$ |$$$$$$$$ |$$ /  $$ |$$ |  $$ |      
$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$   ____|      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$   ____|$$ |  $$ |$$ |  $$ |      
$$ |  $$ |\$$$$$$  |\$$$$$$$ |\$$$$$$  |\$$$$$$$\       $$$$$$$  |\$$$$$$  |$$ |  $$ |\$$$$$$$ |\$$$$$$$\ \$$$$$$  |$$ |  $$ |      
\__|  \__| \______/  \____$$ | \______/  \_______|      \_______/  \______/ \__|  \__| \____$$ | \_______| \______/ \__|  \__|      
                    $$\   $$ |                                                        $$\   $$ |                                    
                    \$$$$$$  |                                                        \$$$$$$  |                                    
                     \______/                                                          \______/                                     
", "room2" };
            Console.WriteLine(@"");
            int roomNr = 0;
            var test = new Dictionary<GearSpot, Item>();
            test.Add(GearSpot.TRINCKET, Item.RABBITSFOOT);
            Character player = new StartingCharacter("Bjarte", StartingWeapon(), test);
            Character orc = new StartingCharacter("Orc", StartingWeapon(), test);

            player.AddItemToActiveItems(GearSpot.HELMET, Item.RABBITSFOOT);
            string input = "";

            while (true) {

                if (playertrun) {

                    Console.WriteLine("you see 1 enemy");
                    Console.WriteLine($"player health is: {player.GetHealth()}");
                    Console.WriteLine($"Enemy health is: {orc.GetHealth()}");
                    Console.WriteLine("1 to attack or 2 to go to shop");
                    input = Console.ReadLine();
                    if (input == "1") {
                        player.Attack(orc);
                       
                    }
                    else if (input == "2") {


                    }
                }
                else {

                    playertrun = true;
                }



            }
        }

        private static IWeapon StartingWeapon() {
            string[] weapons = { "sword", "axe" };
            Random random = new Random();
            int index = random.Next(0, weapons.Length);
            return WeaponFactory.GetWeapon(weapons[index], "Battel" + weapons[index], 100);
        }
    }
}