public class SmartHeater : SmartDevice
{
    int _temp = 0;

    public SmartHeater(string name, int temp) : base(name)
    {
        _temp = temp;
    }

    
}