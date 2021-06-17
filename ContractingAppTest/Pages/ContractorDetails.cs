using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Pages
{
    class ContractorDetails
    {
        private readonly IWebDriver webDriver;
        public ContractorDetails(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        private IWebElement DetailsHyperLink => webDriver.FindElement(By.XPath("//*[@id='contractortable']/tbody/tr[1]/td[5]/a"));
        private IWebElement DetailsList => webDriver.FindElement(By.XPath("/html/body/div/main/div[1]"));
        private IWebElement BackToListHyperlink => webDriver.FindElement(By.Id("backtolist"));
        private IWebElement ContractorListTable => webDriver.FindElement(By.Id("contractortable"));
        public bool IsPageLoaded()
        {
            DetailsHyperLink.Click();
            return DetailsList.Displayed && BackToListHyperlink.Displayed;
        }
        public void ClickBackToList()
        {
            DetailsHyperLink.Click();
            BackToListHyperlink.Click();
        }
        public bool IsHomePageDisplayed()
        {
            return ContractorListTable.Displayed;
        }
    }
}
