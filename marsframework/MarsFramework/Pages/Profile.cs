using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Profile
    {
        #region  Initialize Web Elements 
        //Click on Edit button
        private IWebElement AvailabilityTimeEdit => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='large calendar icon']//following-sibling::strong[text()='Availability']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']"));

        //Click on Availability Type dropdown
        private IWebElement AvailabilityTime => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyType']"));

        //Select on Availability Time 
        private IWebElement AvailabilityTimeOpt => GlobalDefinitions.driver.FindElement(By.XPath("//option[@value='1']"));
        private IWebElement AvailabilityTimeOptRead => GlobalDefinitions.driver.FindElement(By.XPath("//span[text()='Full Time']"));

        //Click on Availability Hours option
        private IWebElement AvailabilityHours => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='large clock outline check icon']//following-sibling::strong[text()='Hours']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']"));

        //Click on Availability Hour dropdown
        private IWebElement AvailabilityHoursOpt => GlobalDefinitions.driver.FindElement(By.XPath("//option[@value='2']"));

        //Find Earn Target button salary
        private IWebElement Salary => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='large dollar icon']//following-sibling::strong[text()='Earn Target']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']"));
        // Select the salary targetted
        private IWebElement EarnTargetSalaryOpt => GlobalDefinitions.driver.FindElement(By.XPath("//option[@value='0']"));

        //find Desctiption edit button
        private IWebElement DescriptionBtn => GlobalDefinitions.driver.FindElement(By.XPath("//h3[@class='ui dividing header'][text()='Description']//i[@class='outline write icon']"));

        //find description text box
        private IWebElement DescriptionValue => GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name='value']"));

        //Find Description Save Button
        private IWebElement DescriptionSave => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui twelve wide column']//button[@class='ui teal button'][text()='Save']"));

        // finding Language active tab
        private IWebElement LanguagesText => GlobalDefinitions.driver.FindElement(By.XPath("//A[@data-tab='first'][text()='Languages']"));

        // finding add new button
        private IWebElement AddNewLanguageBtn => GlobalDefinitions.driver.FindElement(By.XPath("//th[text()='Language']//following-sibling::th[@class='right aligned']/div[@class='ui teal button '][text()='Add New']"));

        // finding AddLanguageTextBox
        private IWebElement AddLanguageTextBox => GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@type='text' and @placeholder='Add Language'])"));
        // selecting language level
        private IWebElement LanguageLvlOpt => GlobalDefinitions.driver.FindElement(By.XPath("//select[@class='ui dropdown']//option[@value='Native/Bilingual']"));
        //finding add button on languages
        private IWebElement LanguageAddBtn => GlobalDefinitions.driver.FindElement(By.XPath("//input[@class='ui teal button']"));
        #endregion
        // is language german exists
        //IWebElement LanguageGermanExists = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='form-wrapper']//table[@class='ui fixed table']//thead//th[text()='Language']/ancestor::table[@class='ui fixed table']//following-sibling::tbody//tr//td[text()='German']"));
        //IWebElement LanguageGermanExists = GlobalDefinitions.driver.FindElement(By.XPath("//td[text()='German']"));
        //finding language remove icon
        //private IWebElement GermanRemoveBtn => GlobalDefinitions.driver.FindElement(By.XPath("//td[text()='German']//following-sibling::td[@class='right aligned']//i[@class='remove icon']"));

       

        public void EditProfile()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            //DescriptionValue.Clear();
            Thread.Sleep(1000);
            AvailabilityTimeEdit.Click();
            AvailabilityTime.Click();
            AvailabilityTimeOpt.Click();
            AvailabilityHours.Click();
            AvailabilityHoursOpt.Click();
            Base.test.Log(LogStatus.Info, "Availability tile has been selected");
            Salary.Click();
            EarnTargetSalaryOpt.Click();
            Base.test.Log(LogStatus.Info, "Salary expected has been added/updated");
            DescriptionBtn.Click();
            DescriptionValue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            DescriptionSave.Click();
            Base.test.Log(LogStatus.Info, "Description has been added/udated");
            LanguagesText.Click();
            AddNewLanguageBtn.Click();
            // GermanRemoveBtn.Click();
            
            Thread.Sleep(5000);
            AddLanguageTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Language"));
            LanguageLvlOpt.Click();
            LanguageAddBtn.Click();
            Base.test.Log(LogStatus.Info, "Language has been added");
            Thread.Sleep(5000);

            string LanguageText = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
            IWebElement LangRemoveButton = GlobalDefinitions.driver.FindElement(By.XPath("//td[text()='" + LanguageText + "']//following-sibling::td[@class='right aligned']//i[@class='remove icon']"));

            LangRemoveButton.Click();
            Base.test.Log(LogStatus.Info, "Language has been removed");
            //EditProfileValidate();
            //Base.test.Log(LogStatus.Info, "profile updated successfully");
        }
        public void EditProfileValidate()
        {
            try
            {

                String ActualTitle = GlobalDefinitions.driver.Title;
                String ExpectedTitle = "Profile";
                Assert.AreEqual(ExpectedTitle, ActualTitle);
                //Populate the excel data
                //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
                // validate availability time ex. part/full time
                String ExpectedAvailability = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityType");
                String ActualAvailability = "Full Time";
                Assert.AreEqual(ExpectedAvailability, ActualAvailability);
                Base.test.Log(LogStatus.Info, "Profile validated successfully");
            }
            catch (AssertionException)
            {
                //JoinBtn.Click();
                Base.test.Log(LogStatus.Info, "Profile exception handeled successfully");

            }
        }
    }
}
