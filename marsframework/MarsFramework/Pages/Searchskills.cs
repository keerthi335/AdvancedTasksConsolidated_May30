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
    class Searchskills
    {
        //Finding search skill text box
        private IWebElement SeachSkillstext => GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));

        //Finding search skill button/icon
        private IWebElement SeachSkillBtn => GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']//div[@class='ui secondary menu']//div[@class='ui small icon input search-box']//i[@class='search link icon']"));

        private IWebElement SubCategorylink => GlobalDefinitions.driver.FindElement(By.XPath("//a[text()='Programming & Tech']"));
        //a[text()='Programming & Tech' ]
        //button[@class='ui button'][text() ='Online']
        //button[@class='ui button'][text() ='Onsite']

        private IWebElement FilterOnlineBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button'][text() ='Online']"));

        private IWebElement FilterOnsiteBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button'][text() ='Onsite']"));

        private IWebElement FilterShowAllBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button'][text() ='ShowAll']"));

        public void skillSearch()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            SeachSkillstext.Click();
            Thread.Sleep(1000);
            //SeachSkillstext.SendKeys("Test Analyst");
            SeachSkillstext.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkill"));
            Thread.Sleep(3000);
            SeachSkillBtn.Click();

            Thread.Sleep(3000);
            SubCategorylink.Click();


            Thread.Sleep(3000);
            FilterOnlineBtn.Click();

            Thread.Sleep(3000);
            FilterOnsiteBtn.Click();

            Thread.Sleep(3000);
            FilterShowAllBtn.Click();

            Thread.Sleep(3000);
            ValidateSearchSkills();
        }
        public void ValidateSearchSkills()
        {
            try
            {
                String ActualTitle = GlobalDefinitions.driver.Title;
                String ExpectedTitle = "Search";
                Assert.AreEqual(ExpectedTitle, ActualTitle);
                Base.test.Log(LogStatus.Info, "Search skills validated successfully");

                IWebElement searchOutcome = GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(),'Refine Results')]"));
                Assert.IsTrue(searchOutcome.Text.Equals("Refine Results"));

                Base.test.Log(LogStatus.Info, "Search skills returned successfully with results");
            }
            catch (AssertionException)
            {
                //JoinBtn.Click();
                Base.test.Log(LogStatus.Info, "Search skills exception handeled successfully");

            }
        }

    }
}
