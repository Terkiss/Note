import java.io.Serializable;

public class Circle implements Serializable{
    int xpos;
    int ypos;
    double radius;
    public Circle(int xpos, int ypos, double radius) {
        this.xpos = xpos;
        this.ypos = ypos;
        this.radius = radius;
    }

    public void showCircle()
    {
        System.out.printf("[ %d, %d] \n", xpos, ypos);

        System.out.printf("radius ::  %f", radius);
    
    }
}