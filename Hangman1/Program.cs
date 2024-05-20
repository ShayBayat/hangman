using System;

class HangmanGame
{
    static void Main()
    {
        // Words that appear in the game
        string[] words = { "moon", "banana", "sniper", "sunlight", "nature" };

        // Randomly select a word
        Random random = new Random();
        string secretWord = words[random.Next(words.Length)];

        
        // start the proccess of the guessed word with underscores
        char[] guessedWord = new char[secretWord.Length];
        for (int i = 0; i < guessedWord.Length; i++)
        {
            guessedWord[i] = '_';
        }

        
        
        // Track incorrect guesses and remaining guesses
        string incorrectGuesses = "";
        int remainingGuesses = 10;
        bool wordGuessed = false;

        // Game loop
        while (remainingGuesses > 0 && !wordGuessed)
        {
            Console.Clear();
            Console.WriteLine("Hangman Game");
            Console.WriteLine("Secret word: " + new string(guessedWord));
            Console.WriteLine("Incorrect guesses: " + incorrectGuesses);
            Console.WriteLine("Remaining guesses: " + remainingGuesses);
            Console.Write("Enter a letter or guess the word: ");
            string input = Console.ReadLine().ToLower();

            
            if (input.Length == 1)
            {
                char guessedLetter = input[0];

                // Check if the letter has already been guessed
                if (incorrectGuesses.Contains(guessedLetter) || new string(guessedWord).Contains(guessedLetter))
                {
                    Console.WriteLine("You've already guessed that letter. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                // see if the guessed letter is in the secret word
                bool correctGuess = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guessedLetter)
                    {
                        guessedWord[i] = guessedLetter;
                        correctGuess = true;
                    }
                }

                
                if (!correctGuess)
                {
                    incorrectGuesses += guessedLetter + " ";
                    remainingGuesses--;
                }
            }
            else if (input.Length == secretWord.Length)
            {
                // Check if the whole word guess is correct
                if (input == secretWord)
                {
                    wordGuessed = true;
                    guessedWord = secretWord.ToCharArray();
                }
                else
                {
                    remainingGuesses--;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue...");
                Console.ReadLine();
                continue;
            }

            
            
            // Check if the whole word has been guessed
            wordGuessed = new string(guessedWord) == secretWord;
        }

        // Game over
        Console.Clear();
        if (wordGuessed)
        {
            Console.WriteLine("You guessed the word: " + secretWord);
        }
        
        else
        {
            Console.WriteLine("You lost. The word was: " + secretWord);
        }
    }
}
