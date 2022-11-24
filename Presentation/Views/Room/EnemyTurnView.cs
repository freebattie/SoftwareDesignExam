using Model.Base.Player;
using Model.Base.ViewModel;
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
       
        string menu = @"
  ______ _   _ ______ __  __ _____ ______  _____   _______ _    _ _____  _   _ 
 |  ____| \ | |  ____|  \/  |_   _|  ____|/ ____| |__   __| |  | |  __ \| \ | |
 | |__  |  \| | |__  | \  / | | | | |__  | (___      | |  | |  | | |__) |  \| |
 |  __| | . ` |  __| | |\/| | | | |  __|  \___ \     | |  | |  | |  _  /| . ` |
 | |____| |\  | |____| |  | |_| |_| |____ ____) |    | |  | |__| | | \ \| |\  |
 |______|_| \_|______|_|  |_|_____|______|_____/     |_|   \____/|_|  \_\_| \_|
                                                                               
                                                                               
";
        private ViewModel _vm;

        public void EnemyTurn()
        {
            PrintMenuName();
            PlayerAttackingEnemiesInfo();
            var health = _vm.Playerhandler.GetPlayer();
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
            Writer.PrintLine($"Your damage: {_vm.Playerhandler.GetPlayer().GetDamageDone()}");
            Writer.PrintLine("----------Enemies healt left after your Attack---------");
            foreach (var enemy in _vm.Enemies)
            {

                Writer.PrintLine($"{enemy.GetName()} has {enemy.GetHealth()} healt left");

            }
            Writer.PrintLine("-------------------------------------------------------");
            Writer.PrintLine($"");
        }

        private void EnemiesAttackingPlayerInfo(double health)
        {
            Writer.PrintLine("-----------------Enemies are attacking-----------------");
            foreach (var enemy in _vm.Enemies) {
                Writer.PrintLine($"enemy {enemy.Name} did damage: {enemy.GetDamageDone()}");
            }
           
            Writer.PrintLine($"You have {health} Healt left after enemies Attack");
            Writer.PrintLine("-------------------------------------------------------");
            Writer.PrintLine("");
            Writer.PrintLine("---------------Press eny key to continue---------------");
        }

        public void Draw()
        {
            EnemyTurn();
        }

        public void AddViewModel(ViewModel vm) {
            _vm = vm;
        }
    }
}
