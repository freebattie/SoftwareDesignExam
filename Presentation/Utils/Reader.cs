using Model.Interface;


namespace Presentation.Utils {
    public class Reader  {

        /// <summary>
        /// validates that the input is a number between 1 and length of the list max 9
        /// we use generics method here since list can be Characters, Items, IWeapons etc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ReadIntAsString<T>(List<T> list) { 

            string input = Console.ReadLine();
            
            if (Char.IsDigit(input.ToCharArray()[0]) && input.Length == 1 
                && int.Parse(input.ToCharArray()[0].ToString()) <= list.Count 
                && int.Parse(input.ToCharArray()[0].ToString()) != 0)
                return input;
            else
                return "ERROR";
        }
        public static string ReadIntAsString() {

            string input = Console.ReadLine();
            if (input.Length == 0)
                return "ERROR";
           else if (Char.IsDigit(input.ToCharArray()[0]) && input.Length == 1 )
                return input;
            else
                return "ERROR";
        }
        public static string ReadString() {

            string input = Console.ReadLine();
            if (input.Length == 0)
                return "ERROR";
            return input;
        }
        public static string KeyPressed() {
            return Console.ReadKey().ToString();
        }

    }
}
