using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.IO;

var client = new HttpClient();
string key = File.ReadAllText("appsettings.json");
string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();
Console.WriteLine("What Zip Code would you like to get the weather for?");
var userInput = Console.ReadLine();
var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={userInput}&appid={APIkey}&units=imperial";
var weather = client.GetStringAsync(weatherURL).Result;
var temp = double.Parse(JObject.Parse(weather)["main"]["temp"].ToString());
var feels_like = double.Parse(JObject.Parse(weather)["main"]["feels_like"].ToString());
var humidity = double.Parse(JObject.Parse(weather)["main"]["humidity"].ToString());
var temp_min = double.Parse(JObject.Parse(weather)["main"]["temp_min"].ToString());
var temp_max = double.Parse(JObject.Parse(weather)["main"]["temp_max"].ToString());
var pressure = double.Parse(JObject.Parse(weather)["main"]["pressure"].ToString());

bool cont = true;
do
{
    Console.WriteLine($"Current temperature: {temp}");
    Console.WriteLine($"Feels Like: {feels_like}");
    Console.WriteLine($"Humidity: {humidity}");
    Console.WriteLine($"Low: {temp_min}");
    Console.WriteLine($"High: {temp_max}");
    Console.WriteLine($"Pressure: {pressure}");
    Console.WriteLine("---------------------");
    Console.WriteLine("Enter another Zip Code or type end");
    var userResponse = Console.ReadLine().ToLower();
    cont = (userResponse == "end") ? false : true;
} while (cont);


//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine("What Zip Code would you like to get the weather for?");
//    var userInput = Console.ReadLine();
//    var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={userInput}&appid={APIkey}&units=imperial";
//    var weather = client.GetStringAsync(weatherURL).Result;
//    var temp = double.Parse(JObject.Parse(weather)["main"]["temp"].ToString());
//    var feels_like = double.Parse(JObject.Parse(weather)["main"]["feels_like"].ToString());
//    var humidity = double.Parse(JObject.Parse(weather)["main"]["humidity"].ToString());
//    var temp_min = double.Parse(JObject.Parse(weather)["main"]["temp_min"].ToString());
//    var temp_max = double.Parse(JObject.Parse(weather)["main"]["temp_max"].ToString());
//    var pressure = double.Parse(JObject.Parse(weather)["main"]["pressure"].ToString());
//    Console.WriteLine($"Current temperature: {temp}");
//    Console.WriteLine($"Feels Like: {feels_like}");
//    Console.WriteLine($"Humidity: {humidity}");
//    Console.WriteLine($"Low: {temp_min}");
//    Console.WriteLine($"High: {temp_max}");
//    Console.WriteLine($"Pressure: {pressure}");
//    Console.WriteLine("---------------------");
//}




//"main":{
//        "temp": 79.12,
//        "feels_like": 79.12,
//        "humidity": 77,
//        "temp_min": 77.02,
//        "temp_max": 81.99,
//        "pressure": 1024
//     }
