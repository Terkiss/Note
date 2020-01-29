package myprintf;

public class Jprint
{
    public Jprint()
    {

    }

    public static void print(String arr, Object...a)
    {
        String data = String.format(arr, a);
        System.out.print(data);
    }  
    public static void print(String arr)
    {
      
        System.out.print(arr);
    }   
}