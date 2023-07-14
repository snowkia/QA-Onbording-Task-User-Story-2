using OpenQA.Selenium.DevTools.V112.Browser;
using Project_QAMars.Utilities;
using TechTalk.SpecFlow;

namespace Project_QAMars.Hooks
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        
        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Close();
        }
    }
}