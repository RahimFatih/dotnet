package snakeData;

public class czlon {
    public int cordX;
    public int cordY;

    public czlon(int x, int y)
    {
        cordX = x;
        cordY= y;
    }
    public void printCzlon()
    {
        for(int i=0;i<10;i++){
            String linia="";
            if (i!=cordY)
            {
             for(int j=0;j<10;j++)
             {
                linia=linia+"-";
             }
            }
            else
            {
                for(int j=0;j<10;j++)
                {
                    if(j!=cordY){
                        linia=linia+"-";
                    }
                   else{
                       linia=linia+"O";
                   }
                }
            }
            System.out.println(linia);
        }
    }
    

}