
using Model.Abstract;
using Model.Base;
using Model.Decorator;
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
            string[] weapons = { "sword", "axe" };
            Character player2 = CreateStaringPlayer(weapons);
            Character player3 = CreateEnemy1(weapons);
            string input = "";

            while (true) {

                if (playertrun) {

                    Console.WriteLine("you see 1 enemy");
                    Console.WriteLine($"player health is: {player2.GetHealth()}");
                    Console.WriteLine($"Enemy health is: {player3.GetHealth()}");
                    Console.WriteLine("1 to attack or 2 to go to shop");
                    input = Console.ReadLine();
                    if (input == "1") {
                        // player.DoDamage(enemy);
                        player2.Attack(player3);
                        playertrun = false;

                    }
                    else if (input == "2") {


                    }
                }
                else {

                    playertrun = true;
                }



            }
        }

        private static Character CreateEnemy1(string[] weapons) {
            Character player3 = new Level1Player();
            player3.SetWeapon(WeaponFactory.GetWeapon(weapons[1], "normal" + weapons[1], 100));
            player3 = new RabbitsFoot(player3);
            return player3;
        }

        private static Character CreateStaringPlayer(string[] weapons) {
            Character player = new Level1Player();

            player.SetWeapon(WeaponFactory.GetWeapon(weapons[0], "Battel" + weapons[0], 200));
            List<Item> items = new List<Item> { Item.RABBITSFOOT, Item.WOODENSHIELD };
            Character player2 = ItemDecoratorFactory.GetItems(items, player);
            return player2;
        }
    }
}