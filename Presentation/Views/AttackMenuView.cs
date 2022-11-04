using Model.Abstract;
using Presentation.Utils;
using Model.Interface;

namespace Presentation.Views {
    public class AttackMenuView : IView{
        private  Character player;
        private  List<Character> enemies;

        public AttackMenuView(Character player,List<Character> enemies) {
           
        }

        public void AddModels<T, K>(T model, List<K> items = null) {
            player = model as Character;
            enemies = items<Character>;
        }

        public void AttackMenu() {
            Writer.ResetScreen();
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
