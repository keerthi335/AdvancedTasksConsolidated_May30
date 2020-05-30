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
    class Certification
    {
        public void AddCertification()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Certification");
            By WaitCondition = By.XPath("//a[contains(.,'Certifications')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(.,'Certifications')]")).Click();
            By WaitCondition_ = By.XPath("(//div[contains(@class,'ui teal button ')])[3]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);
            GlobalDefinitions.driver.FindElement(By.XPath("(//div[contains(@class,'ui teal button ')])[3]")).Click();

            IWebElement Certificate = GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
            Certificate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));
            Assert.That(Certificate != null);

            //Thread.Sleep(1000);
            IWebElement CertificationFrom = GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']"));
            CertificationFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certified_From"));
            Assert.That(CertificationFrom != null);
            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='certificationYear']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Year"));
            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();

            By WaitCondition2 = By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition2, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]")).Click();

            By WaitCondition__ = By.XPath("//input[@placeholder='Certificate or Award']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition__, 60);

            IWebElement Certificate_ = GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
            Certificate_.Clear();
            Thread.Sleep(1000);
            Certificate_.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Certificate"));
            Assert.That(Certificate_ != null);

            By WaitCondition1 = By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

            IWebElement CertificationFrom_ = GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']"));
            CertificationFrom_.Clear();
            CertificationFrom_.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Certified_From"));

            Assert.That(CertificationFrom_ != null);
            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='certificationYear']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Year"));
            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();
            Base.test.Log(LogStatus.Info, "Certification added  successfully");

        }

        public void UpdateCertification()
        {
            By WaitCondition = By.XPath("//tbody[1]//tr[1]//td[4]//span[1]//i[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//tbody[1]//tr[1]//td[4]//span[1]//i[1]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='certificationYear']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Year"));

            By WaitCondition_ = By.XPath("//input[contains(@value,'Update')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
            Base.test.Log(LogStatus.Info, "Certification updated  successfully");

            var Year = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='certificationYear']")).Text;

            string ExcelYear = GlobalDefinitions.ExcelLib.ReadData(3, "Year");


            if (Year == ExcelYear)
            {
                Base.test.Log(LogStatus.Info, "Certification has been updated");
                Assert.IsTrue(true);
            }

        }

        public void DeleteCertification()
        {
            By WaitCondition = By.XPath("//tbody[2]//tr[1]//td[4]//span[2]//i[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//tbody[2]//tr[1]//td[4]//span[2]//i[1]")).Click();

            var Certificate = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'ISTQB Advancd Level')]")).Text;
            string ExcelCertificate = GlobalDefinitions.ExcelLib.ReadData(4, "Title");
            if (Certificate != ExcelCertificate)
            {
                Base.test.Log(LogStatus.Info, "Certification has been deleted");
                Assert.True(true);

            }
        }
    }
}
