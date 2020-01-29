package interface_ex;

public class Audio implements RemoteControl
{
    int volume;
    @Override
    public void turnON() 
    {
        // TODO Auto-generated method stub
        System.out.println("audio 를 켭니다");
    }

    @Override
    public void turnOFF()
    {
        // TODO Auto-generated method stub
        System.out.println("audio 를 끕니다");
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

        System.out.println("현재 audio 볼륨 : "+this.volume);

    }
}