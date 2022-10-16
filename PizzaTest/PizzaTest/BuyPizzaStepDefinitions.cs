using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTest
{
    [Binding]
    public class BuyPizzaStepDefinitions
    {
        private EdgeDriver edgeDriver;
        
        public BuyPizzaStepDefinitions()
        {
            edgeDriver = new EdgeDriver("C:\\Users\\shivtej.deshmukh\\Downloads\\edgedriver_win64");
        }

        [Given(@"that I am on pizza portal")]
        public void GivenThatIAmOnPizzaPortal()
        {
            //use url = https://pizzajoe20221016234140.azurewebsites.net for azure..
            //edgeDriver.Navigate().GoToUrl("https://pizzajoe20221016234140.azurewebsites.net");
            edgeDriver.Navigate().GoToUrl("https://localhost:7010/");
            

            edgeDriver.Manage().Window.Maximize();

            //throw new PendingStepException();
        }

        [Then(@"click on buy now to add pizza")]
        public void ThenClickOnBuyNowToAddPizza()
        {
            WebDriverWait wait = new WebDriverWait(edgeDriver, TimeSpan.FromSeconds(5));
            IWebElement BuyNow = edgeDriver.FindElement(By.XPath("(//a[@class='btn btn-primary'])[3]"));
            Thread.Sleep(3000);
            //edgeDriver.ExecuteScript("arguements[0].click();",BuyNow);
            BuyNow.Click();
            //throw new PendingStepException();
        }

        [Then(@"increase the amount of pizza")]
        public void ThenIncreaseTheAmountOfPizza()
        {
            IWebElement quantity = edgeDriver.FindElement(By.XPath("//table[contains(@class,'table table-bordered')]/tbody[1]/tr[2]/td[6]/input[1]"));
            var wait = new WebDriverWait(edgeDriver, TimeSpan.FromSeconds(5));

            Thread.Sleep(4000);
            quantity.SendKeys(Keys.ArrowUp);
            quantity.SendKeys(Keys.ArrowUp);


            IWebElement update = edgeDriver.FindElement(By.XPath("//input[@class='btn btn-warning']"));
            Thread.Sleep(3000);
            update.Click();
            //throw new PendingStepException();

        }

        [Then(@"click on checkout")]
        public void ThenClickOnCheckout()
        {
            WebDriverWait wait = new WebDriverWait(edgeDriver, TimeSpan.FromMilliseconds(5000));
            IWebElement pay = edgeDriver.FindElement(By.XPath("//a[@class='btn btn-primary']"));
            Thread.Sleep(3000);
            pay.Click();
            //throw new PendingStepException();
        }

        [Then(@"close browser")]
        public void ThenCloseBrowser()
        {
            edgeDriver.Quit();
            //throw new PendingStepException();
        }
    }
}
