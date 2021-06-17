using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ContractingAppTest.Pages
{
    class ShortestContractingChain
    {
        private readonly IWebDriver webDriver;
        public ShortestContractingChain(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        private IWebElement BackToListLink => webDriver.FindElement(By.Id("backtolist"));
        private IWebElement Contractor1Dropdown => webDriver.FindElement(By.Id("contractor1"));
        private IWebElement Contractor2Dropdown => webDriver.FindElement(By.Id("contractor2"));
        private IWebElement SearchButton => webDriver.FindElement(By.Id("submitbutton"));
        private IWebElement BackToListHyperlink => webDriver.FindElement(By.Id("backtolist"));
        private IWebElement GetShortestContractingChainElement => webDriver.FindElement(By.Id("shortestcontractingchain"));
        private IWebElement ContractorListTable => webDriver.FindElement(By.Id("contractortable"));
        private IWebElement RequiredValidationMessageContractor1 => webDriver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[1]/span"));
        private IWebElement RequiredValidationMessageContractor2 => webDriver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[2]/span"));
        private IWebElement SameContractorValidation => webDriver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[1]/span"));
        
        public void ClickShortestContractingChainHyperLink()
        {
            GetShortestContractingChainElement.Click();
        }
        public bool IsPageLoadedSuccessfully()
        {
            return Contractor1Dropdown.Displayed && Contractor2Dropdown.Displayed
                && SearchButton.Displayed && BackToListHyperlink.Displayed;
        }
        public bool IsHomePageDisplayed()
        {
            return ContractorListTable.Displayed;
        }
        public void ClickBackToList()
        {
            BackToListLink.Click();
        }
        public bool IsRequiredErrorMessageDisplayed()
        {
            SearchButton.Click();
           return RequiredValidationMessageContractor1.Displayed &&
                RequiredValidationMessageContractor2.Displayed &&
                RequiredValidationMessageContractor1.Text == "Please select Contractor 1" &&
                RequiredValidationMessageContractor2.Text == "Please select Contractor 2";
        }
        public bool IsSameContractorValidationMessageDisplayed()
        {
            var selectElement = new SelectElement(Contractor1Dropdown);
            selectElement.SelectByValue("1");
            selectElement = new SelectElement(Contractor2Dropdown);
            selectElement.SelectByValue("1");
            SearchButton.Click();
            return SameContractorValidation.Displayed &&
                SameContractorValidation.Text == "Contractor1 cannot be same as Contractor2";
        }
       
    }
}
