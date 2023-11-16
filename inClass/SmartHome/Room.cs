public class Room
{
    string _name = "";
    List<SmartDevice> _devices = new List<SmartDevice>();

    public Room(string name)
    {
        _name = name;
    }

    public void AddDevice(SmartDevice d)
    {
        _devices.Add(d);
    }

    public void ListDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine(device.Display());
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var device in _devices)
        {
            device.TurnDeviceOff();
        }
    }

    public void TurnOnAllDevices()
    {
         foreach (var device in _devices)
        {
            device.TurnDeviceOn();
        }       
    }

    public void TurnOnAllLights()
    {
         List<SmartLight> lights= _devices.OfType<SmartLight>().ToList(); 
         foreach (var device in lights)
        {
                device.TurnDeviceOn();
        }        
    }
}