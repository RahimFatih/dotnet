package snakeData;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

import javax.swing.JPanel;
import javax.swing.Timer;

public class Grafika
extends JPanel
implements ActionListener{
	private Timer t = new Timer(100, this);
	public String state;
	
	private Waz s;
	private Jedzenie f;
	private Gra gra;
	
	public Grafika(Gra g) {
		t.start();
		state = "START";
		
		gra = g;
		s = g.getPlayer();
		f = g.getFood();
		
		//add a keyListner 
		this.addKeyListener(g);
		this.setFocusable(true);
		this.setFocusTraversalKeysEnabled(false);
	}
	
	public void paintComponent(java.awt.Graphics g) {
		Random rand = new Random();
		super.paintComponent(g);
		
		Graphics2D g2d = (Graphics2D) g;
		
		g2d.setColor(Color.black);
		g2d.fillRect(0, 0, Gra.szer * Gra.rozmiar + 5, Gra.wys * Gra.rozmiar + 5);
		
		if(state == "START") {
			g2d.setColor(Color.white);
			g2d.drawString("Nacisnij dowolny przycisk", Gra.szer/2 * Gra.rozmiar - 40, Gra.wys / 2 * Gra.rozmiar - 20);
		}
		else if(state == "RUNNING") {
			g2d.setColor(Color.red);
			g2d.fillRect(f.getX() * Gra.rozmiar, f.getY() * Gra.rozmiar, Gra.rozmiar, Gra.rozmiar);
			
			
			for(Rectangle r : s.getBody()) {
				float czerwony = rand.nextFloat();
				float zielony = rand.nextFloat();
				float niebieski = rand.nextFloat();
				g2d.setColor(new Color(czerwony,zielony,niebieski));
				g2d.fill(r);
			}
			g2d.setColor(Color.white);
			g2d.drawString("Wynik: " + (s.getBody().size() - 3), Gra.szer * Gra.rozmiar -100,20);
		}
		else {
			g2d.setColor(Color.white);
			g2d.drawString("Wynik: " + (s.getBody().size() - 3), Gra.szer/2 * Gra.rozmiar - 40, Gra.wys / 2 * Gra.rozmiar - 20);
		}
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		repaint();
		gra.update();

	}
	
}
