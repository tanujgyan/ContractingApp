using ContractingAppTest.Pages.CreateContract;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace ContractingAppTest.Tests
{
    class CreateContractTest
    {
        IWebDriver webDriver = new ChromeDriver();
        private CreateContract createContract;
        [SetUp]
        public void Setup()
        {
            //Navigation
            webDriver.Navigate().GoToUrl("https://localhost:44381/");
            createContract = new CreateContract(webDriver);
            createContract.ClickCreateContractHyperLink();
        }

        [Test]
        public void CreateContractTestMethod()
        {
            Assert.That(createContract.IsPageLoadedSuccessfully(), Is.True);
        }
        [Test]
        public void SubmitContractWithoutSelectingAnyContractorTestMethod()
        {
            createContract.SubmitForm();
            Assert.That(createContract.IsErrorMessageToSelectContractorDisplayed(), Is.True);
        }
        [Test]
        public void SubmitContractAfterSelectingSameContractorTestMethod()
        {
            createContract.SelectFirstElementInContractorDropdown();
            createContract.SubmitForm();
            Assert.That(createContract.IsErrorMessageForSameContractorDisplayed(), Is.True);
        }
        [Test]
        public void BackToListTestMethod()
        {
            createContract.ClickBackToList();
            Assert.That(createContract.IsHomePageDisplayed(), Is.True);
        }
        [Test]
        [Obsolete]
        public void IsContractCreatedTest()
        {
            Assert.That(createContract.IsContractCreated(), Is.True);
        }
        [Test]
        public void IsErrorMessageForAlreadyExistingContractTestMethod()
        {
            Assert.That(createContract.IsErrorMessageForAlreadyExistingContractDisplayed(), Is.True);
        }
        //close the browser once all child tests are done
        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();

    }
}
