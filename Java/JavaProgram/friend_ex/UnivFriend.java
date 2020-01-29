package friend_ex;

public class UnivFriend extends Friend
{
    String major;

    public UnivFriend(String name, String phone, String addr, String major) {
        super(name, phone, addr);
        this.major = major;
        showBasicInfo();
    }

    public void showData()
    {
        super.ShowData();
        print("전공 : %s",  major);
    }

    public void showBasicInfo()
    {
        print("이름 : %s", name);
        print("전화 : %s", phone);
        print("전공 : %s", major);
    }
    
}