using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PractosNumber7
{
    internal class Strelki
    {
        public static int position = 1;
        public static int max = 0;
        public static int min = 0;
        public static ConsoleKey key;
        Strelki(int Min, int Max)
        {
            int min = Min;
            int max = Max;
        }
        public static int positionse(int position, int max, int min, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    position--;
                    if (position < min)
                    {
                        position = min;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    position++;
                    if (position > max)
                    {
                        position = max;
                    };
                    break;
            }
            return position;
        }
        public static void kursoer(int position)
        {
            Console.SetCursorPosition(0, position - 1);
            Console.WriteLine("  ");
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            Console.SetCursorPosition(0, position + 1);
            Console.WriteLine("  ");
        }
    }
}