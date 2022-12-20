using System.Diagnostics;

namespace PRAKTAN7
{
    internal static class Provodnik
    {
        public static void Diski()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            int[] position = new int[3] { 2, 1 + DriveInfo.GetDrives().Length, 2 };
            ConsoleKeyInfo knopka;
            DriveInfo[] alldiski = DriveInfo.GetDrives();
            for (int i = 0; i < alldiski.Length; i++)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.Write($"{"Свободное место: " + alldiski[i].AvailableFreeSpace / 1073741824 + " ГБ из " + alldiski[i].TotalSize / 1073741824,40}");
                Console.SetCursorPosition(0, i + 2);
                if (i == 0)
                {
                    Console.Write("->" + alldiski[i].Name);
                }
                else
                {
                    Console.Write($"  {alldiski[i].Name,2}");
                }
            }
            do
            {
                knopka = Console.ReadKey();
                if (knopka.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < Console.LargestWindowWidth * alldiski.Length + 2; i++)
                    {
                        Console.Write(" ");
                    }

                    FirstDirectory(alldiski, position);
                }
                else if (knopka.Key == ConsoleKey.Escape)
                {
                    break;
                }
                position = Strelochki.Strelki(knopka, position);
            } while (true);
        }

        static void FirstDirectory(DriveInfo[] allDrives, int[] pos)
        {
            ConsoleKeyInfo knopka;
            string[] vsepapki = Directory.GetFileSystemEntries(allDrives[pos[0] - 2].Name);

            for (int i = 0; i < vsepapki.Length; i++)
            {
                string file = vsepapki[i];
                Console.SetCursorPosition(0, i + 3);
                Console.Write($"{Path.GetExtension(file),77}");
                Console.SetCursorPosition(0, i + 3);
                Console.Write($"{Directory.GetCreationTime(file),54}");
                Console.SetCursorPosition(0, i + 3);

                if (i == 0)
                {
                    Console.Write("->" + file);
                }
                else
                {
                    Console.Write("  " + file);
                }
            }
            Console.SetCursorPosition(0, 0);
            pos[0] = 3; pos[1] = 2 + vsepapki.Length; pos[2] = 3;

            do
            {
                knopka = Console.ReadKey(true);

                if (knopka.Key == ConsoleKey.Enter)
                {
                    if (Directory.Exists(vsepapki[pos[0] - 3]))
                    {
                        Console.SetCursorPosition(0, 0);

                        for (int i = 0; i < Console.LargestWindowWidth * vsepapki.Length + 3; i++)
                        {
                            Console.Write(" ");
                        }
                        int perviy = 1;
                        Directories(vsepapki, pos, perviy);
                    }
                }
                else if (knopka.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < Console.LargestWindowWidth * vsepapki.Length + 3; i++)
                    {
                        Console.Write(" ");
                    }
                    Diski();
                }
                pos = Strelochki.Strelki(knopka, pos);

            } while (true);
        }

        static void Directories(string[] all, int[] pos, int first)
        {
            string[] vse2 = Directory.GetFileSystemEntries(all[pos[0] - 3]);
            ConsoleKeyInfo key;
            for (int i = 0; i < vse2.Length; i++)
            {
                string file = vse2[i];

                Console.SetCursorPosition(0, i + 3);
                Console.Write($"{Path.GetExtension(file),77}");
                Console.SetCursorPosition(0, i + 3);
                Console.Write($"{Directory.GetCreationTime(file),54}");
                Console.SetCursorPosition(0, i + 3);
                if (i == 0)
                {
                    Console.Write("->" + file);
                }
                else
                {
                    Console.Write("  " + file);
                }
            }
            Console.SetCursorPosition(0, 0);
            pos[0] = 3; pos[1] = 2 + vse2.Length; pos[2] = 3;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (vse2.Length != 0)
                    {
                        if (File.Exists(vse2[pos[0] - 3]))
                        {
                            Process.Start(new ProcessStartInfo { FileName = vse2[pos[0] - 3], UseShellExecute = true });
                            Console.SetCursorPosition(0, 5);
                        }

                        else if (Directory.Exists(vse2[pos[0] - 3]))
                        {
                            Console.SetCursorPosition(0, 0);
                            for (int i = 0; i < Console.LargestWindowWidth * vse2.Length + 3; i++)
                            {
                                Console.Write(" ");
                            }
                            first++;
                            Directories(vse2, pos, first);
                        }
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Diski();
                }
                pos = Strelochki.Strelki(key, pos);
            } while (true);
        }
    }
}