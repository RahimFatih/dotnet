using Xunit;


public class testclass
{
    [Fact]
    public void PassingSumaWagPrzedmiotow()
    {
        dotnet.plecak mojPlecak = new dotnet.plecak(70);
        mojPlecak.dodajPrzedmiot(new dotnet.przedmiot(1, 1));
        mojPlecak.dodajPrzedmiot(new dotnet.przedmiot(3, 3));
        Assert.Equal(4, mojPlecak.sumaWagPrzedmiotow());
    }

    [Fact]
    public void PassingDodajPrzedmiot()
    {
        dotnet.plecak mojplecak = new dotnet.plecak(10);
        mojplecak.dodajPrzedmiot(new dotnet.przedmiot(1, 1));
        Assert.Equal(1, mojplecak.iloscPrzedmiotow());
    }
}
