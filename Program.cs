namespace PractosNumber7
{
    internal class Program
    {
        static int position = Strelki.position, max = Strelki.max, min = Strelki.min;
        static ConsoleKey key = Strelki.key;
        static string path = Nachalo.path;
        static void Main()
        {
            gonim(position, max, min, key, path);
        }
        static void gonim(int position, int max, int min, ConsoleKey key, string path)
        {
            min = 1; max = 2;
            position = 1;
            Nachalo.Pervoe(key, position, max, min, path);
        }
    }
}