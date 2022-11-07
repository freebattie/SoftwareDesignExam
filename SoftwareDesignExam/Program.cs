
using Persistence.Db;
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

            Game game = new();
            game.Update();


        }

        private static void Setup() {
            Console.SetWindowSize(120, 60);
            TableMaker.UsersSchemaAndTableMaker();
            TableMaker.ItemsSchemaAndTableMaker();
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
}