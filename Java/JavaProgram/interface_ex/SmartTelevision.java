package interface_ex;

public class SmartTelevision implements RemoteControl, Searchable
{
    int volume;
    @Override
    public void turnON() 
    {
        // TODO Auto-generated method stub
        System.out.println("스마트 tv를 켭니다");
    }

    @Override
    public void turnOFF()
    {
        // TODO Auto-generated method stub
        System.out.println("스마트 tv를 끕니다");
    }

    @Override
    public void setVolume(int volume) 
    {
        
        // TODO Auto-generated method stub
        if(volume > RemoteControl.MAX_VOLUME)
        {
            this.volume = RemoteControl.MAX_VOLUME;
        }
        else if(volume < RemoteControl.MIN_VOLUME)
        {
            this.volume = RemoteControl.MIN_VOLUME;
        }
        else
        {
            this.volume = volume;
        }

        System.out.println("현재  스마트 tv 볼륨 : "+this.volume);

    }

    @Override
    public void Search(String url) {
        // TODO Auto-generated method stub
        System.out.print("url 검색 완료 \n");
    }


    @Override
    public void setMute(boolean mute)
    {
        if(mute)
        {
            System.out.println("스마트 무음 처리 합니다.");
        }
        else
        {
            System.out.println("스마트 무음 해제 합니다.");
        }
    }
}