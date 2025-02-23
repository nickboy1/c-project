using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.classes
{
    public class GuessRandomGame
    {
        public static void Start()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 100);
            int guessCount = 0;
            int maxGuesses = 5;

            Console.WriteLine("choose a random number between 1 and 100.");

            while (guessCount < maxGuesses)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                guessCount++;

                if (guess == secretNumber)
                {
                    Console.WriteLine($"You guessed the number in {guessCount} tries.");
                    break;
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("too low try again.");
                }
                else
                {
                    Console.WriteLine("too high try again.");
                }
            }

            if (guessCount == maxGuesses)
            {
                Console.WriteLine($"you have run out of guesses. The secret number was {secretNumber}.");
            }
        }


        static void Main(string[] args)
        {

            Start();
        }
    }
}
