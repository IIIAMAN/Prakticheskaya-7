
using System.Diagnostics;

namespace PractosNumber7
{
    static class Nachalo
    {
        public static string path;
        static string otkritiefile;
        private static void Papochka(ConsoleKey key, int position, int max, int min, string path)
        {
            Console.Clear();
            position = 1;
            var directory = new DirectoryInfo(path);
            var file = new FileInfo(path);
            if (directory.Exists)
            {
                FileSystemInfo[] dirs = directory.GetFileSystemInfos();
                for (int l = 0; l < dirs.Length; l++)
                {
                    Console.SetCursorPosition(50, l + 1);
                    Console.WriteLine($"{dirs[l].Extension}");
                    Console.SetCursorPosition(1,l + 1);
                    Console.WriteLine($"  {dirs[l].Name}");
                    Console.SetCursorPosition(90, l + 1);
                    Console.WriteLine($"{dirs[l].CreationTime}");
                    Console.SetCursorPosition(90, l + 1);

                }
                int count = dirs.Length;
                max = count;
                min = count - count + 1;
                bool check = true;
                Console.WriteLine();
                do
                {
                    Strelki.kursoer(position);
                    key = Console.ReadKey().Key;
                    position = Strelki.positionse(position, max, min, key);
                    if (key == ConsoleKey.Enter)
                    {
                        path = Convert.ToString(dirs[position - 1]);
                        otkritiefile = path;
                        otkritiefile.TrimEnd('\\');
                        path = ($"{path}\\");
                        position = 1;
                        Papochka(key, max, min, position, path);

                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        position = 1;
                        min = 1;
                        max = 2;
                        Pervoe(key, position, max, min, path);
                        check = false;
                    }
                } while (check);
            }
            else if (file.Exists)
            {
                Otkritie(otkritiefile, key, position, max, min, path);
            }
        }
        public static void Pervoe(ConsoleKey key, int position, int max, int min, string path)
        {
            List<DriveInfo> Diski = DriveInfo.GetDrives().ToList();
            DriveInfo joloben = Diski.First(wow => wow.Name == "D:\\");
            Console.WriteLine("  Выберите диск:");
            Console.Clear();
            Console.WriteLine("  Выберите диск:");
            foreach (DriveInfo DISK in Diski)
            {
                if (DISK.IsReady == true)
                {
                    Console.WriteLine($"  Диск: {DISK.Name}" + "Свободное пространство - " + DISK.AvailableFreeSpace / 1024 / 1024 / 1024 + " ГБ");
                }
            }
            do
            {
                Strelki.kursoer(position);
                key = Console.ReadKey().Key;
                position = Strelki.positionse(position, max, min, key);
                if (key == ConsoleKey.Enter)
                {
                    path = Convert.ToString(Diski[position - 1]);
                    string NAME = ($"{path}\\");
                    Console.Clear();
                    var PAPKA = new DirectoryInfo(NAME);
                    if (PAPKA.Exists)
                    {
                        FileSystemInfo[] masiv = PAPKA.GetFileSystemInfos();
                        for (int i = 0; i < masiv.Length; i++)
                        {

                            Console.SetCursorPosition(60, i + 1);
                            Console.WriteLine($"{masiv[i].Extension}");
                            Console.SetCursorPosition(1, i + 1);
                            Console.WriteLine($"  {masiv[i].Name}");
                            Console.SetCursorPosition(30, i + 1);
                            Console.WriteLine($"{masiv[i].CreationTime}");
                            Console.SetCursorPosition(30, i + 1);
                        }
                        int dlina = masiv.Length;
                        max = dlina;
                        bool proverka = true;
                        do
                        {
                            Strelki.kursoer(position);
                            key = Console.ReadKey().Key;
                            position = Strelki.positionse(position, max, min, key);
                            if (key == ConsoleKey.Enter)
                            {
                                path = Convert.ToString(masiv[position - 1]);
                                otkritiefile = path;
                                otkritiefile.TrimEnd('\\');
                                path = ($"{path}\\");
                                position = 1;
                                Papochka(key, max, min, position, path);
                            }
                            else if (key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                position = 2;
                                min = 1;
                                max = 2;
                                Pervoe(key, position, max, min, path);
                                proverka = false;
                            }
                        } while (proverka);
                    }
                    else
                    {
                        Otkritie(otkritiefile, key, position, max, min, path);
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            } while (true);
        }
        static private void Otkritie(string otkrivaeem, ConsoleKey key, int position, int max, int min, string path)
        {
            Process.Start(new ProcessStartInfo($"{otkrivaeem}") { UseShellExecute = true });
            Console.Clear();
            position = 1;
            min = 1;
            max = 2;
            Pervoe(key, position, max, min, path);
        }
    }
}
