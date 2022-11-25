
using Model.Interface;
using Persistence.Db;
using Presentation;
using System.Runtime.InteropServices;

namespace SoftwareDesignExam
{     

    internal partial class Program {


  

        #region Main
        static void Main(string[] args) {

            
           
            IUpdateManagar manager = new UpdateManagar();  
            IUserDao userDao = new UserDao();   
            IItemDao itemDao= new ItemDao();

            IUI ui = new UI();
            GameController gameController = new GameController(itemDao,userDao,manager, ui);
            gameController.Update();


        }
        #endregion

       
        
    }
    
}