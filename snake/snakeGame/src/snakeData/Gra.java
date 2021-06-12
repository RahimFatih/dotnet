package snakeData;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JFrame;

public class Gra 
implements KeyListener{
	private Waz gracz;
	private Jedzenie jedzenie;
	private Grafika grafika;
	
	private JFrame okno;
	
	public static final int szer = 30;
	public static final int wys = 30;
	public static final int rozmiar = 20;
	
	public Gra(){
		okno = new JFrame();
		
		gracz = new Waz();
		
		jedzenie = new Jedzenie(gracz);
		
		grafika = new Grafika(this);
		
		okno.add(grafika);
		
		okno.setTitle("Snake by Denis Firat & Kacper Gasieniec");
		okno.setSize(szer * rozmiar + 2, wys * rozmiar + rozmiar + 4);
		okno.setVisible(true);
		okno.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	
	public void start() {
		grafika.state = "RUNNING";
	}
	
	public void update() {
		if(grafika.state == "RUNNING") {
			if(kolizjaZJedzeniem()) {
				gracz.grow();
				jedzenie.random_spawn(gracz);
			}
			else if(kolizjaZjedzeniem() || kolizjaZSobą()) {
				grafika.state = "END";
			}
			else {
				gracz.kierunek();
			}
		}
	}
	
	private boolean kolizjaZjedzeniem() {
		if(gracz.getX() < 0 || gracz.getX() >= szer * rozmiar 
				|| gracz.getY() < 0|| gracz.getY() >= wys * rozmiar) {
			return true;
		}
		return false;
	}
	
	private boolean kolizjaZJedzeniem() {
		if(gracz.getX() == jedzenie.getX() * rozmiar && gracz.getY() == jedzenie.getY() * rozmiar) {
			return true;
		}
		return false;
	}
	
	private boolean kolizjaZSobą() {
		for(int i = 1; i < gracz.getBody().size(); i++) {
			if(gracz.getX() == gracz.getBody().get(i).x &&
					gracz.getY() == gracz.getBody().get(i).y) {
				return true;
			}
		}
		return false;
	}

	@Override
	public void keyTyped(KeyEvent e) {	}

	@Override
	public void keyPressed(KeyEvent e) {
		
		int keyCode = e.getKeyCode();
		
		if(grafika.state == "RUNNING") {
			if(keyCode == KeyEvent.VK_W && gracz.getMove() != "DOWN") {
				gracz.up();
			}
		
			if(keyCode == KeyEvent.VK_S && gracz.getMove() != "UP") {
				gracz.down();
			}
		
			if(keyCode == KeyEvent.VK_A && gracz.getMove() != "RIGHT") {
				gracz.left();
			}
		
			if(keyCode == KeyEvent.VK_D && gracz.getMove() != "LEFT") {
				gracz.right();
			}
		}
		else {
			this.start();
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {	}

	public Waz getPlayer() {
		return gracz;
	}

	public void setPlayer(Waz gracz) {
		this.gracz = gracz;
	}

	public Jedzenie getFood() {
		return jedzenie;
	}

	public void setFood(Jedzenie jedzenie) {
		this.jedzenie = jedzenie;
	}

	public JFrame getWindow() {
		return okno;
	}

	public void setWindow(JFrame okno) {
		this.okno = okno;
	}
	
}
