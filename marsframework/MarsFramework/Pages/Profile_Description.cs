using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Profile_Description
    {
        public void AddDescription()
        {
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Profile");

            By WaitCondition_ = By.XPath("//i[@class='outline write icon']");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='outline write icon']")).Click();

            IWebElement Description = GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name='value']"));

            By WaitCondition = By.XPath("//textarea[@name='value']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            Description.Clear();

            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(@type,'button')]")).Click();
            Assert.That(Description != null);
            Base.test.Log(LogStatus.Info, "Added Description successfully");

        }
    }
}
