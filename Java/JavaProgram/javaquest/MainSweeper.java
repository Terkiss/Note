import java.util.Scanner;

public class MainSweeper {
    public static void main(String[] args) {
        
        Scanner sc = new Scanner(System.in);

        System.out.println("x 범위 y 범위를 입력 해주세요");
        String input = sc.nextLine();

        System.out.print("입력 받은거" + input+" 길이 "+input.length()+"\n");

        System.out.print(input.indexOf(" "));
 
        System.out.print( "ddd "+input.substring(0, 1) );
        int index = input.indexOf(" ");
        int xPos = Integer.parseInt(input.substring(0, index) );
        System.out.print("\nxpos :: "+xPos );
     
        int yPos = Integer.parseInt( input.substring(index+1, input.length() ));
        System.out.print("\nypos :: "+yPos );

        String mineData[][] = new String[yPos][xPos];

        for(int i = 0; i < yPos; i++)
        {
            System.out.print("지뢰를 입력 해주세요 :: ");
            String tempMine = sc.nextLine();

            if(tempMine.length() > xPos)
            {
                System.out.println("다시 입력해요 ");
                i--;
            }
            else
            {
                for(int j = 0; j < xPos; j++)
                {
                    char charact = tempMine.charAt(j);

                    if( String.valueOf(charact).equals("."))
                    {
                        mineData[i][j] = "0";
                    }
                    else if( String.valueOf(charact).equals("*"))
                    {
                        mineData[i][j] = String.valueOf(charact);
                    }
                
                }
            }

        }

        view(mineData);
        System.out.println(" ");
        mineCheck(mineData);
        view(mineData);
        sc.close();

    }

    public static void view(String mineData[][])
    {

        for(int i = 0; i < mineData.length; i++)
        {


            for(int j = 0; j < mineData[i].length; j++)
            {
                System.out.print(mineData[i][j]+" ");
            }
            System.out.print("\n");

        }
    }
    public static void mineCheck(String mineData[][])
    {
        for(int i = 0 ; i < mineData.length; i++)
        {
            for(int j = 0; j < mineData[i].length; j++)
            {
                String current = mineData[i][j];
                if(current.equals("*"))
                {
                    if( i-1 >= 0 )
                    {
                        mineData[i-1][j] =mineNumberIncreament(mineData[i-1][j]);
                    }
                    if( i+1 < mineData.length )
                    {
                        mineData[i+1][j] =mineNumberIncreament(mineData[i+1][j]);
                    }
                    if( j+1 < mineData[i].length )
                    {
                        mineData[i][j+1] =mineNumberIncreament(mineData[i][j+1]);
                    }
                    if( j-1 >= 0 )
                    {
                        mineData[i][j-1] =mineNumberIncreament(mineData[i][j-1]);
                    }
                    if( ( i-1 >= 0 ) && ( j-1 >= 0) )
                    {
                        mineData[i-1][j-1] =mineNumberIncreament(mineData[i-1][j-1]);
                    }
                    if( ( i-1 >= 0 ) && ( j+1 < mineData[i].length ) )
                    {
                        mineData[i-1][j+1] =mineNumberIncreament(mineData[i-1][j+1]);
                    }
                    if( ( i+1 < mineData.length ) && ( j-1 >= 0) )
                    {
                        mineData[i+1][j-1] =mineNumberIncreament(mineData[i+1][j-1]);
                    }
                    if( ( i+1 < mineData.length ) && ( j+1 < mineData[i].length ) )
                    {   
                        
                        mineData[i+1][j+1] =mineNumberIncreament(mineData[i+1][j+1]);
                    }
                }
            }
        }
    }
    public static String mineNumberIncreament(String str)
    {
        if(str.equals("*"))
        {
            return str;
        }
        int data = Integer.parseInt(str);
        data++;
        return String.valueOf(data);
    }
}