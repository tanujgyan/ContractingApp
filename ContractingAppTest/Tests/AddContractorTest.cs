using ContractingAppTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Tests
{
    class AddContractorTest
    {
        IWebDriver webDriver = new ChromeDriver();
        private AddContractor addContractor;
        [SetUp]
        public void Setup()
        {
            //Navigation
            webDriver.Navigate().GoToUrl("https://localhost:44381/");
            addContractor = new AddContractor(webDriver);
            addContractor.ClickAddContractorHyperLink();
        }
        [Test]
        public void CreateContractTestMethod()
        {
            Assert.That(addContractor.IsPageLoadedSuccessfully(), Is.True);
        }
        [Test]
        public void BackToListTestMethod()
        {
            addContractor.ClickBackToList();
            Assert.That(addContractor.IsHomePageDisplayed(), Is.True);
        }
        [Test]
        [Obsolete]
        public void SubmitFormTest()
        {
            Assert.That(addContractor.SubmitForm(), Is.True);
        }
        [Test]
        [Obsolete]
        public void FormValidationTest()
        {
            Assert.That(addContractor.IsFormValidationDisplayed(), Is.True);
        }
        //close the browser once all child tests are done
        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}
