public abstract class SmartDevice
{

    string _name = "";
    bool _powerOn = false;
    long _poweredOnTime = 0;


    public SmartDevice(string name)
    {
        _name = name;
    }

    public bool DeviceIsOn()
    {
        return _powerOn;
    }

    public string Display()
    {
        return $"{_name}: {_powerOn} {this.GetRunTime()}";
    }

    public void TurnDeviceOn()
    {
        _powerOn = true;
        DateTime currentTime = DateTime.UtcNow;
        long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
        _poweredOnTime = unixTime;
    }

    public void TurnDeviceOff()
    {
        _powerOn = false;
        _poweredOnTime = 0;
    }

    public double GetRunTime()
    {
        if(_powerOn)
        {
            DateTime currentTime = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
            return unixTime - _poweredOnTime;
        }
        else
        {
            return 0;
        }
    }

}