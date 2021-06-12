package snakeData;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JPanel;
import javax.swing.Timer;

public class Grafika
extends JPanel
implements ActionListener{
	private Timer t = new Timer(100, this);
	public String state;
	
	private Waz s;
	private Jedzenie f;
	private Gra game;
	
	public Grafika(Gra g) {
		t.start();
		state = "START";
		
		game = g;
		s = g.getPlayer();
		f = g.getFood();
		
		//add a keyListner 
		this.addKeyListener(g);
		this.setFocusable(true);
		this.setFocusTraversalKeysEnabled(false);
	}
	
	public void paintComponent(java.awt.Graphics g) {
		super.paintComponent(g);
		
		Graphics2D g2d = (Graphics2D) g;
		
		g2d.setColor(Color.black);
		g2d.fillRect(0, 0, Gra.width * Gra.dimension + 5, Gra.height * Gra.dimension + 5);
		
		if(state == "START") {
			g2d.setColor(Color.white);
			g2d.drawString("Press Any Key", Gra.width/2 * Gra.dimension - 40, Gra.height / 2 * Gra.dimension - 20);
		}
		else if(state == "RUNNING") {
			g2d.setColor(Color.red);
			g2d.fillRect(f.getX() * Gra.dimension, f.getY() * Gra.dimension, Gra.dimension, Gra.dimension);
		
			g2d.setColor(Color.green);
			for(Rectangle r : s.getBody()) {
				g2d.fill(r);
			}
		}
		else {
			g2d.setColor(Color.white);
			g2d.drawString("Your Score: " + (s.getBody().size() - 3), Gra.width/2 * Gra.dimension - 40, Gra.height / 2 * Gra.dimension - 20);
		}
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		repaint();
		game.update();

	}
	
}
