
namespace SoftwareDesignExam
{     // kanskje ha med runder med forjskjellige funkjsoner osv, evt. en abstrakt Level/Round også flere leveler osv

    internal partial class Program {




        static void Main(string[] args) {
            //TableMaker.UsersSchemaAndTableMaker();


            Game game = new();
            game.Update();


        }
    }
}