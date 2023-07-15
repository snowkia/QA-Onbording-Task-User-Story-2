using NUnit.Framework;
using OpenQA.Selenium;
using Project_QAMars.Utilities;

namespace Project_QAMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        private static IWebElement AddNew => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement AddLanguageTextBox   => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseLanguageLevel  => driver.FindElement(By.Name("level"));
        private static IWebElement AddButton            => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement newLanguage          => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement newLevel             => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement PencilIcon           => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement UpdateLangauge       => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private static IWebElement UpdateLevel          => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private static IWebElement UpdateButton         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement createdLanguage      => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement createdLevel         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement deleteLanguageTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
        private static IWebElement deletedElement       => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedLevel         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement languageDeleteIcon   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));


        //Adding New language to the language list
        public void AddLanguage(string language, string level)
        {
            //Click on AddNew button
            AddNew.Click();
            Thread.Sleep(1000);
            //Enter the language that needs to be added
            AddLanguageTextBox.SendKeys(language);
            //Choose the language level
            ChooseLanguageLevel.Click();
            ChooseLanguageLevel.SendKeys(level);
            //Click on Add button
            AddButton.Click();
            Thread.Sleep(2000);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(1000);
            //get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            //verify the expected message text
            string expectedMessage1 = language+ " has been added to your languages";
            string expectedMessage2 = "Please enter language and level";
            string expectedMessage3 = "This language is already exist in your language list.";
            string expectedMessage4 = "Duplicated data";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
        }
        public string getLanguage()
        {
            return newLanguage.Text;
        }

        public string getLevel()
        {
            return newLevel.Text;
        }

        //Updating an already existing language in the language list 
        public void UpdateLanguage(string language, string level)
        {
            //Click on pencilIcon
            PencilIcon.Click();
            //Edit the language
            UpdateLangauge.Clear();
            UpdateLangauge.SendKeys(language);
           //Choose the level from the drop down
            UpdateLevel.Click();
            Thread.Sleep(1000);
            UpdateLevel.SendKeys(level);
            //Click on Update button
            UpdateButton.Click();
            Thread.Sleep(2000);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(1000);
            //get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            //verify the expected message text
            string expectedMessage1 = language + " has been updated to your languages";
            string expectedMessage2 = "Please enter language and level";
            string expectedMessage3 = "This language is already added to your language list.";
           
            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));
        }
        public string getEditedLanguage()
        {
             return createdLanguage.Text;
        }
        public string getEditedLevel()
        {
             return createdLevel.Text;
        }

        //Deleting a language from the language list
        public void DeleteLanguage(string language, string level)
        {
            deleteLanguageTab.Click();
            var deleteIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{language}'] and td[text()='{level}']]]//i[@class='remove icon']"));
            // Find and click the delete icon in the row
            deleteIcon.Click();
            Thread.Sleep(2000);
            //get the text of the message element
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(1000);
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            //verify the expected message text
            string expectedMessage1 = language + " has been deleted from your languages";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1));
        }
        public string GetDeletedElement()
        {
            return deletedElement.Text;
        }
        public string GetDeletedLevel() 
        {
            return deletedLevel.Text;
        }
    }
}



    

