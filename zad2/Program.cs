using System;
using System.Net;
using System.IO;
using System.Data;
using Newtonsoft.Json;
namespace zad2
{
    public class Cord
    {
        public float lon;
        public float lat;
    }
    public class Weather
    {
        public int id;
    }
    public class DownloadWeather
    {
        public string timezone { get; set; }
        public string name { get; set; }
        public Cord coord {get;set;}
        public Weather[] weather {get;set;}
        //public string main { get; set; }
        //public string feels_like { get; set; }
        //public DataSet weather { get; set; }
        
        public string getWeather(string City)
        {
            using(WebClient web = new WebClient())
            {
                string url =string.Format("https://api.openweathermap.org/data/2.5/weather?q="+City+"&appid=b0789adf874bd65919c23b49a964d714&units=metric");
                var json = web.DownloadString(url);
                //Console.WriteLine(json);
                return json;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            
            //string City = "Wroclaw";
            //DownloadWeather myWeather = new DownloadWeather();
            //Console.WriteLine(myWeather.getWeather(City));
            //DownloadWeather deserializedProduct = JsonConvert.DeserializeObject<DownloadWeather>(myWeather.getWeather(City));
            //Console.WriteLine(deserializedProduct.name);
            //Console.WriteLine(deserializedProduct.coord.lat);
            //Console.WriteLine(deserializedProduct.weather[0].id);
            
        }

        
    }
}   
