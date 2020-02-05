package anoymous;

public class Anonymous
{
    public Anonymous()
    {
        
    }

    public Person field = new Person(){
        void work()
        {
            System.out.print("출근 합니다 . \n");
        }

        public void wake()
        {
            System.out.println("6시에 일어 납나다 ");
            work();
        }
    
    };
    public void methods()
    {
        Person localVar = new Person(){
            void walk()
            {
                System.out.println("산책 합니다");
            }    

            public void wake()
            {
                System.out.println("7시에 일어납니다. ");
                walk();
            }
        };

        localVar.wake();



    }

    public void methods2(Person person)
    {
        person.wake();
    }

}