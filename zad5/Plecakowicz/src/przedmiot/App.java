package przedmiot;

import java.util.ArrayList;
import java.util.List;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class App {
    public static void main(String[] args) throws Exception {
        RandomNumberGenerator rng = new RandomNumberGenerator(1);

        List<przedmiot> listaPrzedmiotow = new ArrayList<przedmiot>();
        plecak mojPlecak = new plecak(70);
        int liczbaPrzedmiotow = 10;
        // Generuje listę przedmiotów
        for (int i = 0; i < liczbaPrzedmiotow; i++) {
            listaPrzedmiotow.add(new przedmiot(rng.nextInt(1, 29), rng.nextInt(1, 29)));
        }
        // Sortuj listę przedmiotów

        mojPlecak.wlozDoPlecaka(listaPrzedmiotow);
        /*
         * foreach (przedmiot item in listaPrzedmiotow) { if
         * (mojPlecak.sumaWagPrzedmiotow() + item.wagaPrzedmiotu <=
         * mojPlecak.wagaMaksymalna) { mojPlecak.dodajPrzedmiot(item); } }
         */
        System.out.println(mojPlecak.sumaWagPrzedmiotow());
        mojPlecak.pokazPrzedmioty();

        
        JFrame frame = new JFrame("plecak");
        frame.setSize(400, 500);
        JButton button = new JButton("ok");
        frame.add(button);
        frame.setVisible(true);
        
    }
}
