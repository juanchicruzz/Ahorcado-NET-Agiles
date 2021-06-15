using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class HangmanController
    {
        private Hangman hangman { get; set; }
        private User sessionUser { get; set; }

        public User Login(string username)
        {
            sessionUser = new User(username);
            return sessionUser;
        }

        public Hangman StartGame(string word)
        {
            hangman = new Hangman(word);
            int position = 0;
            foreach (char letter in hangman.WordToGuess.ToCharArray())
            {
                position++;
                hangman.Letters.Add(new HangmanLetter(position, letter, false));
            }
            return hangman;
        }

        public Hangman EnterLetter(char letter)
        {
            if (ValidateLetter(letter))
            {
                IEnumerable<HangmanLetter> foundLetters = hangman.Letters.Where(x => x.Letter == letter);
                foreach (HangmanLetter item in foundLetters)
                {
                    item.Display = true;
                }
                hangman.GuessedTheLetter = true;
                return hangman;
            }
            if (!hangman.BadLetters.Contains(letter))
            {
                hangman.BadLetters.Add(letter);
                hangman.Lifes -= 1;
            }
            hangman.GuessedTheLetter = false;
            return hangman;
        }

        public Hangman EnterWord(string word)
        {
            if (hangman.WordToGuess == word.ToUpper())
            {
                foreach (HangmanLetter item in hangman.Letters)
                {
                    item.Display = true;
                }
                hangman.GuessedWholeWord = true;
            } else
            {
                hangman.GuessedWholeWord = false;
                hangman.Lifes -= 2;
            }
            return hangman;
        }

        public int GetPoints()
        {
            if (hangman.Lifes <= 0)
            {
                return 0;
            }
            else
            {
                int extraPoints = 0;
                if (hangman.GuessedWholeWord)
                {
                    extraPoints = Constant.POINTS_PER_WORD;
                }
                return Constant.POINTS_FOR_WINNING - (hangman.BadLetters.Count * Constant.POINTS_LESS_BY_MISTAKE) + extraPoints;
            }
        }

        private bool ValidateLetter(char letter)
        {
            if (!Char.IsLetter(letter))
            {
                throw new ArgumentException("El caracter ingresado no es una letra.");
            }
            return hangman.WordToGuess.Contains(Char.ToUpper(letter));
        }
    }
}
