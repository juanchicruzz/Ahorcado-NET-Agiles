using System.ComponentModel.DataAnnotations;

namespace Hangman.Models
{
    public class PlayerModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Player1 { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Player2 { get; set; }
    }
}