using Facebook;
using System.Dynamic;


var token = "EAAJQEXL2kL0BO1XRYkZC6kkl2YbqDySZC4hCx8rYeDEFBB65J9BwMTbFCM35kaaCN4pWfPD2HFnmcazQQR8XYdF6y4oHDS1aqhG5t7DrkGGgA1rDzYwDXZAlJe5QpCOmdtikTNlNrL71536oEPF0Ml2aMT7rBrDIuJti8VIroKZCoAHD21dcC3k0rgZDZD";
var fb = new FacebookClient(token);
dynamic parameters = new ExpandoObject();
parameters.message = "Yoruk Travel";
parameters.link = "https://www.example.com"; // Eğer bir link paylaşmak isterseniz

dynamic result = fb.Post("me/feed", parameters);
string postId = result.id;
