package friend_ex;

import myprintf.*;
import java.util.Scanner;

public class FriendInfoHandler 
{
    private Friend[] myFriends;
    private int numOfFriends;

    public FriendInfoHandler(int num)
    {
        myFriends = new Friend[num];
        numOfFriends = 0;
    }
    private void addFirendInfo(Friend fren)
    {
        myFriends[numOfFriends++] = fren;
    }
    public void addfriend(int choice)
    {
        String name, phoneNum, addr, job, major;
        Scanner sc = new Scanner(System.in, "euc-kr");


        Jprint.print("이름 : ");
        name = sc.nextLine();

        Jprint.print("전화 : ");
        phoneNum = sc.next();

        Jprint.print("주소 : ");
        addr = sc.next();
        Jprint.print("name : %s, phone : %s, job : %s",name,phoneNum, addr);
        if(choice == 1)
        {
            Jprint.print("직업 : ");
            job = sc.nextLine();
          
            addFirendInfo(new HighFriend(name, phoneNum, addr, job));
        }
        else
        {
            Jprint.print("학과 : ");
            major = sc.nextLine();

            addFirendInfo(new UnivFriend(name, phoneNum, addr, major));
        }

    }



    public void showAllData()
    {
        for(int i = 0; i < numOfFriends ; i++)
        {
            myFriends[i].ShowData();
            Jprint.print("");
        }
    }


    
    public void showAllSimpleData()
    {
        for(int i = 0; i < numOfFriends ; i++)
        {
            myFriends[i].showBasicInfo();
            Jprint.print("");
        }
    }
}