using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Debugger;
using Project_QAMars.Utilities;
using TechTalk.SpecFlow;

namespace Project_QAMars.Pages
{
    public class SkillsPage : CommonDriver
    {
        private static IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement AddNew => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement AddSkillTextBox => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseSkillLevel => driver.FindElement(By.Name("level"));
        private static IWebElement AddButton         =>driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private static IWebElement newSkill          => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement newSkillLevel     => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement UpdateSkillsTab   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement PenIcon        =>  driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement UpdateSkillTextBox=> driver.FindElement(By.Name("name"));
        private static IWebElement UpdateSkillLevel  => driver.FindElement(By.Name("level"));
        private static IWebElement UpdateButton      => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement newUpdatedSkill   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement newUpdatedSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement DeleteSkillsTab   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement deleteIcon         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        private static IWebElement deletedSkillElement => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedSkillLevel  => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

        public void AddSkills(string skill, String skillLevel)
        {
            //Click on Skill tab
            SkillsTab.Click();
            Thread.Sleep(1000);

            //Click on AddNew button
            AddNew.Click();
            Thread.Sleep(1000);

            //Enter the skills that needs to be added
            AddSkillTextBox.SendKeys(skill);
            Thread.Sleep(1000);

            //Choose the skill level
            ChooseSkillLevel.Click();
            Thread.Sleep(1000);
            ChooseSkillLevel.SendKeys(skillLevel);

            //Click onn Add button
            AddButton.Click();
            Thread.Sleep(1000);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            //get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            //verify the expected message text
            string expectedMessage1 = skill + " has been added to your skills";
            string expectedMessage2 = "Please enter skill and experience level";
            string expectedMessage3 = "This skill is already exist in your skill list.";
            string expectedMessage4 = "Duplicated data";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
        }
        public string getSkill()
        {
            return newSkill.Text;
        }
        public string getSkillLevel()
        {
            return newSkillLevel.Text;
        }
        public void UpdateSkills(string skill, string skillLevel)
        {
            //Click on Skill tab
            UpdateSkillsTab.Click();
            Thread.Sleep(1000);

            //Click on Pencil Icon
            PenIcon.Click();
            Thread.Sleep(1000);

            //Update the skill
            UpdateSkillTextBox.Clear();
            Thread.Sleep(1000);
            UpdateSkillTextBox.SendKeys(skill);
            Thread.Sleep(1000);

            //Choose the level from the drop down
            UpdateSkillLevel.Click();
            Thread.Sleep(1000);
            UpdateSkillLevel.SendKeys(skillLevel);
            Thread.Sleep(1000);

            //Click on update button
            UpdateButton.Click();
            Thread.Sleep(2000);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            //get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);
            
            //verify the expected message text
            string expectedMessage1 = skill + " has been updated to your skills";
            string expectedMessage2 = "Please enter skill and experience level";
            string expectedMessage3 = "This skill is already added to your skill list.";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));
        }
        public string getUpdatedSkill()
        {
       return newUpdatedSkill.Text;
        }
        public string getUpdatedSkillLevel()
        {
        return newUpdatedSkillLevel.Text;
        }

        //Deleting a Skill from the Skill list
        public void DeleteSkill(string skill, string skillLevel)
        {
            try
            {
                DeleteSkillsTab.Click();
                var deleteIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{skill}'] and td[text()='{skillLevel}']]]//i[@class='remove icon']"));
                // Find and click the delete icon in the row
                deleteIcon.Click();
                Thread.Sleep(2000);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                Thread.Sleep(1000);

                //get the text of the message element
                string actualMessage = messageBox.Text;
                Console.WriteLine(actualMessage);

                //verify the expected message text
                string expectedMessage1 = skill + " has been deleted";

                Assert.That(actualMessage, Is.EqualTo(expectedMessage1));
            }
            catch (NoSuchElementException)
            {

                Console.WriteLine("Record not found");

            }
        }
        
        public string GetDeletedSkillElement()
        {
             return deletedSkillElement.Text;
        }
        public string GetDeletedSkillLevel()
        {
            return deletedSkillLevel.Text;
        }
    }
}
