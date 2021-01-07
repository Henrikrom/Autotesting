using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace Testing
{
    class AutoTesting
    {
        public IWebDriver driver;
        public string APIkey { get; set; }
        public string url { get; set; }
        public string IP { get; set; }
        public string[] connectionGraph { get; set; }        
        public string[] connectionEWS { get; set; }
        public string[] connectionPexip { get; set; }
        public string addRoomManuallyName { get; set; }
        public string[] oneTimeVMRrange { get; set; }
        public string[] addVideoSystemCisco { get; set; }
        public string[] conferenceSettings { get; set; }
        public string policyName { get; set; }
        public string[] connectionThingsWeb { get; set; }
        public string[] connectionQuickChannel { get; set; }


        public AutoTesting()
        {            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void goToConfigTool()
        {
            driver.Navigate().GoToUrl(url);
            this.clickObject("button", "id", "details-button");
            this.clickObject("a", "id", "proceed-link");
        }

        public void clickObject(string tagname, string attribute, string value)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format("//{0}[@{1}='{2}']", tagname, attribute, value)));
            element.Click();
        }

        public void insertText(string tagname, string attribute, string value, string text)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format("//{0}[@{1}='{2}']", tagname, attribute, value)));
            element.Click();
            element.SendKeys(text);
        }

        public void deployConfig()
        {
            driver.Navigate().GoToUrl(string.Format("{0}/Config-Tool/Configuration-Versions", url));

            this.clickObject("div", "class", "checkbox checkbox-icon");
            this.clickObject("div", "class", "button button-green");

            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void agreeToEULA()
        {
            this.clickObject("div", "class", "toggle-button off");

            this.clickObject("button", "id", "apply-all-changes-button");
        }

    }
}
