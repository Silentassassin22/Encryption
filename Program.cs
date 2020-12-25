using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

namespace Encryption
{
    class Program
    {
        public static bool debug = false;
        public static char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static void Encrypt()
        {
            int shift;
            Console.Write("Please enter a shift number between 1-50: ");
            if (!int.TryParse(Console.ReadLine(), out shift))
            {
                Console.WriteLine("Please input a number between 1-50");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Main();
            }
            else if (shift < 1 || shift > 50)
            {
                Console.WriteLine("Please input a number between 1-50");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Main();
            }
            Console.Write("Please type what you would like to be encrypted: ");
            string text = Console.ReadLine();
            string newtext = String.Empty;
            int location;
            foreach (char v in text)
            {
                if (Program.letters.Contains(v))
                {
                    location = Array.IndexOf(Program.letters, v);
                    if (location + shift > 51)
                    {
                        if (Program.debug)
                        {
                            Console.WriteLine("Outside of Bounds:\nLocation: " + location + "\nShift: " + shift + "\nMath Equation: " + ((location + shift) - 51));
                        }
                        newtext = newtext + Program.letters[(location + shift) - 51];
                    }
                    else
                    {
                        if (Program.debug)
                        {
                            Console.WriteLine("Not Outside of Bounds:\nLocation: " + location + "\nShift: " + shift);
                            Console.WriteLine("Checking Array index: " + Convert.ToString(Array.IndexOf(Program.letters, v) + shift) + " Returns: " + Program.letters[Array.IndexOf(Program.letters, v) + shift]);

                        }
                        newtext = newtext + Program.letters[Array.IndexOf(Program.letters, v) + shift];
                    }
                }
                else
                {
                    newtext = newtext + v;
                }
            }
            Console.Write("Your encrypted text is: " + newtext);
        }

        private static void Decrypt()
        {
            int shift;
            Console.Write("Please enter a shift number between 1-50: ");
            if (!int.TryParse(Console.ReadLine(), out shift))
            {
                Console.WriteLine("Please input a number between 1-50");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Main();
            }
            else if (shift < 1 || shift > 50)
            {
                Console.WriteLine("Please input a number between 1-50");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Main();
            }
            Console.Write("Please type what you would like to be decrypted: ");
            string text = Console.ReadLine();
            string newtext = String.Empty;
            int location;
            foreach (char v in text)
            {
                location = Array.IndexOf(Program.letters, v);

                if (debug) { Console.WriteLine("Key: " + v + " Location: " + location); };

                if (Program.letters.Contains(v))
                {
                    Console.WriteLine("Reached! "+ Convert.ToString(51 + (location - shift)));
                    if (location - shift < 0)
                    {
                        Console.WriteLine("Reached! 2");
                        if (Program.debug)
                        {
                            Console.WriteLine("Letter: " + v + "Math: " + letters[51+(location-shift)]);
                        }
                        newtext = newtext + (letters[51+(location-shift)]);
                    }
                    else
                    {
                        newtext = newtext + (letters[location-shift]);
                    }
                    
                }
                else
                {
                    newtext = newtext + v;
                }
            }
            Console.Write("Your decrypted text is: " + newtext);
        }

        private static void Main()
        {
            Console.WriteLine("Welcome to a simple encryption program");
            Console.WriteLine("This encryption can be cracked by anyone with more than 3 brain cells so don't use it for anything illegal");
            Console.WriteLine("------------Please Select------------");
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");
            char input = Console.ReadKey(true).KeyChar;
            switch (input)
            {
                case '1':
                    Console.Clear();
                    Encrypt();
                    break;
                case '2':
                    Console.Clear();
                    Decrypt();
                    break;
                default:
                    Console.WriteLine("Please press either 1 or 2");
                    Console.Clear();
                    Main();
                    break;
            }
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            Main();

        }
    }
}
