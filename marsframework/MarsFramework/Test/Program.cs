using MarsFramework.Pages;
using NUnit.Framework;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void SignIn()
            {
                test = extent.StartTest("Signin test started");
                var mySignin = new SignIn();
                mySignin.LoginSteps();
                Thread.Sleep(3000);
                mySignin.validateSteps();
                Thread.Sleep(3000);
            }
            [Test, Order(3)]
            public void SignUp()
            {
                test = extent.StartTest("Signup test started");
                var mySignup = new SignUp();
                mySignup.register();
                Thread.Sleep(10000);
            }
            [Test, Order(2)]
            public void ProfilePage()
            {
                test = extent.StartTest("Profile test started");
                var myProfile = new Profile();
                myProfile.EditProfile();
                Thread.Sleep(10000);
                myProfile.EditProfileValidate();

            }

            [Test, Order(4)]
            public void SearchskillPage()
            {
                test = extent.StartTest("Search test started");
                var mySearch = new Searchskills();
                mySearch.skillSearch();
                Thread.Sleep(10000);
            }

            [Test, Order(5)]
            public void SkillPage()
            {
                test = extent.StartTest("Skills test started");
                Skills skills = new Skills();
                skills.AddSkill();
                skills.UpdateSkill();
                skills.DeleteSkill();

            }

            [Test, Order(6)]
            public void EducationPage()
            {
                test = extent.StartTest("Education test started");
                Education education = new Education();
                education.AddEducation();
                education.UpdateEducation();
                education.DeleteEducation();
            }
            [Test, Order(7)]
            public void CertificationPage()
            {
                test = extent.StartTest("Certification test started");
                Certification certification = new Certification();
                certification.AddCertification();
                certification.UpdateCertification();
                certification.DeleteCertification();
            }
            [Test, Order(8)]
            public void Profile()
            {
                test = extent.StartTest("Profile Description test started");
                Profile_Description profile = new Profile_Description();
                profile.AddDescription();
            }

            [Test, Order(9)]
            public void ShareSkillTest()
            {
                test = extent.StartTest("ShareSkill test started");
                ShareSkills shareSkill = new ShareSkills();
                shareSkill.EnterShareSkill();

                bool Result = shareSkill.ValidateShareSkill(Global.GlobalDefinitions.driver);
                Assert.IsTrue(Result);
            }

            [Test, Order(10)]
            public void EditListingTest()
            {
                test = extent.StartTest("Edit Listing test started");
                ManageListings manageListings = new ManageListings();
                manageListings.EditListings();

                bool EditResult = manageListings.ValidateEdit(Global.GlobalDefinitions.driver);
                Assert.IsTrue(EditResult);
            }

            [Test, Order(11)]
            public void DeleteListingTest()
            {
                test = extent.StartTest("Delete Listing test started");
                ManageListings manageListings = new ManageListings();
                manageListings.DeleteListings();

                bool DelResult = manageListings.ValidateDelete(Global.GlobalDefinitions.driver);
                Assert.IsTrue(DelResult);
            }

            [Test, Order(12)]
            public void ChangePassword()
            {
                test = extent.StartTest("Change Password test started");
                Account account = new Account();
                account.ChangePassword();

                bool PwdChgResult = account.ValidateChangePassword(Global.GlobalDefinitions.driver);
                Assert.IsTrue(PwdChgResult);
            }
        }
    }
}