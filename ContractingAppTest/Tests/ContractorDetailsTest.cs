using ContractingAppTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Tests
{
    class ContractorDetailsTest
    {
        IWebDriver webDriver = new ChromeDriver();
        private ContractorDetails contractorDetails;
        [SetUp]
        public void Setup()
        {
            //Navigation
            webDriver.Navigate().GoToUrl("https://localhost:44381/");
            contractorDetails = new ContractorDetails(webDriver);
        }
        [Test]
        public void IsPageLoadedTest()
        {
            Assert.That(contractorDetails.IsPageLoaded(), Is.True);
        }
        [Test]
        public void BackToListTestMethod()
        {
            contractorDetails.ClickBackToList();
            Assert.That(contractorDetails.IsHomePageDisplayed(), Is.True);
        }
        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}
