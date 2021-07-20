using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace UITestAhorcado.pages
{
    public class MainMenu
    {
        public IWebDriver webDriver { get; }

        public MainMenu(IWebDriver _driver)
        {
            webDriver = _driver;
        }

        public IWebElement player1 => webDriver.FindElement(By.CssSelector("algo"));
    }
}
