
using System;

namespace BlackJackCardDrawSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int won = 0;
            int lost = 0;
            int res = 3;
            Console.WriteLine("\nBENVENUTO AL TAVOLO DI BLACKJACK\n");
            while (res == 3)
            {
                res = Sel(res, won, lost);
                if (res == 1) { lost++; }
                if (res == 2) { won++; }
                res = 3;
            }

        }
        static int Sel(int rres, int wwon, int llost)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nPLAY / PUNTEGGIO / FINE\n");
            Console.ForegroundColor = ConsoleColor.Red;
            var input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (input == "PLAY" || input == "play")
            {
                rres = Gioco(rres);
                input = "";
            }
            while (input == "PUNTEGGIO" || input == "punteggio")
            {
                Console.WriteLine($"\nMANI VALIDE: {wwon}\nMANI NON VALIDE: {llost}");
                input = "";
            }
            while (input == "FINE" || input == "fine")
            {
                Console.WriteLine($"\nIL PUNTEGGIO FINALE E':\n\nMANI VALIDE: {wwon}\nMANI NON VALIDE: {llost}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nGRAZIE PER AVER GIOCATO!");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            return rres;
        }
        static int Gioco(int args, int result = 0)
        {
            string f = "";
            int a = 0;
            var rd = new Random();
            int[] c = new int[4];
            for (int i = 0; i < c.Length - 1; i++)
            {
                c[i] = rd.Next(-1, 11);
            }
            Console.WriteLine("\nLE TUE CARTE SONO:\n");
            if (c[1] < 1 || c[2] < 1)
            {
                if (c[1] == 0 && c[2] == 0)
                {
                    Console.WriteLine($"{Figure(f)} | {Figure(f)}");
                    c[1] = 10;
                    c[2] = 10;
                }
                if (c[1] == 0)
                {
                    Console.WriteLine($"{string.Join(" | ", Figure(f), c[2])}");
                    c[1] = 10;
                }
                if (c[2] == 0)
                {
                    Console.WriteLine($"{string.Join(" | ", c[1], Figure(f))}");
                    c[2] = 10;
                }
                if (c[1] == -1 && c[2] == -1)
                {
                    Console.WriteLine($"ASSO | ASSO");
                    c[1] = Ace(a);
                    c[2] = Ace(a);
                }
                if (c[1] == -1)
                {
                    Console.WriteLine($"{string.Join(" | ", "ASSO", c[2])}");
                    c[1] = Ace(a);
                }
                if (c[2] == -1)
                {
                    Console.WriteLine($"{string.Join(" | ", c[1], "ASSO")}");
                    c[2] = Ace(a);
                }
            }
            else { Console.WriteLine(string.Join(" | ", c[1], c[2])); }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nHIT / STAND:\n");
            Console.ForegroundColor = ConsoleColor.Red;
            var command = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            int sum = 0;
            if (command == "HIT" || command == "hit")
            {
                c[3] = rd.Next(-1, 11);
                if (c[3] < 1)
                {
                    if (c[3] == 0)
                    {
                        Console.WriteLine($"\nE' USCITO: {Figure(f)}");
                        c[3] = 10;
                    }
                    if (c[3] == -1)
                    {
                        Console.WriteLine("\nE' USCITO ASSO");
                        c[3] = Ace(a);
                    }
                }
                else { Console.WriteLine($"\nE' USCITO: {c[3]}"); }
            }
            for (int i = 1; i < c.Length; i++)
            {
                sum += c[i];
            }
            Console.WriteLine($"\nIL VALORE TOTALE DELLE TUE CARTE E': {sum}\n");
            if (sum < 22)
            {
                result = 2;
                Console.WriteLine("LA MANO E' VALIDA");
            }
            else
            {
                result = 1;
                Console.WriteLine("LA MANO NON E' VALIDA");
            }
            return result;
        }
        static string Figure(string args)
        {
            var rd = new Random();
            int f = rd.Next(1, 4);
            string op = "";
            if (f == 1)
            {
                op = "J";
            }
            if (f == 2)
            {
                op = "Q";
            }
            if (f == 3)
            {
                op = "K";
            }
            return op;
        }
        static int Ace(int a)
        {
            Console.WriteLine("\nINSERIRE VALORE DELL'ASSO:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n1 O 11 ?\n");
            Console.ForegroundColor = ConsoleColor.Red;
            var inputace = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (inputace == "1")
            {
                return 1;
            }
            if (inputace == "11")
            {
                return 11;
            }
            else { return 1; }
        }
    }
}