using System;
using System.Collections.Generic;
using System.Linq;


    public class ConsoleDesign
    {
        // نمایش منو همراه با متدهای مرتبط
        public static void ShowMenu(string title, Dictionary<string, Action> menuOptions, ConsoleColor color = ConsoleColor.Green)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = color;
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine($"       {title,-28} ");
                Console.WriteLine("╠════════════════════════════════╣");

                int index = 1;
                foreach (var option in menuOptions.Keys)
                {
                    Console.WriteLine($" {index}. {option,-28} ");
                    index++;
                }

                Console.WriteLine(" 0. Exit                        ");
                Console.WriteLine("╚════════════════════════════════╝");
                Console.ResetColor();

                // دریافت ورودی از کاربر
                int choice = (int)GetValidatedInput("Select an option:", true);

                if (choice == 0) break; // خروج از منو

                if (choice > 0 && choice <= menuOptions.Count)
                {
                    // اصلاح شده: دریافت متد مربوطه با `ElementAt()`
                    var selectedMethod = menuOptions.ElementAt(choice - 1).Value;
                    selectedMethod?.Invoke();

                    Console.ReadKey();
            }
                else
                {
                    ShowMessage("Invalid selection! Please try again.", ConsoleColor.Red);
                }
            }
        }

        // نمایش پیام سفارشی
        public static void ShowMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($" {message,-70} ");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        // دریافت ورودی معتبر
        public static object GetValidatedInput(string message, bool isNumeric = true)
        {
            Console.Write($"║ {message} ");

            if (isNumeric)
            {
                int number;
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("║ Invalid input! Please enter a valid number. ║");
                    Console.Write("║ Try again: ");
                }
                return number;
            }
            else
            {
                string input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("║ Input cannot be empty! Try again.           ║");
                    Console.Write("║ ");
                    input = Console.ReadLine();
                }
                return input;
            }
        }
    }

