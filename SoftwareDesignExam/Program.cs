
using Model.Interface;
using Persistence.Db;
using Presentation;
using System.Runtime.InteropServices;

namespace SoftwareDesignExam
{     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal partial class Program {


        #region Windows fileds
        /// <summary>
        /// brukt får å starte applikasjonen i full skjerm på windows
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        #endregion

        #region Main
        static void Main(string[] args) {

            
            Setup();
            IUpdateManagar manager = new UpdateManagar();  
            IUserDao userDao = new UserDao();   
            IItemDao itemDao= new ItemDao();

            IUI ui = new UI();
            Game game = new Game(itemDao,userDao,manager, ui);
            game.Update();


        }
        #endregion

        #region private static method
        /// <summary>
        /// setter opp slik at console appen starter i full skjerm
        /// </summary>
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
    #endregion
}