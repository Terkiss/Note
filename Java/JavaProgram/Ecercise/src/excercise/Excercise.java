package excercise;

import java.util.*;
public class Excercise {
	public Excercise()
	{
		
	}
	public void run()
	{
		
		Random random = new Random();
		Scanner sc = new Scanner(System.in);
		
		System.out.print("������ �ִ밪 �Է� ���ּ���");
		int randMax =  sc.nextInt();
		int result[] = new int[50];
		
		for(int i = 0 ; i < result.length; i++)
		{
			result[i] =  random.nextInt(randMax);
			
		}
		System.out.println("�ټ������");
		showData(result);
		System.out.println("----------------");
		resultForSort(result);
		System.out.println("�ټ����� ");
		showData(result);
		
	}
	public void showData(int[] data)
	{
		for(int i =0; i<data.length; i++)
		System.out.println(data[i]);
	}
	public void resultForSort(int[] data)
	{
		int i=0, j=0;
		int processingData=0;
		
		while(i<data.length)
		{
			processingData = data[i];
			for(j = i -1; j>=0&&data[j] > processingData; j-- )
			{
				data[j + 1] = processingData;
			}
			data[j+1] = processingData;
			i++;
		}
	}
}
