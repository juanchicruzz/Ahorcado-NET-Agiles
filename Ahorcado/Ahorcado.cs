using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class Ahorcado
    {
        private string _word2guess;
        private List<(int Key, (char letter,bool Value))> letters;
        public List<char> incorrectLetters;
        public int lifes;
        private bool assertWord;
        public Ahorcado(string word)
        {
            this._word2guess = word;
            this.letters = new List<(int Key, (char letter, bool Value))> { };
            this.incorrectLetters = new List<char> { };
            this.lifes = 8;
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
            if (!incorrectLetters.Contains(letter))
            {
                incorrectLetters.Add(letter);
                this.lifes -= 1;
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
                this.assertWord = true;
                return true;
            }
            this.lifes -= 2;
            return false;
        }

        public int endOfGame()
        {
            if (lifes <= 0)
            {
                return 0;
            }
            else
            {
                int points = 20;
                if (this.assertWord)
                {
                    points += 10;
                }
                int count = incorrectLetters.Count;
                return points - count;
            }

        }
    }
}

