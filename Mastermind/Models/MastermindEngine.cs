using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    internal class MastermindEngine
    {
        private const int ATTEMPTS = 10;

        private const int SOLUTION_SIZE = 4;

        public enum EngineMode { Home, Play, Info, Quit }

        public EngineMode Mode { get; set; }


        public MastermindEngine() 
        {
            Mode = EngineMode.Home;
            Console.WriteLine("Welcome to Mastermind!");
        }

        public void Run()
        {
            while(true)
            {
                while(Mode == EngineMode.Home)
                {
                    DisplayOptions();

                    try
                    {
                        var input = Console.ReadKey();

                        Mode = input.Key switch
                        {
                            ConsoleKey.P => EngineMode.Play,
                            ConsoleKey.I => EngineMode.Info,
                            ConsoleKey.Q => EngineMode.Quit,
                            _ => throw new Exception("Invalid option selected!")
                        };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                switch (Mode)
                {
                    case EngineMode.Play:
                        {
                            var game = new Game(ATTEMPTS, SOLUTION_SIZE);
                            Mode = EngineMode.Home;
                            break;
                        }
                    case EngineMode.Info:
                        {
                            DisplayInfo();
                            Mode = EngineMode.Home;
                            break;
                        }
                    case EngineMode.Quit:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }

        public void DisplayOptions()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("Play (p)");
            Console.WriteLine("Info (i)");
            Console.WriteLine("Quit (q)");
        }

        public void DisplayInfo()
        {
            Console.Clear();
            Console.WriteLine("\nGame Play:");
            Console.WriteLine($"\nMastermind will generate a {SOLUTION_SIZE} digit code using the numbers 1 through 6");
            Console.WriteLine($"Submit your guess by inputting {SOLUTION_SIZE} digits and press the Enter key");
            Console.WriteLine("Each number guessed in the correct position will be represented by a '+'");
            Console.WriteLine("A number that exists in the solution, but in the incorrect position, will be represented by a '-'");
            Console.WriteLine("An incorrect number will be left blank in the result");
            Console.WriteLine($"\nYou have {ATTEMPTS} attempts to solve the puzzle. Good luck!");
        }
    }
}
