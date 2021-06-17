using ContractingAppTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Tests
{
    class ShortestContractingChainTest
    {
        IWebDriver webDriver = new ChromeDriver();
        private ShortestContractingChain shortestContractingChain;
        [SetUp]
        public void Setup()
        {
            //Navigation
            webDriver.Navigate().GoToUrl("https://localhost:44381/");
            shortestContractingChain = new ShortestContractingChain(webDriver);
            shortestContractingChain.ClickShortestContractingChainHyperLink();
        }
        [Test]
        public void ShortestContractingChainPageLoadedTest()
        {
            Assert.That(shortestContractingChain.IsPageLoadedSuccessfully(), Is.True);
        }
        [Test]
        public void BackToListTestMethod()
        {
            shortestContractingChain.ClickBackToList();
            Assert.That(shortestContractingChain.IsHomePageDisplayed(), Is.True);
        }
        [Test]
        public void ContractorRequiredValidationMessageTest()
        {
            Assert.That(shortestContractingChain.IsRequiredErrorMessageDisplayed(), Is.True);
        }
        [Test]
        public void SameContractorValidationMessageTest()
        {
            Assert.That(shortestContractingChain.IsSameContractorValidationMessageDisplayed(), Is.True);
        }
        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();

    }
}
