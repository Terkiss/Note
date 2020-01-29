package friend_ex;


public class HighFriend extends Friend
{
    String work;
    public HighFriend(String name, String phone, String addr, String job)
    {
        super(name, phone, addr);
        work = job;
    }

    public void showData()
    {
        super.ShowData();
        print("직업 %s", work);
    }

    public void showBasicInfo()
    {
        print("name : %s", name);
        print("phone : %s", phone);
    }

}