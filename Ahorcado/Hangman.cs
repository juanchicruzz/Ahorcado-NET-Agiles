using System.Collections.Generic;

namespace Ahorcado
{
    public class Hangman
    {
        public Hangman(string word)
        {
            this.WordToGuess = word;
            this.Letters = new List<HangmanLetter>();
            this.BadLetters = new List<char>();
            this.Lifes = Constant.LIFES;
        }
        public string WordToGuess { get; set; }
        public List<HangmanLetter> Letters { get; set; }
        public List<char> BadLetters { get; set; }
        public int Lifes { get; set; }
        public bool GuessedTheLetter { get; set; }
        public bool GuessedWholeWord { get; set; }

        public string PrintWord()
        {
            string op = "";
            foreach (HangmanLetter letter in Letters)
            {
                if (letter.Display)
                {
                    op += " " + letter.Letter;
                }
                else
                {
                    op += " _";
                }
            }
            return op.Trim();
        }
    }

    public class HangmanLetter
    {
        public HangmanLetter(int position, char letter, bool display)
        {
            Position = position;
            Letter = letter;
            Display = display;
        }
        public int Position { get; set; }
        public char Letter { get; set; }
        public bool Display { get; set; }
    }
}

