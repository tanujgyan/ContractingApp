using ContractingAppTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Tests
{
    class TerminateContractTest
    {
        IWebDriver webDriver = new ChromeDriver();
        private TerminateContract terminateContract;
        [SetUp]
        public void Setup()
        {
            //Navigation
            webDriver.Navigate().GoToUrl("https://localhost:44381/");
            terminateContract = new TerminateContract(webDriver);
            terminateContract.ClickTerminateContractHyperLink();
        }
        [Test]
        public void TerminatePageLoadedTest()
        {
            Assert.That(terminateContract.IsPageLoadedSuccessfully(), Is.True);
        }
        [Test]
        public void BackToListTestMethod()
        {
            terminateContract.ClickBackToList();
            Assert.That(terminateContract.IsHomePageDisplayed(), Is.True);
        }
        [Test]
        public void ClickFetchButtonWithoutSelectingContractorTest()
        {
            Assert.That(terminateContract.ClickFetchButtonWithoutSelectingContractor(), Is.True);
        }
        [Test]
        [Obsolete]
        public void TerminateContractMethodTest()
        {
            Assert.That(terminateContract.TerminateContractMethod(), Is.True);
        }
        [Test]
        public void ValidationSummaryTest()
        {
            Assert.That(terminateContract.ValidationSummaryDisplayed, Is.True);
        }
        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}
