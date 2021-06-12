package snakeData;

import java.awt.Rectangle;
import java.util.concurrent.TimeUnit;

public class Jedzenie {
	private int x;
	private int y;
	Thread thread = new Thread(() -> {
		while(true){

			int newX = x-(int)(Math.random() * 2);
			int newY= y-(int)(Math.random() * 2);
			if (newX>0 && newX<Gra.szer-1){
				x=newX;
			}
			if (newY>0 && newY<Gra.wys-1){
				y=newY;
			}
			try {
				TimeUnit.SECONDS.sleep(1);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
		
	});
	public Jedzenie(Waz player) {
		this.random_spawn(player);
		thread.start();
	}

	public void random_spawn(Waz player) {
		boolean kolizjaWaz = true;
		while(kolizjaWaz) {
			kolizjaWaz = false;
			
			x = (int)(Math.random() * Gra.szer - 1);
			y = (int)(Math.random() * Gra.wys - 1);
			
			for(Rectangle r : player.getBody()){
				if(r.x == x && r.y == y) {
					kolizjaWaz = true;
				}
			}
		}
	}

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}
}
