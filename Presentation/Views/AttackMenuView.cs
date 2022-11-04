using Model.Abstract;
using Presentation.Utils;
using Model.Interface;

namespace Presentation.Views {
    public class AttackMenuView : IView{
        private  Character player;
        private  List<Character> enemies;

        private string attackHeader = @"
        _______ _______       _____ _  __
     /\|__   __|__   __|/\   / ____| |/ /
    /  \  | |     | |  /  \ | |    | ' / 
   / /\ \ | |     | | / /\ \| |    |  <  
  / ____ \| |     | |/ ____ \ |____| . \ 
 /_/    \_\_|     |_/_/    \_\_____|_|\_\

";

        public AttackMenuView(Character player,List<Character> enemies) {
           
        }

        public void AddModels<T, K>(T model, List<K> items = null) {
            player = model as Character;
            enemies = items<Character>;
        }

        public void AttackMenu() {
            Writer.ResetScreen();
            Writer.PrintLine(attackHeader);
            
            Writer.PrintLine($"Hi, {player.Name}.");
            Writer.PrintLine("");
            Writer.PrintLine($"Your health: {player.GetHealth()}");
            Writer.PrintLine($"Your current level: {player.GetLevel()}");
            //Writer.PrintLine($"Your active items: {player.GetActiveItems()}");
            
            Writer.PrintLine("");
            Writer.PrintLine("");

            
            Writer.PrintLine("----------Enemies Information-------");
            Writer.PrintLine($"Number of enemies are: {enemies.Count}");
            int index = 1;
            foreach (Character enemy in enemies) {
              
                Writer.PrintLine($"{index}. Name: {enemy.GetName()}, Health: {enemy.GetHealth()}, Level: {enemy.GetLevel()}, Items: {enemy.GetDescription()}");
                index++;
            }
            
            Writer.PrintLine("");
            Writer.PrintLine("----------Attack Menu-------");
            Writer.PrintLine("Select a Enemy to attack.");
            Writer.Print("Input:");            
        }

        public void Draw() {
            AttackMenu();

        }
    }
}
