package interface_ex;



public class Television implements RemoteControl
{
    int volume;
    @Override
    public void turnON() 
    {
        // TODO Auto-generated method stub
        System.out.println("tv를 켭니다");
    }

    @Override
    public void turnOFF()
    {
        // TODO Auto-generated method stub
        System.out.println("tv를 끕니다");
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

        System.out.println("현재 tv 볼륨 : "+this.volume);

    }
    
}