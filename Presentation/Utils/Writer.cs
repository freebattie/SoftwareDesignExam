
namespace Presentation.Utils {
    public static class Writer {
        private static ConsoleColor backgroundColor = ConsoleColor.Black;
        private static ConsoleColor foregroundColor = ConsoleColor.White;


        static Writer() {
            ResetColors();
        }
        public static void ClearScreen() {
            Console.Clear();
        }
        private static void ResetColors() {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }

        /// <summary>
        /// hvis vi bestemmer oss for å skifte hele programmet fra kvit tekst og svart bakgrunn så kan vi gjør det her
        /// </summary>
        /// <param name="textColor"></param>
        /// <param name="backGroundColor"></param>
        public static void SetDefaultColors(ConsoleColor textColor, ConsoleColor backGroundColor) {
            foregroundColor = textColor;
            backgroundColor = backGroundColor;
            ResetColors();
        }
        public static void PrintLine(string line) {
            Console.WriteLine(line);
        }
        public static void PrintLine(string line,int x,int y) {
            
            Console.SetCursorPosition(x, y);
            Console.WriteLine(line);
            Console.SetCursorPosition(x, y+1);
        }
        public static void PrintLine(string line, ConsoleColor forground, ConsoleColor background = ConsoleColor.Black) {
            Console.ForegroundColor = forground;
            Console.BackgroundColor = background;
            Console.WriteLine(line);
            ResetColors();

        }
        public static void PrintLine(string line,int x,int y, ConsoleColor forground, ConsoleColor background = ConsoleColor.Black) {
            Console.ForegroundColor = forground;
            Console.BackgroundColor = background;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(line);
            Console.SetCursorPosition(x, y + 1);
            ResetColors();

        }

        public static void Print(string line) {
            Console.Write(line);
        }
        public static void Print(string line, int x ,int y) {
            Console.SetCursorPosition(x, y);
            Console.Write(line);
            Console.SetCursorPosition(x, y + 1);
        }

        public static void Print(string line, ConsoleColor forground, ConsoleColor background = ConsoleColor.Black) {
            Console.ForegroundColor = forground;
            Console.BackgroundColor = background;
            Console.Write(line);
            ResetColors();

        }
    }
}
