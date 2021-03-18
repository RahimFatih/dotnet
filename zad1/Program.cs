using System;
using System.Collections.Generic;
namespace dotnet
{

    //ToDo:
    //•Sprawdz sume wag przedmiotów w plecaku w Nowej Metodzie
    //•Dodać żeby pokazywała wszystkie przedmioty w metodzie pokazPrzedmioty()
    //•metoda Wyjmij Ostatni Przedmiot
    public class plecak
    {
        List<przedmiot> przedmioty = new List<przedmiot>();
        private int wagaMaksymalna;
        
        public plecak(int waga)
        {
            wagaMaksymalna=waga;
        }
        public void dodajPrzedmiot(przedmiot nowy)
        {
            przedmioty.Add(nowy);
        }
        public void pokazPrzedmioty()
        {   
            //Console.WriteLine(przedmioty[0].wagaPrzedmiotu);
            //przedmioty.ForEach(Console.WriteLine(.wagaPrzedmiotu, .wartoscPrzedmiotu));
            //przedmioty.ForEach(przedmiot => Console.Write("{0}\t", przedmiot));
            for(int i =0;i<przedmioty.Count;i++)
            {
                Console.WriteLine("Waga: ", przedmioty[i].wagaPrzedmiotu);
                Console.WriteLine("Wartosc: ", przedmioty[i].wartoscPrzedmiotu);
            }
        }
    }
    
    //Klasa Przedmiot TODO
    //•Konstruktor w postaci xD= new przedmiot(54)
    public class przedmiot
    {   
        public int wagaPrzedmiotu;
        public int wartoscPrzedmiotu;
        //private bool stanPrzedmiotu;
        public float stosunekWartoscWaga;
    

        
        public przedmiot(int waga, int wartosc)
        {
            wagaPrzedmiotu = waga;
            wartoscPrzedmiotu = wartosc;
            stosunekWartoscWaga=wartosc/waga;
        }
        /*
        public bool ustawStan(bool stan)
        {
            stanPrzedmiotu = stan;
            return stan;
        }
        */
    }


        class Program
    {
        static void Main(string[] args)
        {
            List<przedmiot> listaPrzedmiotow = new List<przedmiot>();
            plecak mojPlecak = new plecak(54);
            //Generuje listę przedmiotów
            Random rand =new Random();
            for (int i = 0; i < 40; i++)
            {
                listaPrzedmiotow.Add(new przedmiot(rand.Next(1,30),rand.Next(1,30)));
            }
            //Sortuj listę przedmiotów
            listaPrzedmiotow.Sort((x, y) => y.stosunekWartoscWaga.CompareTo(x.stosunekWartoscWaga));
            foreach (przedmiot item in listaPrzedmiotow)  
            mojPlecak.dodajPrzedmiot(item);
            mojPlecak.pokazPrzedmioty();
            Console.WriteLine("Test!");
        }
    }
}
