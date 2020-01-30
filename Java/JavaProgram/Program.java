import virtualfunction.*;
import polymorphism.*;

import java.util.Scanner;

import friend_ex.FriendInfoHandler;
import innerclass.InerClass;
import interface_ex.*;
import myprintf.Jprint;

// 다형성 
public class Program {
    public static void main(String[] args) {

        // Testa ts = new Testa();

        // ts.aaa();

        // Program pg = new Program();
        // pg.mpveAnimal(new Eagle());
        // pg.mpveAnimal(new Human());
        // pg.mpveAnimal(new Tiger());

        // Customer customer = new Customer();
        
        // 고등 학교 대학 친구
        // MyFriendInfoBook my = new MyFriendInfoBook();
        // my.run();

        InerClass a = new InerClass();
        

    }

    public void mpveAnimal(Animal ani) {
        ani.move();
    }
}

class RemoteControl_Example {
    public void run() {
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

class MyFriendInfoBook {
    public void run() {
        FriendInfoHandler handler = new FriendInfoHandler(10);
        while (true) {
            Jprint.print("*** 메뉴 선택 ***");
            Jprint.print("1. 고교 정보 저장");
            Jprint.print("2. 대학 친구 저장");
            Jprint.print("3. 전체 정보 출력");
            Jprint.print("4. 기본 정보 출력");
            Jprint.print("5. 프로그램 종료");
            Jprint.print("선택>> ");
            Scanner sc = new Scanner(System.in);

            int choice = sc.nextInt();

            switch (choice) {
            case 1:
                handler.addfriend(choice);
                break;
            case 2:
                handler.addfriend(choice);
                break;
            case 3:
                handler.showAllData();
                break;
            case 4:
                handler.showAllSimpleData();
                break;
            case 5:
                Jprint.print("프로그램을 종료 합니다 . ");
                return;

            }
        }
    }
}
