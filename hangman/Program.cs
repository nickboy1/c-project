using System;
using System.Collections.Generic;

namespace HangManGame
{
    class Hangman
    {
        public static void Start()
        {
        
            string[] wordList = { "computer", "programming", "hangman", "challenge", "car" };
            Random random = new Random();
            string wordToGuess = wordList[random.Next(wordList.Length)].ToUpper();

        
            char[] guessedWord = new string('*', wordToGuess.Length).ToCharArray();
            List<char> incorrectGuesses = new List<char>();
            int maxAttempts = 5;
            bool isGameWon = false;

            Console.WriteLine("Welcome to hangman, guess the word by typing one letter at a time.");

            while (incorrectGuesses.Count < maxAttempts && !isGameWon)
            {
                Console.WriteLine("\nWord: " + new string(guessedWord));
                Console.WriteLine($"Attempts left: {maxAttempts - incorrectGuesses.Count}");

                Console.Write("Enter your guess: ");
                string input = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
                {
                    Console.WriteLine("Please enter a single letter.");
                    continue;
                }

                char guessedLetter = input[0];

                if (guessedWord.Contains(guessedLetter) || incorrectGuesses.Contains(guessedLetter))
                {
                    Console.WriteLine("You have  already guessed that letter. Try again.");
                    continue;
                }

                if (wordToGuess.Contains(guessedLetter))
                {
                    Console.WriteLine("Good guess!");

                   
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guessedLetter)
                        {
                            guessedWord[i] = guessedLetter;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect guess.");
                    incorrectGuesses.Add(guessedLetter);
                }

             
                if (new string(guessedWord) == wordToGuess)
                {
                    isGameWon = true;
                }
            }

      
            if (isGameWon)
            {
                Console.WriteLine("\nCongratulations! You guessed the word: " + wordToGuess);
            }
            else
            {
                Console.WriteLine("\nGame over! The word was: " + wordToGuess);
            }
        }

      
        static void Main(string[] args)
        {
          
            Start();
        }
    }
}
