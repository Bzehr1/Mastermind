using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    internal class Game
    {
        private int _attempts { get; set; } = 0;
        private int _solutionSize { get; set; } = 0;
        private string _solution { get; set; } = string.Empty;
        private List<Guess> _guesses { get; set; } = new List<Guess>();


        public Game(int attempts, int solutionSize)
        {
            _attempts = attempts;
            _solutionSize = solutionSize;
            _solution = GenerateSoltuion();
            Run();
        }

        private string GenerateSoltuion()
        {
            int[] result = new int[_solutionSize];
            var rand = new Random();

            for (int i = 0; i < _solutionSize; i++)
            {
                result[i] = rand.Next(1, 6);
            }

            return string.Join("", result);
        }

        private string ParseGuess(string guess)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < _solution.Length; i++)
            {
                if (_solution[i] == guess[i])
                {
                    results.Add("+");
                }
                else if (_solution.Contains(guess[i]))
                {
                    results.Add("-");
                }
            }
            return string.Join("", results.OrderDescending());
        }

        private string GetNextGuess()
        {
            Console.WriteLine("\nEnter next guess");
            return Console.ReadLine() ?? string.Empty;
        }

        private string ValidateGuess(string guess)
        {
            if (string.IsNullOrWhiteSpace(guess))
                return "You entered an empty string, that'll cost you one attempt!";

            if (_solution.Length != guess.Length)
                return $"{guess} is not a valid length, that'll cost you one attempt!";

            if (!int.TryParse(guess, out int i))
                return $"{guess} is not a valid guess, that'll cost you one attempt!";

            return string.Empty;
        }

        private void PrintGuesses()
        {
            Console.Clear();
            foreach (var guess in _guesses)
            {
                Console.WriteLine($"Guess #{guess.Id}: {guess.Value} => {guess.Result} {guess.Error}");
            }
        }

        private void Run()
        {
            Console.Clear();
            bool gameOver = false;

            while (!gameOver)
            {
                for (int i = 0; i < _attempts; i++)
                {
                    PrintGuesses();

                    string guess = GetNextGuess();
                    string error = ValidateGuess(guess);
                    string result = ParseGuess(guess);

                    _guesses.Add(new Guess(i + 1, guess, result, error));

                    if (_solution == guess)
                    {
                        Console.WriteLine($"Congrats!! You've guessed correctly in {_guesses.Count} guesses!");
                        gameOver = true;
                        break;
                    }

                }

                if (!gameOver)
                {
                    Console.WriteLine($"Game over! The solution was: {_solution}");
                    gameOver = true;
                }
            }
        }
    }
}
