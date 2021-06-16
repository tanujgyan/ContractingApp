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

        private IWebElement GetcreateContractElement => webDriver.FindElement(By.Id("createcontract"));
        private IWebElement GetcreateContractContractor1Element => webDriver.FindElement(By.Id("createcontract_contractor1Id"));
        private IWebElement GetcreateContractContractor2Element => webDriver.FindElement(By.Id("createcontract_contractor2Id"));
        private IWebElement Form => webDriver.FindElement(By.Id("createcontractForm"));
        private IWebElement Contractor1NotSelectedErrorMessage => webDriver.FindElement(By.XPath("//*[@id='createcontract_contractor1Id-error']"));
        private IWebElement SameContractorErrorMessage => webDriver.FindElement(By.XPath("//*[@id='createcontractForm']/div[1]/span"));
        private IWebElement Contractor2NotSelectedErrorMessage => webDriver.FindElement(By.XPath("//*[@id='createcontract_contractor2Id-error']"));
        private IWebElement Contractor1Dropdown => webDriver.FindElement(By.Id("createcontract_contractor1Id"));
        private IWebElement Contractor2Dropdown => webDriver.FindElement(By.Id("createcontract_contractor2Id"));
        private IWebElement BackToListLink => webDriver.FindElement(By.Id("backtolist"));
        private IWebElement ContractorListTable => webDriver.FindElement(By.Id("contractortable"));
        private IWebElement ExistingContractErrorMessage => webDriver.FindElement(By.XPath("//*[@id='createcontractForm']/div[1]/span"));
        private IWebElement SubmitButton => webDriver.FindElement(By.Id("createcontractbutton"));
        public void SelectFirstElementInContractorDropdown()
        {
            var selectElement = new SelectElement(Contractor1Dropdown);
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(Contractor2Dropdown);
            selectElement.SelectByValue("1");
        }
        public void ClickCreateContractHyperLink()
        {
            GetcreateContractElement.Click();
        }
        public void SubmitForm()
        {
            Form.Submit();
        }
        public void ClickBackToList()
        {
            BackToListLink.Click();
        }
        public bool IsPageLoadedSuccessfully()
        {
            return GetcreateContractContractor1Element.Displayed && GetcreateContractContractor2Element.Displayed
                && BackToListLink.Displayed && SubmitButton.Displayed;
        }
        public bool IsErrorMessageToSelectContractorDisplayed()
        {
            return Contractor1NotSelectedErrorMessage.Displayed && Contractor2NotSelectedErrorMessage.Displayed;
        }
        public bool IsErrorMessageForSameContractorDisplayed()
        {
            return SameContractorErrorMessage.Displayed;
        }
        public bool IsHomePageDisplayed()
        {
            return ContractorListTable.Displayed;
        }

        [Obsolete]
        //If this test fails, please make sure the contractor 1 is not connected to contractor 3
        //I am assuming this test is based on the mockup data i have created 
        //In the mockup data contractor 1 and 3 are not connected to each other directly
        public bool IsContractCreated()
        {
            var selectElement = new SelectElement(Contractor1Dropdown);
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(Contractor2Dropdown);
            selectElement.SelectByText("TestContractor1");
            SubmitForm();
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(webDriver);
            if (alert != null)
            {
                alert.Accept();
            }
            return (alert != null);
        }
        public bool IsErrorMessageForAlreadyExistingContractDisplayed()
        {
            var selectElement = new SelectElement(Contractor1Dropdown);
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(Contractor2Dropdown);
            selectElement.SelectByValue("2");
            SubmitForm();
           var val = ExistingContractErrorMessage.Text;
           return val == "Contractor1 is already related to Contractor2" ? true : false;
            
        }
    }
}
