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
    static class GeneralSettingsTests
    {
        public static void validateAPIkey(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/License", test.url, "General-Settings"));
            test.insertText("input", "id", "control_1000", test.APIkey);
            test.clickObject("input", "id", "control_1000");
            test.clickObject("button", "type", "button");            

            string resultOK = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div[6]/div/div")).Text;
            string resultError = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div[5]/div")).Text;

            do
            {
                Thread.Sleep(500);
                if (resultError.Contains("Problem"))
                {
                    Console.WriteLine("Problem with APIkey validation");
                    break;
                }
            }
            while (resultOK != "OK");

            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addConnectionGraph(AutoTesting test)
        {            
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Integrations-Settings", test.url, "General-Settings"));
            test.clickObject("button", "class", "button button-blue");
            test.clickObject("div", "class", "dropdown flex-1");
            IWebElement list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='MS Graph API']")).Click();
            test.insertText("input", "id", "txtName", test.connectionGraph[0]);

            IWebElement clientID = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[2]"));
            clientID.Click();
            clientID = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[2]/input"));
            clientID.SendKeys(test.connectionGraph[1]);

            IWebElement tenantID = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[3]"));
            tenantID.Click();
            tenantID = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[3]/input"));
            tenantID.SendKeys(test.connectionGraph[2]);

            IWebElement clientSecret = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[4]/input"));
            clientSecret.Click();
            clientSecret.SendKeys("N-6drz7G8v84c1");

            Actions action = new Actions(test.driver);
            action.KeyDown(Keys.Control);
            action.KeyDown(Keys.LeftAlt);
            action.SendKeys(Keys.Semicolon);
            action.KeyUp(Keys.Control);
            action.KeyUp(Keys.LeftAlt);
            action.SendKeys(Keys.ArrowLeft);
            action.SendKeys(Keys.Backspace);
            action.SendKeys(Keys.ArrowRight);
            action.Build().Perform();

            clientSecret.SendKeys(".INGt5DSrIM_pl_92qS");

            test.clickObject("div", "class", "button button-yellow");
            
            IWebElement testedBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[4]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (testedBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);

            test.clickObject("div", "class", "button button-blue");

            test.clickObject("div", "id", "apply-all-changes-button");

            
            var table = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/table"));
            var tr = table.FindElements(By.TagName("tr"));
            var edits = table.FindElements(By.XPath("//td[@class='edit']"));
            for (int i = 1; i < tr.Count; i++)
            {
                var tds = tr[i].FindElements(By.XPath("td"));
                if (tds[0].Text == test.connectionGraph[0]) { edits[i-1].Click(); }
            }         

            test.clickObject("div", "class", "button button-yellow");

            testedBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[4]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (testedBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);

            test.clickObject("div", "class", "button button-blue");


            /*-----------------------------------------ADD API INTEGRATION------------------------------------------*/
            
            IWebElement APIbutton = test.driver.FindElement(By.XPath("//div[@class='buttonRow']"));
            APIbutton.FindElement(By.XPath("//div[@class='button button-blue']")).Click();

            test.clickObject("div", "class", "dropdown flex-1");
            test.clickObject("div", "value", "1");

            IWebElement connectionDropDown = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div[1]/div[1]"));
            connectionDropDown.Click();

            IWebElement graph = test.driver.FindElement(By.XPath(string.Format("//div[text()='{0}']", test.connectionGraph[0])));
            graph.Click();

            IWebElement insertEmail = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[3]/div/div[5]/div[2]/input"));
            insertEmail.SendKeys(test.connectionGraph[4]);

            IWebElement save = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[3]/div[1]"));
            save.Click();

            
            
            IWebElement APItable = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[2]/table"));
            var rows = APItable.FindElements(By.TagName("tr"));
            var switches = APItable.FindElements(By.XPath("//div[@class='switch']"));
            for (int i = 0; i < rows.Count - 1; i++)
            {
                var td = rows[i + 1].FindElements(By.XPath("td"));
                if (td[1].Text == test.connectionGraph[0]) { switches[i].Click(); }
            }
            
            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addRoomAuto(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Rooms", test.url, "General-Settings"));
            test.clickObject("div", "class", "button button-blue");
            test.clickObject("div", "id", "label_control_64");
            
            Actions action = new Actions(test.driver);
            action.SendKeys(test.addRoomManuallyName).Build().Perform();

            test.clickObject("div", "class", "checkbox checkbox-icon");
            IWebElement element = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div[3]/div[2]/div"));
            element.Click();
            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addConnectionEWS(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Integrations-Settings", test.url, "General-Settings"));
            test.clickObject("button", "class", "button button-blue");
            
            test.clickObject("div", "class", "dropdown flex-1");
            IWebElement list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='MS EWS API']")).Click();
            
            test.insertText("input", "id", "txtName", test.connectionEWS[0]);

            test.insertText("input", "id", "txtEwsUrl", test.connectionEWS[1]);

            test.insertText("input", "id", "txtEwsUsername", test.connectionEWS[2]);

            test.insertText("input", "id", "txtDomain", test.connectionEWS[3]);

            test.insertText("input", "id", "txtPassword", test.connectionEWS[4]);

            test.clickObject("div", "class", "button button-yellow");

            Thread.Sleep(2500);

            test.clickObject("div", "class", "button button-blue");

            test.clickObject("div", "id", "apply-all-changes-button");         
        }

        public static void addConnectionPexip(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Integrations-Settings", test.url, "General-Settings"));
            test.clickObject("button", "class", "button button-blue");

            test.clickObject("div", "class", "dropdown flex-1");
            IWebElement list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='Pexip Infinity']")).Click();
            test.insertText("input", "id", "txtName", test.connectionPexip[0]);

            IWebElement hostname = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div/div[2]/input"));
            hostname.Click();
            hostname.SendKeys(test.connectionPexip[1]);

            IWebElement username = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div/div[3]/input"));
            username.Click();
            username.SendKeys(test.connectionPexip[2]);

            IWebElement password = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div/div[4]/input"));
            password.Click();
            password.SendKeys(test.connectionPexip[3]);

            test.clickObject("div", "class", "button button-yellow");

            Thread.Sleep(1000);

            test.clickObject("div", "class", "button button-blue");

            test.clickObject("div", "id", "apply-all-changes-button");

            IWebElement header = test.driver.FindElement(By.XPath("//div[@class='header']"));
            Actions action = new Actions(test.driver);
            action.MoveToElement(header).Click();
            action.SendKeys(Keys.PageDown);
            action.SendKeys(Keys.PageDown);
            action.Perform();

            /*-----------------------------------------ADD API INTEGRATION------------------------------------------*/

            Thread.Sleep(1000);

            IWebElement addAPI = test.driver.FindElement(By.XPath("//div[text()='Add API Integration']"));            
            addAPI.Click();

            test.clickObject("div", "class", "dropdown flex-1");
            test.clickObject("div", "value", "2");

            IWebElement connectionDropDown = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div[1]/div[1]"));
            connectionDropDown.Click();

            IWebElement pexip = test.driver.FindElement(By.XPath(string.Format("//div[text()='{0}']", test.connectionPexip[0])));
            pexip.Click();

            IWebElement connectionConfig = test.driver.FindElement(By.XPath("//div[@class='section-header-text']"));
            action.MoveToElement(connectionConfig).Click();
            action.SendKeys(Keys.PageDown);            
            action.Perform();

            IWebElement reverseProxy = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[3]/div/div[2]/div[2]/input"));
            reverseProxy.Click();
            reverseProxy.SendKeys(test.connectionPexip[4]);


            IWebElement getLocations = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[3]/div/div[2]/div[3]/div/div[3]/button"));
            getLocations.Click();

            IWebElement okBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[3]/div/div[2]/div[3]/div/div[2]/div/div"));

            do
            {
                Thread.Sleep(500);
                if (okBanner.Text == "OK")
                {
                    break;
                }

            } while (true);

            IWebElement save = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[3]/div[1]"));
            save.Click();            
  
            Actions action2 = new Actions(test.driver);
            action2.MoveToElement(header).Click();
            action2.SendKeys(Keys.PageDown);
            action2.SendKeys(Keys.PageDown);
            action2.Perform();

            Thread.Sleep(100);

            IWebElement APItable = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[2]/table"));
            var rows = APItable.FindElements(By.TagName("tr"));
            var switches = APItable.FindElements(By.XPath("//div[@class='switch']"));
            for (int i = 0; i < rows.Count - 1; i++)
            {
                var tds = rows[i + 1].FindElements(By.XPath("td"));
                if (tds[1].Text == test.connectionPexip[0]) { switches[i].Click(); }
            }

            test.clickObject("div", "id", "apply-all-changes-button");

        }

        public static void addVideoSystem(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Video-Systems", test.url, "General-Settings"));
            test.clickObject("div", "class", "button button-blue");
            test.clickObject("div", "class", "dropdown flex-1");

            test.driver.FindElement(By.XPath(string.Format("//div[text()='{0}']", test.addRoomManuallyName))).Click();

            IWebElement manu = test.driver.FindElement(By.XPath("//label[text()='Manufacturer']//parent::div"));
            manu.Click();
            test.driver.FindElement(By.XPath("//div[@value='1']")).Click();

            IWebElement IPaddress = test.driver.FindElement(By.XPath("//label[text()='IP Address']//parent::div"));
            IPaddress.Click();
            Actions insertText = new Actions(test.driver);
            insertText.SendKeys(test.addVideoSystemCisco[0]).Perform();

            IWebElement username = test.driver.FindElement(By.XPath("//label[text()='Username']//parent::div"));
            username.Click();
            Actions insertText2 = new Actions(test.driver);
            insertText2.SendKeys(test.addVideoSystemCisco[2]).Perform();

            IWebElement pwd = test.driver.FindElement(By.XPath("//label[text()='Password']//parent::div"));
            pwd.Click();
            Actions insertText3 = new Actions(test.driver);
            insertText3.SendKeys(test.addVideoSystemCisco[1]).Perform();

            IWebElement insertURI = test.driver.FindElement(By.XPath("//label[text()='URI']//parent::div"));
            insertURI.Click();
            Actions insertText4 = new Actions(test.driver);
            insertText4.SendKeys(test.addVideoSystemCisco[3]).Perform();

            test.clickObject("div", "class", "button button-yellow");

            IWebElement testedBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div[2]/div/div[2]/div/div[2]/div[2]/div/div[5]/div[2]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (testedBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);
            

            test.clickObject("div", "class", "button button-blue");

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div[2]/div/div[2]/table/tr[2]/td[1]/div/div/div[2]")).Click();

            test.driver.FindElement(By.XPath("//div[@class='switch']")).Click();

            test.clickObject("div", "id", "apply-all-changes-button");
           
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Rooms", test.url, "General-Settings"));
           
            var tr = test.driver.FindElement(By.XPath(string.Format("//td[text()='{0}']//parent::tr",test.addRoomManuallyName)));
            var tds = tr.FindElements(By.TagName("td"));
            
            foreach (var td in tds)
            {
                if (td.GetAttribute("class") == "edit")
                {
                    td.Click();
                    break;
                }
            }

            test.driver.FindElement(By.XPath("//label[text()='Attached videosystem']")).Click();
            test.driver.FindElement(By.XPath("//*[contains(.,'Cisco')]")).Click();

            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();
            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addConnectionThingsWeb(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Integrations-Settings", test.url, "General-Settings"));
            test.clickObject("button", "class", "button button-blue");

            test.clickObject("div", "class", "dropdown flex-1");
            IWebElement list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='ThingsWeb Cloud']")).Click();

            test.driver.FindElement(By.XPath("//label[contains(.,'Name')]")).Click();
            Actions action = new Actions(test.driver);
            action.SendKeys(test.connectionThingsWeb[0]);
            action.Perform();

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[2]/input")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.connectionThingsWeb[1]);
            action.Perform();

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div[3]/input")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.connectionThingsWeb[2]);
            action.Perform();

            test.clickObject("div", "class", "button button-yellow");

            IWebElement okBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[4]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (okBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);          

            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();

            var table = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/table"));
            var tr = table.FindElements(By.TagName("tr"));
            var edits = table.FindElements(By.XPath("//td[@class='edit']"));
            for (int i = 1; i < tr.Count; i++)
            {
                var tds = tr[i].FindElements(By.XPath("td"));
                if (tds[0].Text == test.connectionThingsWeb[0]) { edits[i - 1].Click(); }
            }

            test.clickObject("div", "class", "button button-yellow");

            var testedBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[4]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (testedBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);

            test.clickObject("div", "class", "button button-blue");

            test.clickObject("div", "id", "apply-all-changes-button");

            /*-----------------------------------------ADD API INTEGRATION------------------------------------------*/

            IWebElement header = test.driver.FindElement(By.XPath("//div[@class='header']"));
            action = new Actions(test.driver);
            action.MoveToElement(header).Click();
            action.SendKeys(Keys.PageDown);
            action.SendKeys(Keys.PageDown);
            action.Perform();

            Thread.Sleep(1000);

            test.driver.FindElement(By.XPath("//div[text()='Add API Integration']")).Click();

            test.clickObject("div", "class", "dropdown flex-1");
            list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='Sensors']")).Click();

            IWebElement connection = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div[1]/div[1]"));
            connection.Click();
            connection.FindElement(By.XPath($"//div[text()='{test.connectionThingsWeb[0]}']")).Click();

            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();

            IWebElement APItable = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[2]/table"));
            var rows = APItable.FindElements(By.TagName("tr"));
            var switches = APItable.FindElements(By.XPath("//div[@class='switch']"));
            for (int i = 0; i < rows.Count - 1; i++)
            {
                var tds = rows[i+1].FindElements(By.XPath("td"));
                if (tds[1].Text == test.connectionThingsWeb[0]) { switches[i].Click(); }                
            }
                
            test.clickObject("div", "id", "apply-all-changes-button");
        }

        public static void addConnectionQuickChannel(AutoTesting test)
        {
            test.driver.Navigate().GoToUrl(string.Format("{0}/{1}/Integrations-Settings", test.url, "General-Settings"));
            test.clickObject("button", "class", "button button-blue");

            test.clickObject("div", "class", "dropdown flex-1");
            IWebElement list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='Quickchannel Cloud']")).Click();

            test.driver.FindElement(By.XPath("//label[contains(.,'Name')]")).Click();
            Actions action = new Actions(test.driver);
            action.SendKeys(test.connectionQuickChannel[0]).Perform();

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div/div/div[2]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.connectionQuickChannel[1]).Perform();

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[3]/div/div/div[3]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.connectionQuickChannel[2]).Perform();

            test.clickObject("div", "class", "button button-yellow");

            var testedBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[4]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (testedBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);

            test.clickObject("div", "class", "button button-blue");

            var table = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/table"));
            var tr = table.FindElements(By.TagName("tr"));
            var edits = table.FindElements(By.XPath("//td[@class='edit']"));
            for (int i = 1; i < tr.Count; i++)
            {
                var tds = tr[i].FindElements(By.XPath("td"));
                if (tds[0].Text == test.connectionQuickChannel[0]) { edits[i - 1].Click(); }
            }

            test.clickObject("div", "class", "button button-yellow");

            testedBanner = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div/div[2]/div[4]/div/div/div"));
            do
            {
                Thread.Sleep(500);
                if (testedBanner.Text == "Tested")
                {
                    break;
                }

            } while (true);

            test.clickObject("div", "class", "button button-blue");
            test.clickObject("div", "id", "apply-all-changes-button");

            /*-----------------------------------------ADD API INTEGRATION------------------------------------------*/

            IWebElement header = test.driver.FindElement(By.XPath("//div[@class='header']"));
            action = new Actions(test.driver);
            action.MoveToElement(header).Click();
            action.SendKeys(Keys.PageDown);
            action.SendKeys(Keys.PageDown);
            action.Perform();

            Thread.Sleep(1000);

            test.driver.FindElement(By.XPath("//div[text()='Add API Integration']")).Click();

            test.clickObject("div", "class", "dropdown flex-1");
            list = test.driver.FindElement(By.XPath("//div[@class='list-container']"));
            list.FindElement(By.XPath("//div[text()='Recording']")).Click();

            IWebElement connection = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div[1]/div[1]"));
            connection.Click();
            connection.FindElement(By.XPath($"//div[text()='{test.connectionQuickChannel[0]}']")).Click();

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[3]/div/div/div[2]/div[2]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.connectionQuickChannel[3]).Perform();

            test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[4]/div/div[2]/div[3]/div/div/div[2]/div[4]")).Click();
            action = new Actions(test.driver);
            action.SendKeys(test.connectionQuickChannel[4]).Perform();

            test.driver.FindElement(By.XPath("//div[text()='Save']")).Click();            

            IWebElement APItable = test.driver.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[4]/div[2]/div/div/div[2]/table"));
            var rows = APItable.FindElements(By.TagName("tr"));
            var switches = APItable.FindElements(By.XPath("//div[@class='switch']"));
            for (int i = 0; i < rows.Count - 1; i++)
            {
                var tds = rows[i + 1].FindElements(By.XPath("td"));
                if (tds[1].Text == test.connectionQuickChannel[0]) { switches[i].Click(); }
            }

            test.clickObject("div", "id", "apply-all-changes-button");
        }
    }
}
