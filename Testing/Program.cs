using System;
using System.Text.Json;
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
    class Program
    {
        
        static void Main(string[] args)
        {
            string jsonstring = System.IO.File.ReadAllText(@"C:\Users\HenrikBjørnerudRomne\Desktop\Autotest\Testing\Autotesting-JSON.json");

            AutoTesting test = JsonSerializer.Deserialize<AutoTesting>(jsonstring);

            test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            test.goToConfigTool();

            //test.agreeToEULA();            

            GeneralSettingsTests.validateAPIkey(test);

            GeneralSettingsTests.addConnectionGraph(test);            

            GeneralSettingsTests.addConnectionEWS(test); 

            GeneralSettingsTests.addConnectionPexip(test);

            GeneralSettingsTests.addConnectionThingsWeb(test);

            GeneralSettingsTests.addConnectionQuickChannel(test);

            GeneralSettingsTests.addRoomAuto(test);

            GeneralSettingsTests.addVideoSystem(test);      

            JoinConfigTests.addOneTimeVMR(test);

            JoinConfigTests.addRegexRule(test);

            JoinConfigTests.conferenceSettingsTests(test);

            JoinConfigTests.addDebookPolicy(test);

            //test.deployConfig();   

            //test.driver.Close();     
        }
    }
}
