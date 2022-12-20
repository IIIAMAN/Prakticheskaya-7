namespace PRAKTAN7
{
    internal class Strelochki
    {
        public static int[] Strelki(ConsoleKeyInfo knopka, int[] position)
        {
            int stiranie = 2;
            if (knopka.Key == ConsoleKey.UpArrow)
            {
                if (position[0] <= position[2])
                {
                    position[0] = position[2];
                    stiranie = position[2];
                }
                else
                {
                    stiranie = position[0];
                    position[0]--;
                }
            }
            else if (knopka.Key == ConsoleKey.DownArrow)
            {
                if (position[0] >= position[1])
                {
                    position[0] = position[1];
                    stiranie = position[1];
                }
                else
                {
                    stiranie = position[0];
                    position[0]++;
                }
            }
            Console.SetCursorPosition(0, stiranie);
            Console.Write("  ");
            Console.SetCursorPosition(0, position[0]);
            Console.Write("->");
            return position;
        }
    }
}