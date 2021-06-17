using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ContractingAppTest.Pages
{
    class TerminateContract
    {
        private readonly IWebDriver webDriver;
        public TerminateContract(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        private IWebElement GetTerminateContractElement => webDriver.FindElement(By.Id("terminatecontract"));
        private IWebElement Contractor1Dropdown => webDriver.FindElement(By.Id("primarycontractor"));
        private IWebElement Contractor2Dropdown => webDriver.FindElement(By.Id("contractor2"));
        private IWebElement FetchRelatedButton => webDriver.FindElement(By.Id("fetchrelatedcontractors"));
        private IWebElement TerminateContractButton => webDriver.FindElement(By.Id("terminaterelation"));
        private IWebElement ContractorListTable => webDriver.FindElement(By.Id("contractortable"));
        private IWebElement BackToListLink => webDriver.FindElement(By.Id("backtolist"));
        private IWebElement Contractor1Validation => webDriver.FindElement(By.XPath("/html/body/div/main/div[2]/div/form/div[1]/span"));
        private IWebElement ValidationSummary => webDriver.FindElement(By.XPath("/html/body/div/main/div[1]"));
        public bool IsPageLoadedSuccessfully()
        {
            return Contractor1Dropdown.Displayed && FetchRelatedButton.Displayed;
        }
        public bool IsHomePageDisplayed()
        {
            return ContractorListTable.Displayed;
        }
        public void ClickTerminateContractHyperLink()
        {
            GetTerminateContractElement.Click();
        }
        public bool ClickFetchButtonWithoutSelectingContractor()
        {
            ClickFetch();
            return Contractor1Validation.Displayed;
        }
        public void SelectContractor1()
        {
            var selectElement = new SelectElement(Contractor1Dropdown);
            selectElement.SelectByText("TestContractor1");
        }
        public void SelectContractor2()
        {
            var selectElement = new SelectElement(Contractor2Dropdown);
            selectElement.SelectByText("Billy Jones");
        }
        public void ClickBackToList()
        {
            BackToListLink.Click();
        }
        public void ClickFetch()
        {
            FetchRelatedButton.Click();
        }
        public void ClickTerminateContract()
        {
            TerminateContractButton.Click();
        }
        public bool ValidationSummaryDisplayed()
        {
            SelectContractor1();
            ClickFetch();
            ClickTerminateContract();
            return ValidationSummary.Displayed;
        }
        [System.Obsolete]
        public bool TerminateContractMethod()
        {
            try
            {
                SelectContractor1();
                ClickFetch();
                SelectContractor2();
                ClickTerminateContract();
                IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(webDriver);
                if (alert != null)
                {
                    alert.Accept();
                }
                return (alert != null);
            }
            catch(Exception)
            {
                return false;
            }
        }


    }
}
