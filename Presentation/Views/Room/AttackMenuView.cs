using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Interface;
using Presentation.Utils;
using System;

namespace Presentation.Views.rooms
{
    public class AttackMenuView : IView
    {
        private PlayerHandler playerHandler;
        private List<CharacterInfo> enemies;
        private readonly int room;
        private string attackHeader = @"
        _______ _______       _____ _  __
     /\|__   __|__   __|/\   / ____| |/ /
    /  \  | |     | |  /  \ | |    | ' / 
   / /\ \ | |     | | / /\ \| |    |  <  
  / ____ \| |     | |/ ____ \ |____| . \ 
 /_/    \_\_|     |_/_/    \_\_____|_|\_\

";

        public AttackMenuView(PlayerHandler playerHandler, List<CharacterInfo> enemies, int room)
        {
            this.playerHandler = playerHandler;
            this.enemies = enemies;
            this.room = room;
        }


        public void Draw()
        {
            AttackMenu();

        }

        public void AttackMenu()
        {
            var player = playerHandler.GetPlayer();
            if (player != null)
                PrintMenu(player);

            AddSpacing();
            PrintEnemiesInfo();
            PrintInputInfo();
        }
        private void PrintMenu(CharacterInfo player)
        {
            Writer.ClearScreen();
            Writer.PrintLine(attackHeader);
            Writer.PrintLine($"You are in room {room}");
            Writer.PrintLine($"Hi, {player.GetName()}.");
            Writer.PrintLine("");
            Writer.PrintLine($"Your health: {player.GetHealth()}");
            Writer.PrintLine($"Your current level: {player.GetLevel()}");
            Writer.PrintLine($"Your Weapon: {player.GetWeapon().Name}");
            Writer.PrintLine($"Your BaseDamge is: {player.GetLevel() + 25}");
            Writer.PrintLine($"Your Crit Chance is: {player.GetCrit()}");
            Writer.PrintLine($"Max damage if crit: {player.GetMaxDamage()}");
            Writer.PrintLine($"Your Items: {player.GetDescription()}");
        }

        private static void AddSpacing()
        {
            Writer.PrintLine("");
            Writer.PrintLine("");
        }



        private void PrintEnemiesInfo()
        {
            Writer.PrintLine("----------Enemies Information-------");
            Writer.PrintLine($"Number of enemies are: {enemies.Count}");
            int index = 1;
            foreach (CharacterInfo enemy in enemies)
            {
                Writer.Print($"#############");
                Writer.Print($"Enemy: {index}", ConsoleColor.Red);
                Writer.Print($"################");
                Writer.PrintLine("");
                Writer.PrintLine($"# Name: {enemy.GetName()}");
                Writer.PrintLine($"# level: {enemy.GetLevel()}");
                Writer.PrintLine($"# Health: {enemy.GetHealth()}");
                Writer.PrintLine($"# Items: {enemy.GetDescription()}");
                Writer.PrintLine($"# Weapon: {enemy.GetWeapon().Name}");
                Writer.PrintLine("######################################");

                index++;

            }


        }
        private void PrintInputInfo()
        {
            Writer.PrintLine("");
            Writer.PrintLine("----------Attack Menu-------");
            Writer.PrintLine($"Select a Enemy to attack. or 0 for inventory");
            Writer.Print("Input:");
        }



    }
}
