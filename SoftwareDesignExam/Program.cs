
using Model.Abstract;
using Model.Characters;
using Model.Enums;
using Model.Factory;

namespace SoftwareDesignExam {     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal class Program {
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
            string []items = { "sword", "axe"};
            Character player = new Player(200);
           

            Character enemy = new Enemy(100);
            
            player.SetWeapon(WeaponFactory.GetWeapon(items[0],"Battel"+ items[0], 200));
            enemy.SetWeapon(WeaponFactory.GetWeapon(items[1],"normal" + items[1], 100));
            player.AddItem(GearItems.HELMET);
            player.AddItem(GearItems.SHIELD);
            player.CalculateItemStats();
            string input = "";
            var shop = new Shop(player);
            while (true) {
               
                if (playertrun) {
                    Console.WriteLine($"{room[roomNr]}");
                    Console.WriteLine("you see 1 enemy");
                    Console.WriteLine($"player health is: {player.Health}");
                    Console.WriteLine($"Enemy health is: {enemy.Health}");
                    Console.WriteLine("1 to attack or 2 to go to shop");
                    input = Console.ReadLine();
                    if (input == "1") {
                        player.DoDamage(enemy);
                        playertrun = false;

                    }
                    else if (input == "2") {
                        shop.Menu();
                        
                    }
                }
                else {
                    enemy.DoDamage(player);
                    playertrun = true;
                }
                


            }
        }
    }
}