import java.util.Scanner;

public class javaprogram {
    public static void main(String[] args) {
        int input1, input2;
        int maxCycle = 0;

        Scanner sc =new Scanner(System.in);
        
        System.out.println("수의 범위를 지정 하시오 ");
        
        System.out.print(" 수를 입력 하세오  ");
        input1 = sc.nextInt();

        System.out.print( " 수를 입력 하세요 " );
        input2 = sc.nextInt();


        if(input2 < input1)
        {
            int temp = input1;

            input1 = input2;

            input2 = temp;
        }


        for(int i = input1 ; i <= input2; i++ )
        {
            int current = i;
            int currentCycle  = 1 ; 
            while(current != 1 && current > 0)
            {
                if(current % 2  == 0 )
                {
                    current = current /2 ;
    
                }
                else if(current % 2 == 1)
                {
                    current = current * 3 ;
                    current++;
                }

                currentCycle++;
               
            }
            if(maxCycle < currentCycle)
            {
                maxCycle = currentCycle;
            }
        }

       
        System.out.print(input1+", "+input2+", "+maxCycle);
    }
}