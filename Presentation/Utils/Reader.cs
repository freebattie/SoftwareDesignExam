using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Utils {
    public static class Reader {

        public static string ReadInt() { 

            string input = Console.ReadLine();
            if (Char.IsDigit(input.ToCharArray()[0]) && input.Length == 1)
                return input;
            else
                return "";
        }
        public static string ReadString() {

            string input = Console.ReadLine();
            return input;
        }

    }
}
