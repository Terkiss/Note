import virtualfunction.*;
import polymorphism.*;
import interface_ex.*;

// 다형성 
public class Program
{
    public static void main(String[] args)
    {
        
        // Testa ts = new Testa();

        // ts.aaa();

        //Program pg = new Program();
        // pg.mpveAnimal(new Eagle());
        // pg.mpveAnimal(new Human());
        // pg.mpveAnimal(new Tiger());

        // Customer customer = new Customer();
        
       RemoteControl_Example ex = new RemoteControl_Example();
       ex.run();
    }

    public void mpveAnimal(Animal ani)
    {
        ani.move();
    }
}
class RemoteControl_Example
{
    public void run()
    {
        RemoteControl rc;
        rc = new Television();
        rc.turnON();
        rc.setVolume(5);
        rc.turnOFF();
        rc.setMute(true);


        rc = new Audio();
        rc.turnON();
        RemoteControl.changeBattery();
        rc.setVolume(10);
        rc.turnOFF();

        SmartTelevision tv = new SmartTelevision();
        rc = tv;
        rc.setMute(true);
        Searchable sc = tv;
        rc.turnON();
        sc.Search("http://www.naver.com");
        rc.setVolume(1515);
        rc.turnOFF();

    }
}


