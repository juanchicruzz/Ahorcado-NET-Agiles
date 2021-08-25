using Hangman.Controllers;
using Hangman.Models;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Ahorcado.Test
{
    public class HangmanTest
    {
        [Fact]
        public void Test_player_index_get()
        {
            HangmanService hangmanService = new HangmanService();
            PlayerController playerController = new PlayerController(hangmanService);

            ViewResult result = playerController.Index() as ViewResult;

            Assert.NotNull(result.Model);
        }


        [Fact]
        public void Test_set_players()
        {
            HangmanService hangmanService = new HangmanService();

            HangmanModel result = hangmanService.SetPlayers("player1", "player2");

            Assert.Equal("player4", result.Player1);
            Assert.Equal("player2", result.Player2);
        }

        [Fact]
        public void Test_start_game_player()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");

            HangmanModel result = hangmanService.StartGame(hangman);

            Assert.True(result.GameOwnerIsPlayer1);
            Assert.Equal(new List<HangmanLetter>(), result.Letters);
            Assert.Equal(new List<char>(), result.BadLetters);
            Assert.Equal(Constant.LIFES, result.Lifes);
            Assert.True(result.Playing);
            Assert.False(result.Won);
            Assert.False(result.Lost);
            Assert.False(result.GuessedWholeWord);
        }

        [Fact]
        public void Test_set_word_to_guess_lower_case()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");

            HangmanModel result = hangmanService.SetWordToGuess("auto", hangman);

            Assert.Equal("AUTO", result.WordToGuess);
            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('A', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('U', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('T', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('O', elem4.Letter); Assert.False(elem4.Display); }
                );
        }

        [Fact]
        public void Test_set_word_to_guess_upper_case()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");

            HangmanModel result = hangmanService.SetWordToGuess("CASA", hangman);

            Assert.Equal("CASA", result.WordToGuess);
            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); }
                );
        }

        [Fact]
        public void Test_set_word_to_guess_camel_case()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");

            HangmanModel result = hangmanService.SetWordToGuess("Rosario", hangman);

            Assert.Equal("ROSARIO", result.WordToGuess);
            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('R', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('O', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); },
                elem5 => { Assert.Equal('R', elem5.Letter); Assert.False(elem5.Display); },
                elem6 => { Assert.Equal('I', elem6.Letter); Assert.False(elem6.Display); },
                elem7 => { Assert.Equal('O', elem7.Letter); Assert.False(elem7.Display); }
                );
        }

        [Fact]
        public void Test_enter_correct_letter()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("S", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.True(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); }
                );
        }

        [Fact]
        public void Test_enter_incorrect_letter()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("P", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); }
                );
            Assert.Equal(Constant.LIFES - 1, result.Lifes);
        }

        [Fact]
        public void Test_enter_correct_letter_casesensitive()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("s", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.True(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); }
                );
        }

        [Fact]
        public void Test_correct_letter_duplicated()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("A", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.True(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.True(elem4.Display); }
                );
        }

        [Fact]
        public void Test_win()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("C", hangman);
            result = hangmanService.Try("A", hangman);
            result = hangmanService.Try("S", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.True(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.True(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.True(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.True(elem4.Display); }
                );
            Assert.True(result.Won);
            Assert.False(result.Playing);
        }

        [Fact]
        public void Test_win_with_word()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("CASA", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.True(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.True(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.True(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.True(elem4.Display); }
                );
            Assert.True(result.Won);
            Assert.True(result.GuessedWholeWord);
            Assert.False(result.Playing);
        }

        [Fact]
        public void Test_lost()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("P", hangman);
            result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("I", hangman);
            result = hangmanService.Try("E", hangman);
            result = hangmanService.Try("U", hangman);
            result = hangmanService.Try("N", hangman);
            result = hangmanService.Try("T", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); }
                );
            Assert.True(result.Lost);
            Assert.False(result.Playing);
            Assert.Equal(0, result.Lifes);
        }

        [Fact]
        public void Test_incorrect_word()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("CAMA", hangman);

            Assert.Collection(result.Letters,
                elem1 => { Assert.Equal('C', elem1.Letter); Assert.False(elem1.Display); },
                elem2 => { Assert.Equal('A', elem2.Letter); Assert.False(elem2.Display); },
                elem3 => { Assert.Equal('S', elem3.Letter); Assert.False(elem3.Display); },
                elem4 => { Assert.Equal('A', elem4.Letter); Assert.False(elem4.Display); }
                );
        }

        [Fact]
        public void Test_incorrect_letters()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("E", hangman);
            result = hangmanService.Try("N", hangman);

            Assert.Collection(result.BadLetters,
                elem1 => Assert.Equal('O', elem1),
                elem2 => Assert.Equal('E', elem2),
                elem3 => Assert.Equal('N', elem3)
                );
        }

        [Fact]
        public void Test_incorrect_letters_duplicated()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("E", hangman);
            result = hangmanService.Try("N", hangman);
            result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("E", hangman);

            Assert.Collection(result.BadLetters,
                elem1 => Assert.Equal('O', elem1),
                elem2 => Assert.Equal('E', elem2),
                elem3 => Assert.Equal('N', elem3)
                );
        }

        [Fact]
        public void Test_incorrect_word_lifes()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("CAMA", hangman);

            Assert.Equal(Constant.LIFES - 2, result.Lifes);
        }

        [Fact]
        public void Test_incorrect_letters_lifes()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("E", hangman);
            result = hangmanService.Try("N", hangman);

            Assert.Equal(Constant.LIFES - 3, result.Lifes);
        }

        [Fact]
        public void Test_incorrect_letters_duplicated_lifes()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("E", hangman);
            result = hangmanService.Try("N", hangman);
            result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("E", hangman);

            Assert.Equal(Constant.LIFES - 3, result.Lifes);
        }

        [Fact]
        public void Test_win_and_get_points()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("C", hangman);
            result = hangmanService.Try("A", hangman);
            result = hangmanService.Try("S", hangman);

            Assert.Equal(Constant.POINTS_FOR_WINNING, result.PointsPlayer2);
        }

        [Fact]
        public void Test_win_with_errors_and_get_points()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("C", hangman);
            result = hangmanService.Try("A", hangman);
            result = hangmanService.Try("S", hangman);

            Assert.Equal(Constant.POINTS_FOR_WINNING - (hangman.BadLetters.Count * Constant.POINTS_LESS_BY_MISTAKE), result.PointsPlayer2);
        }

        [Fact]
        public void Test_win_with_word_and_get_points()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("CASA", hangman);

            Assert.Equal(Constant.POINTS_FOR_WINNING - (hangman.BadLetters.Count * Constant.POINTS_LESS_BY_MISTAKE) + Constant.POINTS_PER_WORD, result.PointsPlayer2);
        }

        [Fact]
        public void Test_lost_and_get_points()
        {
            HangmanService hangmanService = new HangmanService();
            HangmanModel hangman = new HangmanModel("player1", "player2");
            hangman = hangmanService.StartGame(hangman);
            hangman = hangmanService.SetWordToGuess("CASA", hangman);

            HangmanModel result = hangmanService.Try("P", hangman);
            result = hangmanService.Try("O", hangman);
            result = hangmanService.Try("I", hangman);
            result = hangmanService.Try("E", hangman);
            result = hangmanService.Try("U", hangman);
            result = hangmanService.Try("N", hangman);
            result = hangmanService.Try("T", hangman);

            Assert.Equal(0, result.PointsPlayer1);
        }
    }
}
