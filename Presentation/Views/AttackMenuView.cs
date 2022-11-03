using Model.Abstract;
using Presentation.Utils;
using Model.Interface;

namespace Presentation.Views {
    public class AttackMenuView : IView{
        private readonly Character player;
        private readonly List<Character> enemies;

        public AttackMenuView(Character player,List<Character> enemies) {
            this.player = player;
            this.enemies = enemies;
        }

        public void AttackMenu() {
            //Writer.ResetScreen();
            Writer.Print($"you see ");
            Writer.Print($"{enemies.Count}",ConsoleColor.DarkRed);
            Writer.Print($" enemys");
            Writer.PrintLine("");
            Writer.PrintLine("----------Player-------");
            Writer.PrintLine($"{player.GetDescription()}");

            Writer.PrintLine("----------Enemies-------");
            int index = 1;
            Writer.PrintLine("Select a Enemy to attack");
            foreach (Character enemy in enemies) {
              
                Writer.PrintLine($"{index}. {enemy.GetName()} Level: {enemy.GetLevel()} Health: {enemy.GetHealth()}");
                
                index++;
            }
            Writer.Print("Input:");            
        }

        public void Draw() {
            AttackMenu();

        }
    }
}
