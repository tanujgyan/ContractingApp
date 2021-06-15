using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Pages.CreateContract
{
    class CreateContract
    {
        private readonly IWebDriver webDriver;

        public CreateContract(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        private IWebElement GetcreateContractElement()
        {
            return webDriver.FindElement(By.Id("createcontract"));
        }
        private IWebElement GetcreateContractContractor1Element()
        {
            return webDriver.FindElement(By.Id("createcontract_contractor1Id"));
        }
        private IWebElement GetcreateContractContractor2Element()
        {
            return webDriver.FindElement(By.Id("createcontract_contractor2Id"));
        }
        private IWebElement GetForm()
        {
            return webDriver.FindElement(By.Id("createcontractForm"));
        }
        private IWebElement GetContractor1NotSelectedErrorMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id='createcontract_contractor1Id-error']"));
        }
        private IWebElement GetSameContractorErrorMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id='createcontractForm']/div[1]/span"));
        }
        private IWebElement GetContractor2NotSelectedErrorMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id='createcontract_contractor2Id-error']"));
        }
        private IWebElement GetContractor1Dropdown()
        {
            return webDriver.FindElement(By.Id("createcontract_contractor1Id"));
        }
        private IWebElement GetContractor2Dropdown()
        {
            return webDriver.FindElement(By.Id("createcontract_contractor2Id"));
        }
        private IWebElement GetBackToListLink()
        {
            return webDriver.FindElement(By.Id("backtolist"));
        }
        private IWebElement GetContractorListTable()
        {
            return webDriver.FindElement(By.Id("contractortable"));
        }
        private IWebElement GetExistingContractErrorMessage()
        {
          return webDriver.FindElement(By.XPath("//*[@id='createcontractForm']/div[1]/span"));
        }
        public void SelectFirstElementInContractorDropdown()
        {
            var selectElement = new SelectElement(GetContractor1Dropdown());
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(GetContractor2Dropdown());
            selectElement.SelectByValue("1");
        }
        public void ClickCreateContractHyperLink()
        {
            GetcreateContractElement().Click();
        }
        public void SubmitForm()
        {
            GetForm().Submit();
        }
        public void ClickBackToList()
        {
            GetBackToListLink().Click();
        }
        public bool IsContractorDropdownsDisplayed()
        {
            return GetcreateContractContractor1Element().Displayed && GetcreateContractContractor2Element().Displayed;
        }
        public bool IsErrorMessageToSelectContractorDisplayed()
        {
            return GetContractor1NotSelectedErrorMessage().Displayed && GetContractor2NotSelectedErrorMessage().Displayed;
        }
        public bool IsErrorMessageForSameContractorDisplayed()
        {
            return GetSameContractorErrorMessage().Displayed;
        }
        public bool IsHomePageDisplayed()
        {
            return GetContractorListTable().Displayed;
        }

        [Obsolete]
        //If this test fails, please make sure the contractor 1 is not connected to contractor 3
        //I am assuming this test is based on the mockup data i have created 
        //In the mockup data contractor 1 and 3 are not connected to each other directly
        public bool IsContractCreated()
        {
            var selectElement = new SelectElement(GetContractor1Dropdown());
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(GetContractor2Dropdown());
            selectElement.SelectByValue("3");
            SubmitForm();
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(webDriver);
            return (alert != null);
        }
        public bool IsErrorMessageForAlreadyExistingContractDisplayed()
        {
            var selectElement = new SelectElement(GetContractor1Dropdown());
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(GetContractor2Dropdown());
            selectElement.SelectByValue("2");
            SubmitForm();
            var val = GetExistingContractErrorMessage().Text;
           return val == "Contractor1 is already related to Contractor2" ? true : false;
            
        }
    }
}
