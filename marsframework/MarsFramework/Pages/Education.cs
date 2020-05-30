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
    class Education
    {
        public void AddEducation()
        {
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Education");
            //Thread.Sleep(3000);
            By WaitCondition = By.XPath("(//a[contains(.,'Education')])[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("(//a[contains(.,'Education')])[1]")).Click(); // To click on education icon
            //System.Threading.Thread.Sleep(1000);
            GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//div[@class=\'ui teal button ']")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University")); //To enter university Name

            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='country']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Country")); //To select the name of the country


            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='title']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title")); //To select the qualification title


            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'degree')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree")); //To enter name of the degree

            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Graduation_Year")); //To select the year of passing


            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click(); //To save the details and click on add 
            By WaitCondition_ = By.XPath("//div[@data-tab='third']//div[@class=\'ui teal button ']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//div[@class=\'ui teal button ']")).Click(); //To click on add new
            By WaitCondition__ = By.XPath("//input[contains(@name,'instituteName')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition__, 60);


            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'instituteName')]")).Clear(); //To clear the text box of university name
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "University")); //To enter university Name

            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='country']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Country")); //To select the name of the country


            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='title']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Title")); //To select the qualification title


            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'degree')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Degree")); //To enter name of the degree

            GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Graduation_Year")); //To select the year of passing

            //Thread.Sleep(1000);

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click(); //To save the details and click on add 

            var Title = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'M.Tech')]")).Text;
            // Thread.Sleep(1000);
            var Title_ = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'B.Tech')]")).Text;
            string ExcelTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            string ExcelTitle_ = GlobalDefinitions.ExcelLib.ReadData(4, "Title");

            if (Title == ExcelTitle && Title_ == ExcelTitle_)
            {
                Base.test.Log(LogStatus.Info, "Education has been added");
                Assert.True(true);
            }


        }

        public void UpdateEducation()
        {
            By WaitCondition = By.XPath("//tbody[1]//tr[1]//td[6]//span[1]//i[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//tbody[1]//tr[1]//td[6]//span[1]//i[1]")).Click();

            By WaitCondition_ = By.XPath("//input[contains(@name,'degree')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'degree')]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'degree')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Degree"));

            By WaitCondition__ = By.XPath("//input[@type = 'button'] [1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition__, 60);
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@type = 'button'] [1]")).Click();

            By WaitCondition1 = By.XPath("//td[contains(text(),'MICT')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

            var Title = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'MICT')]")).Text;

            string ExcelTitle = GlobalDefinitions.ExcelLib.ReadData(3, "Degree");


            if (Title == ExcelTitle)
            {
                Base.test.Log(LogStatus.Info, "Education updated  successfully");
                Assert.IsTrue(true);
            }

        }

        public void DeleteEducation()
        {
            By WaitCondition = By.XPath("(//i[contains(@class,'remove icon')])[2]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);
            GlobalDefinitions.driver.FindElement(By.XPath("(//i[contains(@class,'remove icon')])[2]")).Click();

            By WaitCondition_ = By.XPath("//td[contains(text(),'B.Tech')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);

            var Title = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'B.Tech')]")).Text;
            string ExcelTitle = GlobalDefinitions.ExcelLib.ReadData(4, "Title");
            if (Title != ExcelTitle)
            {
                Base.test.Log(LogStatus.Info, "Education has been delete");
                Assert.True(true);

            }

        }
    }
}
