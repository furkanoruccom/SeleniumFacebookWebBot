// Facebook'a giriş için kullanıcı adı ve şifreyi girin.
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

string username = "05379271688";
string password = "CogSgdXUJ3y47sa";

// Chrome sürücüsü oluşturun.
IWebDriver driver = new ChromeDriver();

// Facebook'un ana sayfasına gidin.
driver.Navigate().GoToUrl("https://www.facebook.com");

// Giriş yapın.
driver.FindElement(By.Id("email")).SendKeys(username);
driver.FindElement(By.Id("pass")).SendKeys(password);


// Yorum yapmak istediğiniz gönderinin bağlantısını girin.
string postLink = "https://www.facebook.com/thefurkanoruc/posts/1913940275667135:1913940275667135";

// Gönderiye gidin.
driver.Navigate().GoToUrl(postLink);

// Yorum kutusuna bir yorum yazın.
string comment = "Bu gönderi çok güzel!";
driver.FindElement(By.Name("composer_entry")).SendKeys(comment);

// Yorumu gönderin.
driver.FindElement(By.Id("composer_post")).Click();

// Sürücüyü kapatın.
driver.Quit();


