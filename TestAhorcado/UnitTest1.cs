using System;
using System.Collections.Generic;
using Xunit;

namespace Ahorcado.Test
{
    public class AhorcadoTest
    {
        [Fact]
        public void test_startgame()
        {
            Ahorcado newGame = new Ahorcado("AUTO");

            Assert.Equal("_ _ _ _", newGame.printword());
        }

        [Fact]
        public void test_enter_correct_letter()
        {
            Ahorcado newGame = new Ahorcado("AHORCADO");

            Assert.True(newGame.ValidateLetter('A'));
        }
        [Fact]
        public void test_enter_non_correct_letter()
        {
            Ahorcado newGame = new Ahorcado("AHORCADO");

            Assert.False(newGame.ValidateLetter('J'));
        }
        [Fact]
        public void test_enter_correct_letter_casesensitive()
        {
            Ahorcado newGame = new Ahorcado("AHORCADO");

            Assert.True(newGame.ValidateLetter('a'));
        }
        [Fact]
        public void test_enter_non_letter_number()
        {
            Ahorcado newGame = new Ahorcado("AHORCADO");

            var ex = Assert.Throws<ArgumentException>(() => newGame.ValidateLetter('4'));

            Assert.Equal("El caracter ingresado no es una letra.", ex.Message);
        }
        [Fact]
        public void test_enter_non_letter_space()
        {
            Ahorcado newGame = new Ahorcado("AHORCADO");

            var ex = Assert.Throws<ArgumentException>(() => newGame.ValidateLetter(' '));

            Assert.Equal("El caracter ingresado no es una letra.", ex.Message);
        }
        [Fact]
        public void test_enter_non_letter_symbol()
        {
            Ahorcado newGame = new Ahorcado("AHORCADO");

            var ex = Assert.Throws<ArgumentException>(() => newGame.ValidateLetter('$'));

            Assert.Equal("El caracter ingresado no es una letra.", ex.Message);
        }
        [Fact]
        public void test_correct_letter_printword()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            newGame.EnterLetter('A');
            Assert.Equal("A _ _ _ _ A _ _ _ _", newGame.printword());
        }
        [Fact]
        public void test_correct_guessed_word()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            Assert.True(newGame.EnterWord("AUTOMATICO"));
            Assert.Equal("A U T O M A T I C O", newGame.printword());
        }
        [Fact]
        public void test_incorrect_guessed_word()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            Assert.False(newGame.EnterWord("AUTOTATICO"));
        }

        [Fact]
        public void test_incorrect_letters()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('G');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('P');
            List<char> lista = new List<char> { 'G', 'Q', 'P' };
            Assert.Equal(lista,newGame.incorrectLetters);
        }

        [Fact]
        public void test_incorrect_letters_duplicates()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('G');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('P');
            newGame.EnterLetter('P');
            List<char> lista = new List<char> { 'G', 'Q', 'P' };
            Assert.Equal(lista, newGame.incorrectLetters);
        }

        [Fact]
        public void test_subtract_lifes()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('G');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('P');
            Assert.Equal(5, newGame.lifes);
        }

        [Fact]
        public void test_subtract_lifes_duplicates()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('G');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('P');
            newGame.EnterLetter('P');
            Assert.Equal(5, newGame.lifes);
        }

        [Fact]
        public void test_get_points()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('A');
            newGame.EnterLetter('U');
            newGame.EnterLetter('T');
            newGame.EnterLetter('O');
            newGame.EnterLetter('M');
            newGame.EnterLetter('I');
            newGame.EnterLetter('C');
            Assert.Equal(20, newGame.endOfGame());
        }

        [Fact]
        public void test_get_points_incorrects()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('A');
            newGame.EnterLetter('D');
            newGame.EnterLetter('X');
            newGame.EnterLetter('U');
            newGame.EnterLetter('T');
            newGame.EnterLetter('O');
            newGame.EnterLetter('M');
            newGame.EnterLetter('I');
            newGame.EnterLetter('C');
            Assert.Equal(18, newGame.endOfGame());
        }
        [Fact]
        public void test_get_points_all_incorrects()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('D');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('P');
            newGame.EnterLetter('X');
            newGame.EnterLetter('L');
            newGame.EnterLetter('R');
            newGame.EnterLetter('Z');
            newGame.EnterLetter('Ñ');
            Assert.Equal(0, newGame.endOfGame());
        }
        [Fact]
        public void test_get_points_1correct_rest_incorrects()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");
            newGame.EnterLetter('D');
            newGame.EnterLetter('A');
            newGame.EnterLetter('Q');
            newGame.EnterLetter('P');
            newGame.EnterLetter('X');
            newGame.EnterLetter('L');
            newGame.EnterLetter('R');
            newGame.EnterLetter('Z');
            newGame.EnterLetter('Ñ');
            Assert.Equal(0, newGame.endOfGame());
        }

        [Fact]
        public void test_guessed_word_points()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            newGame.EnterWord("AUTOMATICO");

            Assert.Equal(30,newGame.endOfGame());
        }

        [Fact]
        public void test_guessed_word_w_errors_points()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            newGame.EnterLetter('R');
            newGame.EnterLetter('Z');
            newGame.EnterLetter('Ñ');
            newGame.EnterWord("AUTOMATICO");

            Assert.Equal(27, newGame.endOfGame());
        }

        [Fact]
        public void test_guessed_word_w_corrects_points()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            newGame.EnterLetter('A');
            newGame.EnterLetter('U');
            newGame.EnterLetter('T');
            newGame.EnterWord("AUTOMATICO");

            Assert.Equal(30, newGame.endOfGame());
        }
        [Fact]
        public void test_guessed_word_w_corrects_errors_points()
        {
            Ahorcado newGame = new Ahorcado("AUTOMATICO");

            newGame.EnterLetter('A');
            newGame.EnterLetter('U');
            newGame.EnterLetter('X');
            newGame.EnterLetter('T');
            newGame.EnterWord("AUTOMATICO");

            Assert.Equal(29, newGame.endOfGame());
        }

        [Fact]
        public void test_enter_user_name()
        {
            Usuario user = new Usuario("user1");

            Assert.Equal("user1",user.userName);
        }
    }
}
