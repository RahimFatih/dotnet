package przedmiot2;
import java.util.ArrayList;
import java.util.List;

public class plecak
{
    List<przedmiot> przedmioty = new ArrayList<przedmiot>();
    public int wagaMaksymalna;

    public plecak(int waga)
    {
        wagaMaksymalna = waga;
    }
    public int iloscPrzedmiotow()
    {
        return przedmioty.size();
    }
    public void dodajPrzedmiot(przedmiot nowy)
    {
        przedmioty.add(nowy);
    }
    public float sumaWagPrzedmiotow()
    {
        float suma = 0;
        for (przedmiot item : przedmioty)
        {
            suma = suma + item.wagaPrzedmiotu;
        }
        return suma;
    }
    public String pokazPrzedmioty()
    {   
        String lista = "";
        for (int i = 0; i < przedmioty.size(); i++)
        {
            lista=lista+("Przedmiot nr. "+ (i + 1)+"\n");
            lista=lista+("Wartość/Waga: "+przedmioty.get(i).wartoscPrzedmiotu+"/"+przedmioty.get(i).wagaPrzedmiotu+" Stosunek: "+przedmioty.get(i).stosunekWartoscWaga+"\n");
        }
        return lista;
    }
    public void wlozDoPlecaka(List<przedmiot> przedmiotyDoWlozenia)
    {
        przedmiotyDoWlozenia.sort(( x,  y) -> Float.compare(y.stosunekWartoscWaga, x.stosunekWartoscWaga));
        for (przedmiot item : przedmiotyDoWlozenia)
        {
            if (sumaWagPrzedmiotow() + item.wagaPrzedmiotu <= wagaMaksymalna)
            {
                dodajPrzedmiot(item);
            }
        }
    }
}
