using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace UITestAhorcado
{
    [Binding]
    public class ChromeDriverTest
    {
        static Random random = new Random();
        public static char GetLetter()
        {
            // This method returns a random lowercase between a and z
            int num = random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }

        ChromeDriver _driver;
        String baseURL;


        [BeforeScenario]
        public void TestInitialize()
        {
            // Initialize chrome driver 
            _driver = new ChromeDriver();
            baseURL = "http://localhost:8080/";
        }

        [Given("the the player1 is JUAN and the player2 is FRANCO")]
        public void Player1andPlayer2()
        {
            _driver.Navigate().GoToUrl(baseURL);
            IWebElement player1 = _driver.FindElement(By.XPath("//input[@id='player1']"));
            IWebElement player2 = _driver.FindElement(By.XPath("//input[@id='player2']"));
            IWebElement btnIngresar = _driver.FindElement(By.XPath("//button[@id='submit']"));

            player1.SendKeys("JUAN");
            player2.SendKeys("FRANCO");
            btnIngresar.Click();
        }
        [Given("the word2guess is (.*)")]
        public void word2guess(string word)
        {
            IWebElement word2guess = _driver.FindElement(By.XPath("//input[@id='wordToGuess']"));
            IWebElement btnJugar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            word2guess.SendKeys(word);
            btnJugar.Click();
        }
        [When("the player guessed 7 letters wrong")]
        public void enter7letterswrong()
        {
            IWebElement inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            IWebElement btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            Thread.Sleep(1000);
            inputWord.SendKeys("z");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("x");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("v");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("b");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("n");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("m");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("l");
            btnAceptar.Click();
            Thread.Sleep(1000);

        }
        [When("the player enters (.*) random letters")]
        public void enterRandomLetters(int number)
        {
            IWebElement inputWord;
            IWebElement btnAceptar;
            for(int i=0; i < number; i++)
            {
                string letter = GetLetter().ToString();
                Thread.Sleep(1000);
                inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
                btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
                inputWord.SendKeys(letter);
                btnAceptar.Click();

            }

        }

        [When("the player guesses the complete word (.*)")]
        public void completeWord(string word)
        {
            IWebElement inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            IWebElement btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            Thread.Sleep(1000);
            inputWord.SendKeys(word);
            btnAceptar.Click();



        }
        [When("the player guesses all letters")]
        public void enterAllLettersOK()
        {
            IWebElement inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            IWebElement btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            Thread.Sleep(1000);
            inputWord.SendKeys("a");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("h");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("o");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("r");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("c");
            btnAceptar.Click();
            Thread.Sleep(1000);
            inputWord = _driver.FindElement(By.XPath("//input[@id='attempt']"));
            btnAceptar = _driver.FindElement(By.XPath("//button[@id='submit']"));
            inputWord.SendKeys("d");
            btnAceptar.Click();
            Thread.Sleep(1000);

        }
        [When("the player restarts the game")]
        public void restartgame()
        {
            IWebElement btnRestart = _driver.FindElement(By.XPath("//input[@value='Reiniciar Juego']"));
            btnRestart.Click();
        }
        [Then("the game is restarted")]
        public void gameRestarted()
        {
            string currentUrl = _driver.Url;
            Assert.AreEqual("http://localhost:8080/", currentUrl);
        }
        [Then("the player loses the game")]
        public void hasperdido()
        {
            IWebElement textdanger = _driver.FindElement(By.XPath("//h2[@class='text-danger']"));
            string texto = textdanger.Text;
            Assert.AreEqual("Has perdido! :'(", texto);
        }

        [Then("the player wins the game")]
        public void hasganado()
        {
            IWebElement textdanger = _driver.FindElement(By.XPath("//h2[@class='text-success']"));
            string texto = textdanger.Text;
            Assert.AreEqual("Has ganado! :D", texto);
        }

        [AfterScenario]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
