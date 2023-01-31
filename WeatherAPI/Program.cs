using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.IO;

var client = new HttpClient();
string key = File.ReadAllText("appsettings.json");
string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();
var userInput = 
var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={userInput}&appid={APIkey}&units=imperial";
var weather = client.GetStringAsync(weatherURL).Result;
var temp = double.Parse(JObject.Parse(weather)["main"]["temp"].ToString());



Console.WriteLine(temp);

//"main":{
//        "temp": 79.12,
//        "feels_like": 79.12,
//        "humidity": 77,
//        "temp_min": 77.02,
//        "temp_max": 81.99,
//        "pressure": 1024
//     }
