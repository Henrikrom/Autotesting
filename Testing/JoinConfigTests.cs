using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace Testing
{
    class JoinConfigTests
    {
        public static void addRegexRule(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Matching-Rules", test.url, "Join"));

            test.driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            test.driver.FindElement(By.XPath("//label[text()='Name ']")).Click();
            Actions insertName = new Actions(test.driver);
            insertName.SendKeys("testRegexRule").Perform();

            test.driver.FindElement(By.XPath("//div[text()='Skype URI in Headers']")).Click();
            test.driver.FindElement(By.XPath("//div[text()='Regex Rule']")).Click();

            test.driver.FindElement(By.XPath("//div[text()='Build Regular Expression']")).Click();

            test.clickObject("div", "class", "dropdown flex-1");
            test.driver.FindElement(By.XPath("//div[@value='Generic numeric@domain']")).Click();

            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();
            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();

            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addOneTimeVMR(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/VMR-Pools", test.url, "Join"));
            test.clickObject("div", "class", "button button-blue");

            test.driver.FindElement(By.XPath("//label[text()='Name']//parent::div")).Click();
            Actions insertName = new Actions(test.driver);
            insertName.SendKeys("OneTimeVMRtest").Perform();

            test.driver.FindElement(By.XPath("//label[text()='Description']//parent::div")).Click();
            Actions insertdesc = new Actions(test.driver);
            insertdesc.SendKeys("testDescription").Perform();

            test.driver.FindElement(By.XPath("//label[text()='MCU']//parent::div")).Click();
            test.driver.FindElement(By.XPath("//div[text()='testPexip']")).Click();
            
            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[1]/div/div/div[2]/form/div[4]/div/div[1]/div[1]")).Click();
            test.driver.FindElement(By.XPath("//div[text()='One Time Vmr']")).Click();

            test.driver.FindElement(By.XPath("//label[text()='Range Start']//parent::div")).Click();
            Actions start = new Actions(test.driver);
            start.SendKeys(Keys.Backspace);
            start.SendKeys(test.oneTimeVMRrange[0]).Perform();

            test.driver.FindElement(By.XPath("//label[text()='Range End']//parent::div")).Click();
            Actions end = new Actions(test.driver);
            end.SendKeys(Keys.Backspace);
            end.SendKeys(test.oneTimeVMRrange[1]).Perform();

            test.driver.FindElement(By.XPath("//label[text()='Domain']//parent::div")).Click();
            Actions domain = new Actions(test.driver);
            domain.SendKeys("synergyplay.com").Perform();

            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();

            test.clickObject("div", "class", "switch");

            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void conferenceSettingsTests(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Conference-Settings", test.url, "Join"));

            test.driver.FindElement(By.XPath("//label[contains(.,'IVR Dial-In')]")).Click();
            IWebElement exhangeResourceEmail =  test.driver.FindElement(By.XPath("//label[contains(.,'Exchange Resource')]"));
            exhangeResourceEmail.Click();
            Actions action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[0]).Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Conference Start Buffer')]")).Click();
            action = new Actions(test.driver);            
            action.SendKeys(test.conferenceSettings[1]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Conference End Buffer')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[1]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Retry Count On Dial Outs')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[1]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Retry Delay Between Each')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[1]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Hide Non-Video')]")).Click();
            test.driver.FindElement(By.XPath("//label[contains(.,'Disconnect Autodialled')]")).Click();

            test.driver.FindElement(By.XPath("//label[contains(.,'Enable End Of Conference')]")).Click();

            test.driver.FindElement(By.XPath("//label[contains(.,'Conference End Warning')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[2]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Conference Ending Text')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[3]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Conference Cancelled')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[4]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Message Display')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[1]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Message Display Mode In Video')]")).Click();
            test.driver.FindElement(By.XPath("//label[contains(.,'Message Display Mode In Chat')]")).Click();
            
            test.driver.FindElement(By.XPath("//label[contains(.,'Show Warnings')]")).Click();
            action = new Actions(test.driver);
            for (int i = 0; i < 10; i++)
            {
                action.SendKeys(Keys.Backspace);
            }
            action.SendKeys(test.conferenceSettings[5]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Meeting Manager Display')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[6]);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Internal Email')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[7]);
            action.Perform();


            IWebElement DialInfo = test.driver.FindElement(By.XPath("//div[@class='config-box-body']"));
            DialInfo.Click();
            
            
            var switches = DialInfo.FindElements(By.XPath("//div[@class='switch']"));
            for (int i = 0; i < 11; i++)
            {           
                int a = switches.Count;
                switches[a-1-i].Click();
            }

            test.driver.FindElement(By.XPath("//label[contains(.,'Send Dial-In Info X')]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.conferenceSettings[1]);
            action.Perform();

            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addDebookPolicy(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Policies", test.url, "Join"));
            test.clickObject("div", "class", "button button-blue");

            test.driver.FindElement(By.XPath("//label[contains(.,'Policy Name')]")).Click();
            Actions action = new Actions(test.driver);
            action.SendKeys(test.policyName);
            action.Perform();

            test.driver.FindElement(By.XPath("//label[contains(.,'Automatic')]")).Click();
            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[3]/div/div[3]/div[1]")).Click();

            test.clickObject("div", "id", "apply-all-changes-button");
        }

    }
}
