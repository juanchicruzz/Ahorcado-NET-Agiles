using System;
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

    }
}
