using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class Ahorcado
    {
        private string _word2guess;
        public List<(int Key, (char letter,bool Value))> letters;

        public Ahorcado(string word)
        {
            this._word2guess = word;
            this.letters = new List<(int Key, (char letter, bool Value))> { };
            this.StartGame();
        }

        public string printword()
        {
            string op = "";
            foreach(var letra in letters)
            {
                if (letra.Item2.Value)
                {
                    op += " " + letra.Item2.letter;
                }
                else
                {
                    op += " _";
                }
                
            }
            return op.Trim();
        } 


        

        private void StartGame()
        {
            int count = 0;
            foreach (char l in _word2guess.ToCharArray())
            {
                count += 1;
                this.letters.Add((Key:count,(letter:l,Value:false)));
            }
            
        }


        public bool ValidateLetter(char letter)
        {
            if (!Char.IsLetter(letter))
            {
                throw new ArgumentException("El caracter ingresado no es una letra.");
            }
            return _word2guess.Contains(Char.ToUpper(letter));

        }

        public bool EnterLetter(char letter)
        {
            if (ValidateLetter(letter))
            {
                for(int i=0;i<=letters.Count-1;i++)
                {
                    if (letters[i].Item2.letter == Char.ToUpper(letter))
                    {
                        letters[i] = (Key: i, (letter: Char.ToUpper(letter), Value: true));
                    }
                }
                return true;
            }
            return false;
        }
        public bool EnterWord(string Word)
        {
            if(_word2guess == Word.ToUpper())
            {
                for (int i = 0; i <= letters.Count - 1; i++)
                {
                    letters[i] = (Key: i, (letter: letters[i].Item2.letter, Value: true));
                }
                return true;
            }
            return false;
        }
    }
}

