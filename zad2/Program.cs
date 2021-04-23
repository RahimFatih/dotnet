using System;
using System.Net;
using System.IO;
using System.Data;
using Newtonsoft.Json;
//using System.Data.Entity;
//using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace zad2
{
    public class Coord
    {
        public float lon;
        public float lat;
    }
    public class Weather
    {
        public int id;
        public string main;
        public string description;
    }
    public class MainWeather
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public float pressure;
        public float humidity;
    }
    public class Wind
    {
        public float speed;
        public float deg;
    }
    public class Clouds
    {
        public float all;
    }
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public float sunrise;
        public float sunset;
    }
    public class DownloadWeather
    {
        public Coord coord {get;set;}
        public Weather[] weather {get;set;}
        //public string base {get; set; }
        public MainWeather main {get;set;}
        public float visibility {get;set;}
        public Wind wind{get;set;}
        public Clouds clouds{get;set;}
        public int dt{get;set;}
        public Sys sys{get;set;}
        public int timezone { get; set; }
        public int id {get;set;}
        public string name { get; set; }
        public int cod{get;set;}
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
        public int printWeather()
        {
            Console.WriteLine("Miasto: "+name);
            return 0;
        }
    }
        public class WeatherForDB
    {
        public string clouds {get;set;}
        public float temp  {get;set;}
        public float feels_like {get;set;}
        public float temp_min {get;set;}
        public float temp_max {get;set;}
        public float pressure {get;set;}
        public float humidity {get;set;}
        public float windSpeed {get;set;}
        public float windDeg {get;set;}
        public string id {get;set;}
        public string name {get;set;}
        
    
        public int getWeather(DownloadWeather myWeather)
        {
            clouds = myWeather.weather[0].description;
            temp = myWeather.main.temp;
            feels_like = myWeather.main.feels_like;
            temp_min = myWeather.main.temp_min;
            temp_max = myWeather.main.temp_max;
            pressure = myWeather.main.pressure;
            humidity = myWeather.main.humidity;
            windSpeed = myWeather.wind.speed;
            windDeg = myWeather.wind.deg;
            id =DateTime.Now.ToString("yyyyMMddHHmmssffff");
            name = myWeather.name;
            return 0; 
        }
        public int printWeather()
        {
            Console.WriteLine("Miasto: "+name);
            return 0;
        }

    }
    public class WeatherByCity: DbContext
    {
        public virtual DbSet<WeatherForDB> WeatherForDB {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\database\blogging.db");
    }
    public class Test
        {
            public void Welcome(string choosenCity)
            {
                var context = new WeatherByCity();
                DownloadWeather myWeather = new DownloadWeather();
                DownloadWeather actualWeather;
                WeatherForDB actualWeatherForDB = new WeatherForDB();
                lock(this){
                    actualWeather = JsonConvert.DeserializeObject<DownloadWeather>(myWeather.getWeather(choosenCity));
                }
                
                actualWeatherForDB.getWeather(actualWeather);
                context.WeatherForDB.Add(actualWeatherForDB);
                context.SaveChanges();
                lock(this)
                {
                    Console.WriteLine("Miasto: " + actualWeather.name);
                    Console.WriteLine("Kraj: " + actualWeather.sys.country);
                    Console.WriteLine("Temperatura: " + actualWeather.main.temp+"°C");
                    Console.WriteLine("Zachmurzenie: " + actualWeather.weather[0].description);            

                }
                //blok obliczeń niezależnych
            }
        }
    public class Program
    {
        public static void Main(string[] args)
        {
            //Encoding.GetEncoding("Windows-1250");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            var context = new WeatherByCity();
            string choosenCity;
            string[] manyCities = new string[] {"Warsaw","Sopot","Gdynia","Przeworsk","Radom","London","New York"};
            int n = 7;
            Thread[] threads = new Thread[n];
            Test test = new Test();

            DownloadWeather myWeather = new DownloadWeather();
            DownloadWeather actualWeather;
            WeatherForDB actualWeatherForDB = new WeatherForDB();

            Console.WriteLine("1. Sprawdz pogode \n2. Pokaz historie dla miasta\n3. Duzo miast");
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Podaj miasto: ");
                    choosenCity = Console.ReadLine();
                    actualWeather = JsonConvert.DeserializeObject<DownloadWeather>(myWeather.getWeather(choosenCity));
                    actualWeatherForDB.getWeather(actualWeather);
                    Console.WriteLine("Miasto: " + actualWeather.name);
                    Console.WriteLine("Kraj: " + actualWeather.sys.country);
                    Console.WriteLine("Temperatura: " + actualWeather.main.temp+"°C");
                    Console.WriteLine("Zachmurzenie: " + actualWeather.weather[0].description);            
                    context.WeatherForDB.Add(actualWeatherForDB);
                    context.SaveChanges();
                    break;
                case 2:
                    Console.WriteLine("Podaj miasto");
                    //var cities = context.WeatherForDB.FromSqlRaw("SELECT DISTINCT name FROM WeatherForDB");
                    //foreach(var city in cities)
                    //{
                    //    Console.WriteLine(city.name);//+" "+pogoda.id.Substring(0,4)+" ");
                    //}
                    choosenCity = Console.ReadLine();
                    Console.WriteLine("SELECT * FROM WeatherForDB WHERE name = '"+choosenCity+"'");
                    var pogody = context.WeatherForDB.FromSqlRaw("SELECT * FROM WeatherForDB WHERE name = '"+choosenCity+"'");//.ToList<DownloadWeather>();
                    foreach(var pogoda in pogody)
                    {
                        Console.WriteLine(pogoda.id.Substring(0,4)+"-"+pogoda.id.Substring(4,2)+"-"+pogoda.id.Substring(6,2)+" Temperatura: "+pogoda.temp+"°C");//+" "+pogoda.id.Substring(0,4)+" ");
                    }
                    break;
                case 3:
                    for (int i = 0; i < n; i++)
                    {
                        //Console.WriteLine(manyCities[i]);
                        int zmiennaTym=i;
                        threads[i] = new Thread(() => test.Welcome(manyCities[zmiennaTym]));
                    }
                    foreach(var t in threads)
                    {
                        t.Start();
                    }
                    foreach (var t in threads)
                    {
                        t.Join();
                    }
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji");
                    break;
            }
            
                
        }

        
    }
}
