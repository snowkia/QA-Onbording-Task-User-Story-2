using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Project_QAMars.Utilities;

namespace Project_QAMars.Pages
{
    public class LoginPage : CommonDriver
    {
       private static IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
       private static IWebElement Email => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
       private static IWebElement Password => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
       private static IWebElement RememberMe => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
       private static IWebElement loginbutton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        public void LoginSteps()
        { 
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            SignInButton.Click();
            Thread.Sleep(1000);
            Email.SendKeys("mothercowchicken@gmail.com");
            Password.SendKeys("Mvp123123");  
            RememberMe.Click();
            loginbutton.Click();
            Thread.Sleep(1000);
        }

    }
}
