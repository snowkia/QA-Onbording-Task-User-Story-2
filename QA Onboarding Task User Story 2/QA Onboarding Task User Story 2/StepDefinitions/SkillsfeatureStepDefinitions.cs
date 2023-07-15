using System;
using NUnit.Framework;
using System.Reflection.Emit;
using OpenQA.Selenium.Chrome;
using Project_QAMars.Pages;
using Project_QAMars.Utilities;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace Project_QAMars.StepDefinitions
{
    [Binding]
    public class SkillsfeatureStepDefinitions : CommonDriver
    {
        SkillsPage SkillsPageObj;
        LoginPage LoginPageObj;
        public SkillsfeatureStepDefinitions()
        {
            SkillsPageObj = new SkillsPage();
            LoginPageObj = new LoginPage();
        }

        [Given(@"User is logged into Skillswap website successfully\.")]
        public void GivenUserIsLoggedIntoSkillswapWebsiteSuccessfully_()
        {
            //Login page object initialization and definition
            LoginPageObj.LoginSteps();
        }

        [When(@"Adding new '([^']*)' and '([^']*)' to the skill list")]
        public void WhenAddingNewAndToTheSkillList(string skill, string skillLevel)
        {
            //Adding new skill to the skill list
            SkillsPageObj.AddSkills(skill, skillLevel);
        }

        [Then(@"New skill record with '([^']*)' and '([^']*)' are added successfully\.")]
        public void ThenNewSkillRecordWithAndAreAddedSuccessfully_(string skill, string skillLevel)
        {   
            //Assertion of added skills
            string newSkill = SkillsPageObj.getSkill();
            string newSkillLevel = SkillsPageObj.getSkillLevel();

            if (skill == newSkill && skillLevel == newSkillLevel)
            {
                Assert.AreEqual(skill, newSkill, "Actual skill and expected skill do not match.");
                Assert.AreEqual(skillLevel, newSkillLevel, "Actual skill level and expected skill level do not match");
            }
            else
            {
                Console.WriteLine("Check Error");
            }
        }

        [When(@"Update '([^']*)' and '([^']*)' on an existing skill record\.")]
        public void WhenUpdateAndOnAnExistingSkillRecord_(string skill, string skillLevel)
        {
            //update an existing Skill in the Skill list  
            SkillsPageObj.UpdateSkills(skill, skillLevel);
        }

        [Then(@"The skill record should been updated '([^']*)' and '([^']*)' Successfully")]
        public void ThenTheSkillRecordShouldBeenUpdatedAndSuccessfully(string skill, string skillLevel)
        {
            //Assertion of updated Skill
            string newUpdatedSkill = SkillsPageObj.getUpdatedSkill();
            string newUpdatedSkillLevel = SkillsPageObj.getUpdatedSkillLevel();

            if (skill == newUpdatedSkill && skillLevel == newUpdatedSkillLevel)
            {
                Assert.AreEqual(skill, newUpdatedSkill, "Updated skill and expected skill do not match.");
                Assert.AreEqual(skillLevel, newUpdatedSkillLevel, "Updated Skilllevel and created skilllevel do not match");
            }
            else
            {
                Console.WriteLine("Check error");
            }
        }

        [When(@"Delete the record '([^']*)' and '([^']*)' successfully")]
        public void WhenDeleteTheRecordAndSuccessfully(string skill, string skillLevel)
        {
            SkillsPageObj.DeleteSkill(skill, skillLevel);
        }

        [Then(@"The record '([^']*)' and '([^']*)' should deleted successfully")]
        public void ThenTheRecordAndShouldDeletedSuccessfully(string skill, string skillLevel)
        {
            //Assertion of deleted skill and level from the list
            string deletedSkillElement = SkillsPageObj.GetDeletedSkillElement();
            string deletedSkillLevel = SkillsPageObj.GetDeletedSkillLevel();

            if (skill == deletedSkillElement && skillLevel == deletedSkillLevel)
            {
                Assert.AreNotEqual(skill, deletedSkillElement, "Deleted language and expected language does not match");
                Assert.AreNotEqual(skillLevel, deletedSkillLevel, "Deleted leven and expected level does not match");
            }
            else
            {
                Console.WriteLine("Check Error");
            }
        }
    }
}
