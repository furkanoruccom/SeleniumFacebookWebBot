using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebBotExample
{
    class Program
    {


        static void Main(string[] args)
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl("https://www.facebook.com/");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement emailInputElement = WaitUntilElementVisible(driver, By.Id("email"), 20);
                IWebElement passwordInputElement = WaitUntilElementVisible(driver, By.Id("pass"), 20);

                emailInputElement.SendKeys("05379271688"); // Bu bilgileri gizlemeyi düşünün.
                passwordInputElement.SendKeys("CogSgdXUJ3y47sa"); // Bu bilgileri gizlemeyi düşünün.

                IWebElement formElement = WaitUntilElementVisible(driver, By.CssSelector("form._9vtf"), 20);
                formElement.Submit();

                System.Threading.Thread.Sleep(5000);
                driver.Navigate().GoToUrl("https://www.facebook.com/thefurkanoruc/posts/1913940275667135:1913940275667135");




                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));


                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;


                // Elementin sayfada olup olmadığı kontrol
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x div.xzsf02u")));
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x")));
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x p.xdj266r")));

                js.ExecuteScript("document.querySelector('form.x1ed109x div.xzsf02u').focus();");
                js.ExecuteScript("document.querySelector('form.x1ed109x').click();");

                IWebElement textElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x p.xdj266r")));
                textElement.SendKeys("Yörük Travel" + " "+
                    "https://img.freepik.com/free-photo/full-shot-travel-concept-with-landmarks_23-2149153258.jpg?3&w=1060&t=st=1696840426~exp=1696841026~hmac=f5d7d7a8e3e1b12e0308ab80e0d18a1b1baad92fc1653ec341c53d9ca957068c");

                //"https://www.youtube.com/watch?time_continue=2&v=B2CAprs8Mnw"


                js.ExecuteScript("document.querySelector('form.x1ed109x .x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.xsyo7zv.x16hj40l.x10b6aqq.x1yrsyyn:nth-child(2) .x1ey2m1c').click()");


                //IWebElement formElement2 = WaitUntilElementVisible(driver, By.CssSelector("form.x1ed109x "), 10);
                //formElement2.Submit();

                System.Threading.Thread.Sleep(11115000);
                driver.Quit();
            }
        }

        public static IWebElement WaitUntilElementVisible(IWebDriver driver, By itemSpecifier, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(itemSpecifier));
            }
            return driver.FindElement(itemSpecifier);
        }

    }
}
