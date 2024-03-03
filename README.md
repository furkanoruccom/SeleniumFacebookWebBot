powered by [Furkan Oruç](https://furkanoruc.com/)

# Web Bot Example

This project demonstrates a web automation task using Selenium WebDriver. The primary functions of this script are as follows:

## Features

### 1. Downloading and Copying an Image to Clipboard
- The program first navigates to a specific website (`https://furkanoruc.com/assets/img/avatar-1.jpg`) and retrieves the URL of an image.
- The image is downloaded via an HTTP request and processed using .NET's `System.Drawing` library.
- The downloaded image is then copied to the Windows clipboard, using a separate thread which is run in STA mode.

### 2. Logging into Facebook and Commenting
- The program navigates to the Facebook website for login. User email and password are entered in the respective fields.
- After logging in, it proceeds to a specific Facebook post.
- It focuses on a comment box within the post, pasting the text `hello world` and the image previously copied to the clipboard.
- Finally, the comment is submitted by clicking the submit button.

### 3. Closing
- Once all operations are complete, the browser is automatically closed.

In summary, this program is designed to download an image from a website, copy it to the clipboard, log into Facebook, post a comment on a specific post, and utilize the downloaded image in the comment.

---

## Web Bot Örneği

Bu yazılım, bir web otomasyon görevi gerçekleştirmek için Selenium WebDriver kullanıyor. Ana görevleri şunları içeriyor:

### Özellikler

#### 1. Resim İndirme ve Panoya Kopyalama
- İlk olarak, belirtilen bir web sitesine (`https://furkanoruc.com/assets/img/avatar-1.jpg`) gidilir ve buradaki bir resmin URL'si alınır.
- Resim, HTTP isteği kullanılarak indirilir ve .NET'in `System.Drawing` kütüphanesi ile işlenir.
- Daha sonra, indirilen resim, Windows panosuna kopyalanır. Bu işlem için ayrı bir iş parçacığı (thread) kullanılır ve STA modunda çalıştırılır.

#### 2. Facebook'a Giriş Yapma ve Yorum Yapma
- Program, Facebook web sitesine giderek oturum açma işlemi yapar. Kullanıcı e-postası ve şifresi belirtilen alanlara girilir.
- Oturum açıldıktan sonra, belirli bir Facebook gönderisine gidilir.
- Bu gönderide, bir yorum alanına odaklanılır ve `hello world` yazısı ile daha önce panoya kopyalanan resim yapıştırılır.
- Son olarak, yorum gönderme butonuna tıklanarak yorum gönderilir.

#### 3. Kapanış
- Tüm işlemler tamamlandıktan sonra tarayıcı otomatik olarak kapatılır.

Özetle, bu program bir web sitesinden resim indirip panoya kopyalar, Facebook'a giriş yapar, belirli bir gönderide yorum yapar ve bu yorumda indirilen resmi kullanır.
