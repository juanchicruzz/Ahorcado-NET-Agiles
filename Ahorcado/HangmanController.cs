using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class HangmanController
    {
        private Hangman Hangman { get; set; }
        private User SessionUser { get; set; }

        public User Login(string username)
        {
            SessionUser = new User(username);
            return SessionUser;
        }

        public Hangman StartGame(string word)
        {
            Hangman = new Hangman(word);
            int position = 0;
            foreach (char letter in Hangman.WordToGuess.ToCharArray())
            {
                position++;
                Hangman.Letters.Add(new HangmanLetter(position, letter, false));
            }
            return Hangman;
        }

        public Hangman EnterLetter(char letter)
        {
            if (ValidateLetter(letter))
            {
                IEnumerable<HangmanLetter> foundLetters = Hangman.Letters.Where(x => x.Letter == letter);
                foreach (HangmanLetter item in foundLetters)
                {
                    item.Display = true;
                }
                Hangman.GuessedTheLetter = true;
                return Hangman;
            }
            if (!Hangman.BadLetters.Contains(letter))
            {
                Hangman.BadLetters.Add(letter);
                Hangman.Lifes -= 1;
            }
            Hangman.GuessedTheLetter = false;
            return Hangman;
        }

        public Hangman EnterWord(string word)
        {
            if (Hangman.WordToGuess == word.ToUpper())
            {
                foreach (HangmanLetter item in Hangman.Letters)
                {
                    item.Display = true;
                }
                Hangman.GuessedWholeWord = true;
            } else
            {
                Hangman.GuessedWholeWord = false;
                Hangman.Lifes -= 2;
            }
            return Hangman;
        }

        public int GetPoints()
        {
            if (Hangman.Lifes <= 0)
            {
                return 0;
            }
            else
            {
                int extraPoints = 0;
                if (Hangman.GuessedWholeWord)
                {
                    extraPoints = Constant.POINTS_PER_WORD;
                }
                return Constant.POINTS_FOR_WINNING - (Hangman.BadLetters.Count * Constant.POINTS_LESS_BY_MISTAKE) + extraPoints;
            }
        }

        private bool ValidateLetter(char letter)
        {
            if (!Char.IsLetter(letter))
            {
                throw new ArgumentException("El caracter ingresado no es una letra.");
            }
            return Hangman.WordToGuess.Contains(Char.ToUpper(letter));
        }
    }
}
