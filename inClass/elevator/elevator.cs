public class Elevator
{
    protected int _currentFloor;
    protected bool _doorOpen = false;
    protected int _floorCount;

    public Elevator(int currentFloor, int floorCount)
    {
        _currentFloor = currentFloor;
        _floorCount = floorCount;
    }

    public void OpenDoor()
    {
        _doorOpen = true;
    }

    public void CloseDoor()
    {
        _doorOpen = false;
    }

    public void MoveToFloor(int floor)
    {
        _currentFloor = floor;
        Console.WriteLine($"Moving to Floor {floor}");
    }

    public void DisplayFloor()
    {
        Console.WriteLine($"Current Floor: {_currentFloor}");
    }

    public void ListFloors()
    {
        for (int i = 1; i <= _floorCount; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

}