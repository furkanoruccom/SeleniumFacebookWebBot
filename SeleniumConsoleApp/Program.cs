using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebBotExample
{
    class Program
    {


        static void Main(string[] args)
        {
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

                driver.Navigate().GoToUrl("https://www.facebook.com/thefurkanoruc/posts/1913940275667135:1913940275667135");
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));


                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //js.ExecuteScript("window.location= 'https://www.facebook.com/thefurkanoruc/posts/1913940275667135:1913940275667135'");

                // Elementin sayfada olup olmadığını kontrol edin.
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x div.xzsf02u")));
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x")));
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x p.xdj266r")));

                js.ExecuteScript("document.querySelector('form.x1ed109x div.xzsf02u').focus();");
                js.ExecuteScript("document.querySelector('form.x1ed109x').click();");

                IWebElement textElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x p.xdj266r")));
                textElement.SendKeys("Yörük Travel");


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
