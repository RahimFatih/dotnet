package przedmiot2;

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
        


        // Panele: Etykieta + pola wprowadzania(dla podaj wage plecaka)
        // Panele: Etykieta + pola wprowadzania(Ilosc przedmiotow)
        // Panele: Etykieta wielo wieroszowa(lista przedmiotow)
        // Panele: Prrzycisk(Sortuj)
        JPanel mainPanel = new JPanel();
        JPanel panelSortuj = new JPanel();
        JPanel panelWagaPlecaka = new JPanel();
        JPanel panelIloscPrzedmiotow = new JPanel();
        JPanel panelListaPrzedmiotow = new JPanel();

        mainPanel.setLayout(new GridLayout(4, 1));
        panelWagaPlecaka.setLayout(new GridLayout(1,2));
        panelIloscPrzedmiotow.setLayout(new GridLayout(1,2));
        panelListaPrzedmiotow.setLayout(new GridLayout(1,2));
        panelSortuj.setLayout(new GridLayout(1,1));
        
        //Panel do wprowadzania max wagi plecaka
        JLabel LabelWagaPlecaka = new JLabel("Podaj max wagę plecaka");
        JTextField TextFieldWagaPlecaka = new JTextField();
        panelWagaPlecaka.add(LabelWagaPlecaka);
        panelWagaPlecaka.add(TextFieldWagaPlecaka);

        //Panel do wprowadzania ilosci przedmiotow
        JLabel LabelIloscPrzedmiotow = new JLabel("Podaj ilość przedmiotów");
        JTextField TextFieldIloscPrzedmiotow = new JTextField();
        panelIloscPrzedmiotow.add(LabelIloscPrzedmiotow);
        panelIloscPrzedmiotow.add(TextFieldIloscPrzedmiotow);
        
        //Panel do wyswietlania wyniku
        JTextArea TextAreaListaPrzedmiotow = new JTextArea();
        TextAreaListaPrzedmiotow.setEditable(false);
        panelListaPrzedmiotow.add(TextAreaListaPrzedmiotow);
        TextAreaListaPrzedmiotow.setText("Tu wyświetli się lista przedmitów");

        
        //Przycisk do sortowania i jego akcja
        JButton button = new JButton("Do plecaka!");
        panelSortuj.add(button);
        button.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                listaPrzedmiotow.clear();
                System.out.println("Welcome to Javatpoint.");
                plecak mojPlecak = new plecak(Integer.parseInt(TextFieldWagaPlecaka.getText()));
                // Generuje listę przedmiotów
                for (int i = 0; i < Integer.parseInt(TextFieldIloscPrzedmiotow.getText()); i++) {
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
                TextAreaListaPrzedmiotow.setText(mojPlecak.pokazPrzedmioty());
                System.out.println(mojPlecak.pokazPrzedmioty());
            }
        });


        JFrame frame = new JFrame("plecak");
        frame.setSize(400, 500);
        frame.setLayout(new BorderLayout());
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JScrollPane scrollPane = new JScrollPane(TextAreaListaPrzedmiotow);

        //Dodajemy panele do ramki
        mainPanel.add(panelWagaPlecaka);
        mainPanel.add(panelIloscPrzedmiotow);
        mainPanel.add(scrollPane);
        mainPanel.add(panelSortuj);

        frame.add(mainPanel);
        frame.setVisible(true);

    }
}
