package innerclass;

public class InerClass
{
    wojin a;
    public InerClass()
    {
        System.out.print("메인 생성자\n");

        a = new wojin();
    }
    class wojin
    {
        wojin()
        {
            System.out.print("우진넴의 생성자\n");
        }
    }
}