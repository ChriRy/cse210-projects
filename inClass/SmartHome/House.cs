public class House
{
    List<Room> _rooms = new List<Room>();

    public void AddRoom(Room r)
    {
        _rooms.Add(r);
    }

    public void TurnOnAllDevices()
    {
        foreach (var room in _rooms)
        {
            room.TurnOnAllDevices();
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var room in _rooms)
        {
            room.TurnOffAllDevices();
        }
    } 
    public void ListDevices()
    {
        foreach (var room in _rooms)
        {
            room.ListDevices();
        }
    }   
}