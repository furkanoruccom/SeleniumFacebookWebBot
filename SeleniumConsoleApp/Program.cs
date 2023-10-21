using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SixLabors.ImageSharp.Formats.Jpeg;
using TextCopy;
using System.Drawing;
using System.Security.Permissions;

namespace WebBotExample
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://furkanoruc.com/assets/img/avatar-1.jpg");

                // Resmi bul ve URL'sini al.
                IWebElement image = driver.FindElement(By.TagName("img"));
                string imageUrl = image.GetAttribute("src");

                System.Drawing.Image downloadedImage;
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageData = await client.GetByteArrayAsync(imageUrl);
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData))
                    {
                        downloadedImage = System.Drawing.Image.FromStream(ms);
                    }
                }


                // STA iş parçacığı üzerinde Clipboard işlemini çalıştır
                Thread clipboardThread = new Thread(() =>
                {
                    System.Windows.Forms.Clipboard.SetImage(downloadedImage);
                });
                clipboardThread.SetApartmentState(ApartmentState.STA);
                clipboardThread.Start();
                clipboardThread.Join();










                #region facebook a giriş yap
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
                #endregion



                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete")); // sayfanın yüklenmesini bekle


                #region Elementin sayfada olup olmadığı kontrol
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x div.xzsf02u")));
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x")));
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x p.xdj266r")));
                #endregion

                js.ExecuteScript("document.querySelector('form.x1ed109x div.xzsf02u').focus();");
                js.ExecuteScript("document.querySelector('form.x1ed109x').click();");
                IWebElement textElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form.x1ed109x p.xdj266r")));







                textElement.SendKeys("Furkan Oruç yeni deneme");

                textElement.SendKeys(Keys.Control + "v");







                js.ExecuteScript("document.querySelector('form.x1ed109x .x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.xsyo7zv.x16hj40l.x10b6aqq.x1yrsyyn:nth-child(2) .x1ey2m1c').click()");




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
