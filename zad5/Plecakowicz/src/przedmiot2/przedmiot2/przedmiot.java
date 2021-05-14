package przedmiot2;
public class przedmiot {
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
