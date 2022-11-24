﻿
using Model.Interface;
using Persistence.Db;
using Presentation;
using System.Runtime.InteropServices;

namespace SoftwareDesignExam
{     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal partial class Program {


        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();

        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int HIDE = 0;

        private const int MAXIMIZE = 3;

        private const int MINIMIZE = 6;

        private const int RESTORE = 9;

        static void Main(string[] args) {

            
            Setup();
            IUpdateManagar manager = new UpdateManagar();  
            IUserDao userDao = new UserDao();   
            IItemDao itemDao= new ItemDao();

            IUI ui = new UI();
            Game game = new Game(itemDao,userDao,manager, ui);
            game.Update();


        }

        private static void Setup() {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                Console.SetWindowSize(120, 60);
                TableMaker.UsersSchemaAndTableMaker();
                TableMaker.ItemsSchemaAndTableMaker();
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                ShowWindow(ThisConsole, MAXIMIZE);
            }
            TableMaker.ItemsSchemaAndTableMaker();
            TableMaker.UsersSchemaAndTableMaker();

        }
    }
}