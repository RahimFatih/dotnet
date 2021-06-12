package snakeData;

import java.awt.Rectangle;
import java.util.ArrayList;

public class Waz {
	private ArrayList<Rectangle> ogon;
	private int w = Gra.szer;
	private int h = Gra.wys;
	private int d = Gra.rozmiar;
	
	private String kierunek; //NOTHING, UP, DOWN, LEFT, RIGHT
	
	public Waz() {
		ogon = new ArrayList<>();
		
		Rectangle temp = new Rectangle(Gra.rozmiar, Gra.rozmiar);
		temp.setLocation(Gra.szer / 2 * Gra.rozmiar, Gra.wys / 2 * Gra.rozmiar);
		ogon.add(temp);
		
		temp = new Rectangle(d, d);
		temp.setLocation((w / 2 - 1) * d, (h / 2) * d);
		ogon.add(temp);
		
		temp = new Rectangle(d, d);
		temp.setLocation((w / 2 - 2) * d, (h / 2) * d);
		ogon.add(temp);
		
		kierunek = "NOTHING";
	}
	
	public void kierunek() {
		if(kierunek != "NOTHING") {
			Rectangle glowa = ogon.get(0);
			
			Rectangle temp = new Rectangle(Gra.rozmiar, Gra.rozmiar);
			
			if(kierunek == "UP") {
				temp.setLocation(glowa.x, glowa.y - Gra.rozmiar);
			}
			else if(kierunek == "DOWN") {
				temp.setLocation(glowa.x, glowa.y + Gra.rozmiar);
			}
			else if(kierunek == "LEFT") {
				temp.setLocation(glowa.x - Gra.rozmiar, glowa.y);
			}
			else{
				temp.setLocation(glowa.x + Gra.rozmiar, glowa.y);
			}
			
			ogon.add(0, temp);
			ogon.remove(ogon.size()-1);
		}
	}
	
	public void grow() {
		Rectangle glowa = ogon.get(0);
		
		Rectangle temp = new Rectangle(Gra.rozmiar, Gra.rozmiar);
		
		if(kierunek == "UP") {
			temp.setLocation(glowa.x, glowa.y - Gra.rozmiar);
		}
		else if(kierunek == "DOWN") {
			temp.setLocation(glowa.x, glowa.y + Gra.rozmiar);
		}
		else if(kierunek == "LEFT") {
			temp.setLocation(glowa.x - Gra.rozmiar, glowa.y);
		}
		else{
			temp.setLocation(glowa.x + Gra.rozmiar, glowa.y);
		}
		
		ogon.add(0, temp);
	}

	public ArrayList<Rectangle> getBody() {
		return ogon;
	}
	

	public void setBody(ArrayList<Rectangle> ogon) {
		this.ogon = ogon;
	}
	
	public int getX() {
		return ogon.get(0).x;
	}
	
	public int getY() {
		return ogon.get(0).y ;
	}
	
	public String getMove() {
		return kierunek;
	}
	
	public void up() {
		kierunek = "UP";
	}
	public void down() {
		kierunek = "DOWN";
	}
	public void left() {
		kierunek = "LEFT";
	}
	public void right() {
		kierunek = "RIGHT";
	}
}
