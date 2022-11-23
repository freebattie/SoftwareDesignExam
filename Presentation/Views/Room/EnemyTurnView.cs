using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views.rooms
{
    internal class EnemyTurnView : IView
    {
        private readonly PlayerHandler playerHandler;
        private readonly List<CharacterInfo> enemies;

        public EnemyTurnView(PlayerHandler playerHandler, List<CharacterInfo> enemies)
        {
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

        public EnemyTurnView()
        {
            playerHandler = new();
            enemies = new();
        }



        public void EnemyTurn()
        {
            PrintMenuName();
            PlayerAttackingEnemiesInfo();
            var health = playerHandler.GetPlayer();
            if (health != null)
                EnemiesAttackingPlayerInfo(health.GetHealth());



        }

        private void PrintMenuName()
        {
            Writer.ClearScreen();
            Writer.PrintLine(menu);
        }

        private void PlayerAttackingEnemiesInfo()
        {

            int index = 0;

            Writer.PrintLine("----------Enemies healt left after your Attack---------");
            foreach (var enemy in enemies)
            {

                Writer.PrintLine($"{enemy.GetName()} has {enemy.GetHealth()} healt left after your Attack");

            }
            Writer.PrintLine("-------------------------------------------------------");
            Writer.PrintLine($"");
        }

        private void EnemiesAttackingPlayerInfo(double health)
        {
            Writer.PrintLine("-----------------Enemies are attacking-----------------");
            Writer.PrintLine($"You have {health} Healt left after enemies Attack");
            Writer.PrintLine("-------------------------------------------------------");
            Writer.PrintLine("");
            Writer.PrintLine("---------------Press eny key to continue---------------");
        }

        public void Draw()
        {
            EnemyTurn();
        }
    }
}
