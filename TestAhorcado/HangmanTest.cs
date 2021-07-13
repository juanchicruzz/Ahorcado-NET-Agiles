using System;
using System.Collections.Generic;
using Xunit;
using Hangman.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ahorcado.Test
{
    public class HangmanTest
    {
        //[Fact]
        //public void Test_startgame()
        //{
        //    HangmanController controller = new HangmanController();

        //    IActionResult result = controller.StartGame();

        //    Assert.Equal("_ _ _ _ _ _ _ _ _ _", result);
        //}

        //[Fact]
        //public void Test_enter_correct_letter()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterLetter('A');

        //    Assert.True(result.GuessedTheLetter);
        //}

        //[Fact]
        //public void Test_enter_non_correct_letter()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterLetter('H');

        //    Assert.False(result.GuessedTheLetter);
        //}

        //[Fact]
        //public void Test_enter_correct_letter_casesensitive()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterLetter('a');

        //    Assert.True(result.GuessedTheLetter);
        //}

        //[Fact]
        //public void Test_enter_non_letter_number()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    ArgumentException ex = Assert.Throws<ArgumentException>(() => controller.EnterLetter('2'));

        //    Assert.Equal("El caracter ingresado no es una letra.", ex.Message);
        //}

        //[Fact]
        //public void Test_enter_non_letter_space()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    ArgumentException ex = Assert.Throws<ArgumentException>(() => controller.EnterLetter(' '));

        //    Assert.Equal("El caracter ingresado no es una letra.", ex.Message);
        //}

        //[Fact]
        //public void Test_enter_non_letter_symbol()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    ArgumentException ex = Assert.Throws<ArgumentException>(() => controller.EnterLetter('$'));

        //    Assert.Equal("El caracter ingresado no es una letra.", ex.Message);
        //}

        //[Fact]
        //public void Test_correct_letter_print_word()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterLetter('A');

        //    Assert.Equal("A _ _ _ _ A _ _ _ _", result.PrintWord());
        //}

        //[Fact]
        //public void Test_correct_guessed_word()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterWord("AUTOMATICO");

        //    Assert.Equal("A U T O M A T I C O", result.PrintWord());
        //}
        //[Fact]
        //public void Test_incorrect_guessed_word()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterWord("AUTOMATICA");

        //    Assert.False(result.GuessedWholeWord);
        //}

        //[Fact]
        //public void Test_incorrect_letters()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");
        //    List<char> list = new List<char> { 'G', 'Q', 'P' };

        //    controller.EnterLetter('G');
        //    controller.EnterLetter('Q');
        //    Hangman result = controller.EnterLetter('P');
            
        //    Assert.Equal(list, result.BadLetters);
        //}

        //[Fact]
        //public void Test_incorrect_letters_duplicates()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");
        //    List<char> list = new List<char> { 'G', 'Q', 'P' };

        //    controller.EnterLetter('G');
        //    controller.EnterLetter('Q');
        //    controller.EnterLetter('Q');
        //    controller.EnterLetter('P');
        //    Hangman result = controller.EnterLetter('P');

        //    Assert.Equal(list, result.BadLetters);
        //}

        //[Fact]
        //public void Test_subtract_lifes()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('G');
        //    controller.EnterLetter('Q');
        //    Hangman result = controller.EnterLetter('P');

        //    Assert.Equal(Constant.LIFES - 3, result.Lifes);
        //}

        //[Fact]
        //public void Test_subtract_lifes_duplicates()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('G');
        //    controller.EnterLetter('Q');
        //    controller.EnterLetter('Q');
        //    controller.EnterLetter('P');
        //    Hangman result = controller.EnterLetter('P');

        //    Assert.Equal(Constant.LIFES - 3, result.Lifes);
        //}

        //[Fact]
        //public void Test_get_points()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('A');
        //    controller.EnterLetter('U');
        //    controller.EnterLetter('T');
        //    controller.EnterLetter('O');
        //    controller.EnterLetter('M');
        //    controller.EnterLetter('I');
        //    controller.EnterLetter('C');

        //    Assert.Equal(Constant.POINTS_FOR_WINNING, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_get_points_incorrects()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('A');
        //    controller.EnterLetter('D');
        //    controller.EnterLetter('X');
        //    controller.EnterLetter('U');
        //    controller.EnterLetter('T');
        //    controller.EnterLetter('O');
        //    controller.EnterLetter('M');
        //    controller.EnterLetter('I');
        //    Hangman result = controller.EnterLetter('C');

        //    Assert.Equal(Constant.POINTS_FOR_WINNING - (Constant.POINTS_LESS_BY_MISTAKE * result.BadLetters.Count), controller.GetPoints());
        //}

        //[Fact]
        //public void Test_get_points_all_incorrects()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('D');
        //    controller.EnterLetter('Q');
        //    controller.EnterLetter('P');
        //    controller.EnterLetter('X');
        //    controller.EnterLetter('L');
        //    controller.EnterLetter('R');
        //    controller.EnterLetter('Z');
        //    controller.EnterLetter('J');

        //    Assert.Equal(0, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_get_points_1correct_rest_incorrects()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('O');
        //    controller.EnterLetter('A');
        //    controller.EnterLetter('D');
        //    controller.EnterLetter('Q');
        //    controller.EnterLetter('P');
        //    controller.EnterLetter('X');
        //    controller.EnterLetter('L');
        //    controller.EnterLetter('R');
        //    controller.EnterLetter('Z');
        //    controller.EnterLetter('J');

        //    Assert.Equal(0, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_guessed_word_points()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    Hangman result = controller.EnterWord("AUTOMATICO");

        //    Assert.Equal(Constant.POINTS_FOR_WINNING - (Constant.POINTS_LESS_BY_MISTAKE * result.BadLetters.Count) + Constant.POINTS_PER_WORD, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_guessed_word_w_errors_points()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('P');
        //    controller.EnterLetter('E');
        //    controller.EnterLetter('R');
        //    Hangman result = controller.EnterWord("AUTOMATICO");

        //    Assert.Equal(Constant.POINTS_FOR_WINNING - (Constant.POINTS_LESS_BY_MISTAKE * result.BadLetters.Count) + Constant.POINTS_PER_WORD, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_guessed_word_w_corrects_points()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('A');
        //    controller.EnterLetter('U');
        //    controller.EnterLetter('T');
        //    Hangman result = controller.EnterWord("AUTOMATICO");

        //    Assert.Equal(Constant.POINTS_FOR_WINNING - (Constant.POINTS_LESS_BY_MISTAKE * result.BadLetters.Count) + Constant.POINTS_PER_WORD, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_guessed_word_w_corrects_and_errors_points()
        //{
        //    HangmanController controller = new HangmanController();
        //    controller.StartGame("AUTOMATICO");

        //    controller.EnterLetter('A');
        //    controller.EnterLetter('U');
        //    controller.EnterLetter('D');
        //    controller.EnterLetter('T');
        //    Hangman result = controller.EnterWord("AUTOMATICO");

        //    Assert.Equal(Constant.POINTS_FOR_WINNING - (Constant.POINTS_LESS_BY_MISTAKE * result.BadLetters.Count) + Constant.POINTS_PER_WORD, controller.GetPoints());
        //}

        //[Fact]
        //public void Test_enter_user_name()
        //{
        //    HangmanController controller = new HangmanController();

        //    User result = controller.Login("user1");

        //    Assert.Equal("user1", result.Username);
        //}
    }
}
