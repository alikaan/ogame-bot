using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDll
{
    public class OgameBot
    {
        IWebDriver Driver;
        public string UserName { get; set; }
        public string Password { get; set; }

        public OgameBot()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            //service.HideCommandPromptWindow = true;

            this.Driver = new ChromeDriver(service);
            Driver.Manage().Window.Maximize();
        }
        public OgameBot(string _username, string _password)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            //service.HideCommandPromptWindow = true;
            
            this.UserName = _username;
            this.Password = _password;
            this.Driver = new ChromeDriver(service);            
            Driver.Manage().Window.Maximize();
        }
        public bool SendExpedition(int _piece)
        {
            try
            {
                for (int i = 0; i < _piece; i++)
                {
                    Driver.Navigate().GoToUrl("https://s165-tr.ogame.gameforge.com/game/index.php?page=ingame&component=galaxy");
                    System.Threading.Thread.Sleep(3000);

                    Driver.FindElement(By.Id("expeditionbutton")).Click();
                    System.Threading.Thread.Sleep(3000);

                    Driver.FindElement(By.Name("explorer")).SendKeys("1");
                    System.Threading.Thread.Sleep(500);
                    Driver.FindElement(By.Name("fighterLight")).SendKeys("20");
                    System.Threading.Thread.Sleep(500);
                    Driver.FindElement(By.Name("fighterHeavy")).SendKeys("3");
                    System.Threading.Thread.Sleep(500);
                    Driver.FindElement(By.Name("cruiser")).SendKeys("3");
                    System.Threading.Thread.Sleep(500);
                    Driver.FindElement(By.Name("battleship")).SendKeys("1");
                    System.Threading.Thread.Sleep(500);
                    Driver.FindElement(By.Name("destoryer")).SendKeys("1");
                    System.Threading.Thread.Sleep(500);
                    Driver.FindElement(By.Name("transporterLarge")).SendKeys("40");                                        
                    System.Threading.Thread.Sleep(1000);

                    //var fleet1 = Driver.FindElement(By.Id("fleet1"));
                    //var fleet2 = Driver.FindElement(By.Id("fleet2"));
                    //var fleet3 = Driver.FindElement(By.Id("fleet3"));

                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("document.getElementById('fleet1').style.display = 'none'; ");
                    js.ExecuteScript("document.getElementById('fleet2').style.display = 'block'; ");
                    Driver.FindElement(By.Id("continueToFleet3")).Click();

                    System.Threading.Thread.Sleep(3000);
                    Driver.FindElement(By.Id("sendFleet")).Click();
                    System.Threading.Thread.Sleep(3000);
                }
                return true;
            }
            catch
            {
                return false;
            }
                        
        }       
        public bool Login(string _username, string _password)
        {
            Driver.Manage().Window.Maximize();
            this.UserName = _username;
            this.Password = _password;
            try
            {
                Driver.Navigate().GoToUrl("https://lobby.ogame.gameforge.com/tr_TR/hub");
                Driver.FindElement(By.XPath("/html/body/div[@id='root']/div[@id='content']/div/div/div[2]/div[@id='loginRegisterTabs']/ul[@class='tabsList']/li[1]/span")).Click();
                Driver.FindElement(By.Name("email")).SendKeys(_username);
                Driver.FindElement(By.Name("password")).SendKeys(_password + Keys.Enter);

                System.Threading.Thread.Sleep(5000);
                Driver.FindElement(By.ClassName("serverDetails")).Click();
                System.Threading.Thread.Sleep(5000);
                var val = Driver.WindowHandles;
                Driver.SwitchTo().Window(val[1]);
                return true;
            }
            catch
            {
                return false;
            }                        
        }
        public bool Login()
        {            
            try
            {
                Driver.Navigate().GoToUrl("https://lobby.ogame.gameforge.com/tr_TR/hub");
                Driver.FindElement(By.XPath("/html/body/div[@id='root']/div[@id='content']/div/div/div[2]/div[@id='loginRegisterTabs']/ul[@class='tabsList']/li[1]/span")).Click();
                Driver.FindElement(By.Name("email")).SendKeys(this.UserName);
                Driver.FindElement(By.Name("password")).SendKeys(this.Password + Keys.Enter);

                System.Threading.Thread.Sleep(5000);
                Driver.FindElement(By.ClassName("serverDetails")).Click();
                System.Threading.Thread.Sleep(5000);
                var val = Driver.WindowHandles;
                Driver.SwitchTo().Window(val[1]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Logout()
        {
            try
            {
                Driver.Quit();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        ~OgameBot()
        {
            Driver.Quit();
        }
    }
}
