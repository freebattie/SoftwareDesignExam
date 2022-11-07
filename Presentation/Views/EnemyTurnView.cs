using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views {
    internal class EnemyTurnView : IView {
        private readonly PlayerHandler playerHandler;
        private readonly List<Character> enemies;

        public EnemyTurnView(PlayerHandler playerHandler, List<Character> enemies) {
            this.playerHandler = playerHandler;
            this.enemies = enemies;
        }
        string menu = @"
  ______ _   _ ______ __  __ _____ ______  _____   _______ _    _ _____  _   _ 
 |  ____| \ | |  ____|  \/  |_   _|  ____|/ ____| |__   __| |  | |  __ \| \ | |
 | |__  |  \| | |__  | \  / | | | | |__  | (___      | |  | |  | | |__) |  \| |
 |  __| | . ` |  __| | |\/| | | | |  __|  \___ \     | |  | |  | |  _  /| . ` |
 | |____| |\  | |____| |  | |_| |_| |____ ____) |    | |  | |__| | | \ \| |\  |
 |______|_| \_|______|_|  |_|_____|______|_____/     |_|   \____/|_|  \_\_| \_|
                                                                               
                                                                               
";
        public EnemyTurnView() {
        }
       


        public void EnemyTurn() {

            Writer.ClearScreen();
            Writer.PrintLine(menu);
            Writer.PrintLine("----------Enemies healt left after your Attack---------");
            foreach (var enemy in enemies) {
                Writer.PrintLine($"{enemy.GetName()} has {enemy.GetHealth()} healt left after your Attack");

            }
            Writer.PrintLine("-------------------------------------------------------");
            Writer.PrintLine($"");

            Writer.PrintLine("-----------------Enemies are attacking-----------------");
            Writer.PrintLine($"You have {playerHandler.GetPlayer().GetHealth()} Healt left after enemies Attack");
            Writer.PrintLine("-------------------------------------------------------");
            Writer.PrintLine("");
            Writer.PrintLine("---------------Press eny key to continue---------------");

        }

        public void Draw() {
            EnemyTurn();
        }
    }
}
