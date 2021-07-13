using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hangman.Models
{
    public class HangmanModel
    {
        public HangmanModel() { }
        public HangmanModel(string player1, string player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
        }
        public string Player1 { get; set; }
        public int Player1Played { get; set; } = 0;
        public string Player2 { get; set; }
        public int Player2Played { get; set; } = 0;
        public bool PlayingPlayer1 { get; set; } // TODO
        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Debe ingresar solo letras")]
        public string WordToGuess { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Debe ingresar una letra o una palabra.")]
        public string Attempt { get; set; }
        public List<HangmanLetter> Letters { get; set; }
        public List<char> BadLetters { get; set; }
        public int Lifes { get; set; }
        public bool GuessedWholeWord { get; set; }
        public bool Playing { get; set; }
        public bool Lost { get; set; }
        public bool Won { get; set; }
        public int PointsPlayer1 { get; set; } = 0;
        public int PointsPlayer2 { get; set; } = 0;
    }

    public class HangmanLetter
    {
        public HangmanLetter(char letter, bool display)
        {
            Letter = letter;
            Display = display;
        }
        public char Letter { get; set; }
        public bool Display { get; set; }
    }
}

