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
    class Skills
    {
        public void AddSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Skills");


            By WaitCondition = By.XPath("//a[contains(text(),'Skills')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click(); // To click on skills icon


            GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click(); // To click on add new icon to update details of skills

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill")); //To click on name of the skills box and enter the skill name


            GlobalDefinitions.driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill_Level"));

            GlobalDefinitions.driver.FindElement(By.XPath("(//input[contains(@class,'ui teal button ')])[1]")).Click(); //To save the skills details to add



            By WaitCondition_ = By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click(); // To click on add new icon to update details of skills

            By WaitCondition_C = By.XPath("//input[contains(@placeholder,'Add Skill')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition_C, 60);


            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Skill")); //To click on name of the skills box and enter the skill name


            GlobalDefinitions.driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Skill_Level"));

            GlobalDefinitions.driver.FindElement(By.XPath("(//input[contains(@class,'ui teal button ')])[1]")).Click(); //To save the skills details to add


            var Skill = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//table[@class='ui fixed table']/tbody[1]/tr[1]/td[1]")).Text;
            var Skill_ = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//table[@class='ui fixed table']/tbody[2]/tr[1]/td[1]")).Text;
            string ExcelSkill = GlobalDefinitions.ExcelLib.ReadData(2, "skill");
            string ExcelSkill_ = GlobalDefinitions.ExcelLib.ReadData(4, "skill");
            if (Skill == ExcelSkill && Skill_ == ExcelSkill_)
            {

                Base.test.Log(LogStatus.Info, "Skill has been added");
                Assert.True(true);
            }


        }

        public void UpdateSkill()
        {
            By WaitCondition = By.XPath("//tbody[1]//tr[1]//td[3]//span[1]//i[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//tbody[1]//tr[1]//td[3]//span[1]//i[1]")).Click();

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]")).Clear();

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill")); //To click on name of the skills box and enter the other skill name

            GlobalDefinitions.driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill_Level"));


            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();

            var Skill = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//table[@class='ui fixed table']/tbody[1]/tr[1]/td[1]")).Text;

            string ExcelSkill = GlobalDefinitions.ExcelLib.ReadData(3, "skill");
            if (Skill == ExcelSkill)
            {
                Base.test.Log(LogStatus.Info, "Updated Skill successfully");
                Assert.True(true);
            }

        }

        public void DeleteSkill()
        {

            By WaitCondition = By.XPath("(//i[contains(@class,'remove icon')])[2]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);
            GlobalDefinitions.driver.FindElement(By.XPath("(//i[contains(@class,'remove icon')])[2]")).Click();

            var Skill = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(.,'Java Programming')]")).Text;
            string ExcelSkill = GlobalDefinitions.ExcelLib.ReadData(4, "Skill");
            if (Skill != ExcelSkill)
            {
                Base.test.Log(LogStatus.Info, "Skill has been deleted");
                Assert.True(true);

            }


        }

    }
}
