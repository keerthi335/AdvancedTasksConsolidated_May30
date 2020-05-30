using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        #region  Initialize Web Elements 
        //Finding the Sign Link
        private IWebElement SignIntab => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));
        // Finding the Email Field
        private IWebElement Email => GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        //Finding the Password Field
        private IWebElement Password => GlobalDefinitions.driver.FindElement(By.XPath("//INPUT[@type='password']"));
        //Finding the Login Button
        private IWebElement SignInBtn => GlobalDefinitions.driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
        //Finding Join button
        private IWebElement JoinBtn => GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='pointerCursor'][text()=' Join']"));

        #endregion

        internal void LoginSteps()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Navigate to the SkillSwapPro Website
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Click on Signin button            
            SignIntab.Click();
            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));
            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            //click SignIn Button
            SignInBtn.Click();
            Thread.Sleep(5000);
        }

        internal void validateSteps()
        {
            // Assert to verify that the sign out button is visible
            try
            {
                IWebElement element = GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui green basic button'][text()='Sign Out']"));
                Assert.IsTrue(element.Text.Equals("Sign Out"));
                Base.test.Log(LogStatus.Info, "Signed in successfully");
            }
            catch (Exception)
            {
                JoinBtn.Click();
            }
        }
    }
}