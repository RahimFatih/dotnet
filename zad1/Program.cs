using System;
using System.Collections.Generic;
namespace dotnet
{

     public class plecak
    {
        List<przedmiot> przedmioty = new List<przedmiot>();
        public int wagaMaksymalna;

        public plecak(int waga)
        {
            wagaMaksymalna = waga;
        }
        public int iloscPrzedmiotow()
        {
            return przedmioty.Count;
        }
        public void dodajPrzedmiot(przedmiot nowy)
        {
            przedmioty.Add(nowy);
        }
        public float sumaWagPrzedmiotow()
        {
            float suma = 0;
            foreach (przedmiot item in przedmioty)
            {
                suma = suma + item.wagaPrzedmiotu;
            }
            return suma;
        }
        public void pokazPrzedmioty()
        {
            for (int i = 0; i < przedmioty.Count; i++)
            {
                Console.WriteLine("Przedmiot nr. {0}", i + 1);
                Console.WriteLine("Wartość/Waga: {0}/{1} Stosunek:{2}", przedmioty[i].wartoscPrzedmiotu, przedmioty[i].wagaPrzedmiotu, przedmioty[i].stosunekWartoscWaga);
            }
        }
        public void wlozDoPlecaka(List<przedmiot> przedmiotyDoWlozenia)
        {
            przedmiotyDoWlozenia.Sort((x, y) => y.stosunekWartoscWaga.CompareTo(x.stosunekWartoscWaga));
            foreach (przedmiot item in przedmiotyDoWlozenia)
            {
                if (sumaWagPrzedmiotow() + item.wagaPrzedmiotu <= wagaMaksymalna)
                {
                    dodajPrzedmiot(item);
                }
            }
        }
    }


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
            stosunekWartoscWaga = (float)wartosc / (float)waga;
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
            plecak mojPlecak = new plecak(70);
            int liczbaPrzedmiotow = 10;
            //Generuje listę przedmiotów
            Random rand = new Random();
            for (int i = 0; i < liczbaPrzedmiotow; i++)
            {
                listaPrzedmiotow.Add(new przedmiot(rand.Next(1, 30), rand.Next(1, 30)));
            }
            //Sortuj listę przedmiotów
           
            mojPlecak.wlozDoPlecaka(listaPrzedmiotow);
            /*
            foreach (przedmiot item in listaPrzedmiotow)
            {
                if (mojPlecak.sumaWagPrzedmiotow() + item.wagaPrzedmiotu <= mojPlecak.wagaMaksymalna)
                {
                    mojPlecak.dodajPrzedmiot(item);
                }
            }*/
            Console.WriteLine(mojPlecak.sumaWagPrzedmiotow());
            mojPlecak.pokazPrzedmioty();
        }
    }
}
