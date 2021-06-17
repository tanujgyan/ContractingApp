using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractingAppTest.Pages
{
    class AddContractor
    {
        private readonly IWebDriver webDriver;
        public AddContractor(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        private IWebElement Name => webDriver.FindElement(By.Id("Name"));
        private IWebElement NameValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[1]/div[1]/span"));
        private IWebElement PhoneNumber => webDriver.FindElement(By.Id("PhoneNumber"));
        private IWebElement PhoneValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[1]/div[2]/span"));
        private IWebElement Carrier => webDriver.FindElement(By.Id("Type"));
        private IWebElement StreetNumber => webDriver.FindElement(By.Id("ContractorAddress_StreetNumber"));
        private IWebElement StreetNumberValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[2]/div[1]/span"));
        private IWebElement StreetName => webDriver.FindElement(By.Id("ContractorAddress_StreetName"));
        private IWebElement StreetNameValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[2]/div[2]/span"));
        private IWebElement Suite => webDriver.FindElement(By.Id("ContractorAddress_Suite"));
        private IWebElement City => webDriver.FindElement(By.Id("ContractorAddress_City"));
        private IWebElement CityValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[2]/div[4]/span"));
        private IWebElement Province => webDriver.FindElement(By.Id("ContractorAddress_Province"));
        private IWebElement ProvinceValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[2]/div[5]/span"));
        private IWebElement Country => webDriver.FindElement(By.Id("ContractorAddress_Country"));
        private IWebElement CountryValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[2]/div[6]/span"));
        private IWebElement PostalCode => webDriver.FindElement(By.Id("ContractorAddress_PostalCode"));
        private IWebElement PostalCodeValidation => webDriver.FindElement(By.XPath("//*[@id='addnewcontractorform']/div/div/div[2]/div[7]/span"));
        private IWebElement SubmitButton => webDriver.FindElement(By.Id("addcontractorbutton"));
        private IWebElement BackToListHyperlink => webDriver.FindElement(By.Id("backtolist"));
        public IWebElement GetAddContractorElement => webDriver.FindElement(By.Id("addcontractor"));
        private IWebElement ContractorListTable => webDriver.FindElement(By.Id("contractortable"));
        private IWebElement Form => webDriver.FindElement(By.Id("addnewcontractorform"));
        public bool IsPageLoadedSuccessfully()
        {
            return Name.Displayed && PhoneNumber.Displayed && Carrier.Displayed &&
                StreetName.Displayed && StreetNumber.Displayed && Suite.Displayed &&
                City.Displayed && Province.Displayed && Country.Displayed &&
                SubmitButton.Displayed && BackToListHyperlink.Displayed;
        }

        [Obsolete]
        public bool IsFormValidationDisplayed()
        {
            SubmitFormWithValidationErrors();
            return NameValidation.Displayed && PhoneValidation.Displayed && StreetNumber.Displayed
                && StreetNumberValidation.Displayed && CityValidation.Displayed && ProvinceValidation.Displayed
                && CountryValidation.Displayed;
        }
        private void AddContractorTestData()
        {
            Name.SendKeys("TestContractor1");
            PhoneNumber.SendKeys("1234567890");
            var selectElement = new SelectElement(Carrier);
            selectElement.SelectByValue("1");
            StreetName.SendKeys("Test Street");
            StreetNumber.SendKeys("12");
            Suite.SendKeys("1");
            City.SendKeys("Test City");
            Province.SendKeys("Test Province");
            Country.SendKeys("Test Country");
            PostalCode.SendKeys("Test PostalCode");
        }

        [Obsolete]
        public bool SubmitForm()
        {
            AddContractorTestData();
            Form.Submit();
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(webDriver);
            if (alert != null)
            {
                alert.Accept();
            }
            return (alert != null);
        }
        [Obsolete]
        public void SubmitFormWithValidationErrors()
        {
            Form.Submit();
        }
        public void ClickAddContractorHyperLink()
        {
            GetAddContractorElement.Click();
        }
        public void ClickBackToList()
        {
            BackToListHyperlink.Click();
        }
        public bool IsHomePageDisplayed()
        {
            return ContractorListTable.Displayed;
        }
    }
}
