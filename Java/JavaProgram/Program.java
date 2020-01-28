import virtualfunction.*;
import polymorphism.*;

// 다형성 
public class Program
{
    public static void main(String[] args)
    {
        
        // Testa ts = new Testa();

        // ts.aaa();

        Program pg = new Program();
        pg.mpveAnimal(new Eagle());
        pg.mpveAnimal(new Human());
        pg.mpveAnimal(new Tiger());

        Customer customer = new Customer();
        
       
    }
    public void mpveAnimal(Animal ani)
    {
        ani.move();
    }
}