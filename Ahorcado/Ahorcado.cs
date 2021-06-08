using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class Ahorcado
    {
        private string _word2guess;

        public Ahorcado(string word)
        {
            this._word2guess = word;
            this.StartGame();
        }

        public string printword { get; set; }

        private void StartGame()
        {
            for(int i = 0; i < this._word2guess.Length; i++)
            {
                this.printword += " _";
            }
            this.printword = this.printword.Trim();
        }


        public bool ValidateLetter(char letter)
        {
            if (!Char.IsLetter(letter))
            {
                throw new ArgumentException("El caracter ingresado no es una letra.");
            }
            return _word2guess.Contains(Char.ToUpper(letter));

        }

        public void EnterLetter(char letter)
        {
            if (ValidateLetter(letter))
            {

            }
        }
    }
}

