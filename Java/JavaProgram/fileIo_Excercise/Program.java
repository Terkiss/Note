import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutput;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.io.RandomAccessFile;
import java.util.ArrayList;
import java.util.List;

public class Program {

    public static void main(String[] args) throws Exception {
       // 기본 자료형의 데이터 입출력
        // System.out.print("dd");
        // OutputStream out;
    
        // out = new FileOutputStream("data.bin");
      
        // DataOutputStream filter = new DataOutputStream(out);
        // filter.writeInt(275);
        // filter.writeDouble(45.79);
        // filter.close();


        // InputStream in= new FileInputStream("data.bin");
        // DataInputStream InFilter = new DataInputStream(in);
        // double num2 = InFilter.readDouble();
        // int num = InFilter.readInt();
      

        // System.out.print(" 1번 "+ num +"  2번 "+num2);

        // InFilter.close();

        


        // 버퍼링 기능을 제공하는 필터 스트림
        // InputStream input =new FileInputStream("cyt.bin");
        // OutputStream output = new FileOutputStream("cyt2.bin");

        // BufferedInputStream buffer_Input = new BufferedInputStream(input);
        // BufferedOutputStream buffer_Output = new BufferedOutputStream(output);

        // int copyData = 0;
        // int bdata ;

        // while(true)
        // {
        //     bdata=buffer_Input.read();
        //     System.out.print("바이트 크기 "+bdata +" \n");
        //     if(bdata == -1)
        //     {
        //         break;
        //     }
        //     buffer_Output.write(bdata);
        //     copyData++;
        // }

        // buffer_Input.close();
        // buffer_Output.close();
        // System.out.print("복사한 바이트 크기 "+copyData );





        // 파일에 Double형 데이터 저장 + 버퍼링 적용
        // OutputStream output = new FileOutputStream("cyt2.bin");
        // BufferedOutputStream buffer_Output = new BufferedOutputStream(output);
        // DataOutputStream dataOutput = new DataOutputStream(buffer_Output);

        // dataOutput.writeInt(20);
        // dataOutput.writeDouble(222.22);
        // buffer_Output.close();


        // InputStream input =new FileInputStream("cyt2.bin");
        // BufferedInputStream buffer_Input = new BufferedInputStream(input);
        // DataInputStream dataInput = new DataInputStream(buffer_Input);

        // int copyData = dataInput.readInt();
        // double data = dataInput.readDouble() ;
        // buffer_Input.close();

        // System.out.print("1번  "+copyData+"  2번  "+data );





    //     BufferedWriter bufWrite = new BufferedWriter(new FileWriter("Text.txt"));
    //     bufWrite.write("오우 안녕하세요 ");
    //     bufWrite.newLine();
    //     bufWrite.write("오우 안녕하세요 ");
    //     bufWrite.newLine();
    //     bufWrite.write("22222 ");
    //     bufWrite.newLine();
    //     bufWrite.write("33333 ");
    //     bufWrite.newLine();
    //     bufWrite.write("44444 ");
    //     bufWrite.newLine();
    //     bufWrite.write("5555 ");
    //     bufWrite.newLine();
    //     bufWrite.close();
    //     System.out.println("문자 입력 완료");


    //     BufferedReader reader = new BufferedReader(new FileReader("Text.txt"));

    //         String str;
    //         while(true)
    //         {
    //             str = reader.readLine();
    //             if(str == null)
    //             {
    //                 break;
    //             }

    //             System.out.println("str :: "+str);
    //         }
    //         reader.close();
    // }


        // ObjectInputStream  && ObjectOutPutStream


        // 인스턴스 저장 
        // ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream("data.ser"));
        // out.writeObject(new Circle(1,1,2.4));
        // out.writeObject(new Circle(2,2, 4.8));
        // out.writeObject(new Circle(2, 3, 22));

        // out.writeObject(new String("String implements Serializable"));

        // out.close();

        // 인스턴스 복원

        // ObjectInputStream in = new ObjectInputStream(new FileInputStream("data.ser"));
        // Circle c1  = (Circle)in.readObject();
        // Circle c2 = (Circle)in.readObject();
        // Circle c3 = (Circle) in.readObject();
        // String data = (String)in.readObject();

        // in.close();

        // c1.showCircle();
        // c2.showCircle();
        // c3.showCircle();
        // System.out.println(data);



        // Random AccessFile 클래스
        // 데이터를 읽고 쓰고 할수 있음 
        // RandomAccessFile randFile = new RandomAccessFile("data.bin", "rw");

        // randFile.writeInt(222);
        // randFile.writeInt(3131);
        
        // randFile.seek(0);
        // int data = randFile.readInt();
        // int data2 = randFile.readInt();
   
        // randFile.close();

        // System.out.println("aaa aaaa "+data +"   "+data2);


        // File 클래스
        
        // 디렉터리 생성        
        // File mydir = new File("F:/Project/Java/Note/Java/JavaProgram/fileIo_Excercise/data");
        // mydir.mkdir();



        // 파일 이동
        // File my = new File("F:/Project/Java/Note/Java/JavaProgram/fileIo_Excercise/data.bin");
        // File re = new File("F:/Project/Java/Note/Java/JavaProgram/fileIo_Excercise/data/data.bin");

        // my.renameTo(re);
        File my = new File("D:"+File.separator+"75ad788e939b81dc.mp4");
        File out =  new File("B:"+File.separator+"data.mp4");

        FileInputStream inMyFile = new FileInputStream(my);
       if(my.exists() == false)
       {
           System.out.print("파일이 없다 \n");
       }
        ArrayList<byte[]> Filedata = new ArrayList<>();
        while(true)
        {
            int size;
            byte[] localData = new byte[1024];

            size = inMyFile.read(localData);
            if(size == -1)
            {
                System.out.println(" 파일의 끗 입니다 ");
                break;
            }
            else
            {
                Filedata.add(localData);
            }
        }

        inMyFile.close();
        
        FileOutputStream outMyFile = new FileOutputStream(out);
        for(int i = 0; i <  Filedata.size(); i++)
        {
            outMyFile.write(Filedata.get(i));
            System.out.println(i+ "번쨰 데이터의 입력 완료");
        }
        outMyFile.close();
      
    }
}

