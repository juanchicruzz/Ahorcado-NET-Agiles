using Hangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman.Services
{
    public class HangmanService
    {
        public HangmanModel SetPlayers(string player1, string player2)
        {
            return new HangmanModel(player1, player2);
        }

        public HangmanModel StartGame(HangmanModel hangman)
        {
            hangman.GameOwnerIsPlayer1 = !hangman.GameOwnerIsPlayer1;
            hangman.Letters = new List<HangmanLetter>();
            hangman.BadLetters = new List<char>();
            hangman.Lifes = Constant.LIFES;
            hangman.Playing = true;
            hangman.Won = false;
            hangman.Lost = false;
            hangman.GuessedWholeWord = false;
            if (hangman.GameOwnerIsPlayer1)
            {
                hangman.Player2Played++;
            }
            else
            {
                hangman.Player1Played++;
            }
            return hangman;
        }

        public HangmanModel SetWordToGuess(string wordToGuess, HangmanModel hangman)
        {
            hangman.WordToGuess = wordToGuess.ToUpper();
            foreach (char letter in hangman.WordToGuess.ToCharArray())
            {
                hangman.Letters.Add(new HangmanLetter(letter, false));
            }
            return hangman;
        }
        
        public HangmanModel Try(string tried, HangmanModel hangman)
        {
            tried = tried.ToUpper();
            if (tried.Length > 1)
            {
                hangman = EnterWord(tried, hangman);
            }
            else
            {
                char letter = Char.Parse(tried);
                if (ValidateLetter(letter, hangman))
                {
                    IEnumerable<HangmanLetter> foundLetters = hangman.Letters.Where(x => x.Letter == letter);
                    foreach (HangmanLetter item in foundLetters)
                    {
                        item.Display = true;
                    }
                    if (!hangman.Letters.Where(x => !x.Display).Any())
                    {
                        hangman.Playing = false;
                        hangman.Won = true;
                        if (hangman.GameOwnerIsPlayer1)
                        {
                            hangman.PointsPlayer2 += GetPoints(hangman);
                        }
                        else
                        {
                            hangman.PointsPlayer1 += GetPoints(hangman);
                        }
                    }
                }
                else
                {
                    if (!hangman.BadLetters.Contains(letter))
                    {
                        hangman.BadLetters.Add(letter);
                        hangman.Lifes--;
                    }
                }
            }
            if (hangman.Lifes <= 0)
            {
                hangman.Playing = false;
                hangman.Lost = true;
            }
            return hangman;
        }


        private HangmanModel EnterWord(string word, HangmanModel hangman)
        {
            if (word == hangman.WordToGuess)
            {
                foreach (HangmanLetter item in hangman.Letters)
                {
                    item.Display = true;
                }
                hangman.GuessedWholeWord = true;
                hangman.Playing = false;
                hangman.Won = true;
                if (hangman.GameOwnerIsPlayer1)
                {
                    hangman.PointsPlayer2 += GetPoints(hangman);
                }
                else
                {
                    hangman.PointsPlayer1 += GetPoints(hangman);
                }
            }
            else
            {
                hangman.GuessedWholeWord = false;
                hangman.Lifes -= 2;
            }
            return hangman;
        }

        private int GetPoints(HangmanModel hangman)
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

        private bool ValidateLetter(char letter, HangmanModel hangman)
        {
            if (!Char.IsLetter(letter))
            {
                throw new ArgumentException("El caracter ingresado no es una letra.");
            }
            return hangman.WordToGuess.Contains(Char.ToUpper(letter));
        }

    }
}
