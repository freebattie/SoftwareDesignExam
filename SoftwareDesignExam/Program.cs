
using Model.Interface;
using Persistence.Db;
using Presentation;
using System.Runtime.InteropServices;

namespace SoftwareDesignExam
{     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal partial class Program {


  

        #region Main
        static void Main(string[] args) {

            
           
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
        
    }
    #endregion
}