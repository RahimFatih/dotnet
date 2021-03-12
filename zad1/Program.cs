using System;
using System.Collections.Generic;
namespace dotnet
{


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
            Console.WriteLine(przedmioty[0].wagaPrzedmiotu);
        }
    }
    
    //Klasa Przedmiot TODO
    //•Konstruktor w postaci xD= new przedmiot(54)
    public class przedmiot
    {   
        public int wagaPrzedmiotu;
        private int wartoscPrzedmiotu;
        private bool stanPrzedmiotu;
        private float stosunekWartoscWaga;
    

        
        public przedmiot(int waga, int wartosc)
        {
            wagaPrzedmiotu = waga;
            wartoscPrzedmiotu = wartosc;
            stosunekWartoscWaga=wartosc/waga;
        }
        
        public bool ustawStan(bool stan)
        {
            stanPrzedmiotu = stan;
            return stan;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            plecak mojPlecak = new plecak(54);
            mojPlecak.dodajPrzedmiot(new przedmiot(10,5));
            mojPlecak.pokazPrzedmioty();
            Console.WriteLine("Test!");
        }
    }
}
