package friend_ex;

import myprintf.*;

public class Friend extends Jprint
{
    String name;
    String phone;
    String addr;
    

    /** 생성 자  */
    public Friend(String name, String phone, String addr)
    {
        this.name = name;
        this.phone = phone;
        this.addr = addr;
    }

    public void ShowData()
    {
        print("이름 : %s", name);
        print("전화 : %s", phone);
        print("주소 : %s", addr);

    }
    public void showBasicInfo(){}

    
}