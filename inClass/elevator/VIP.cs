public class VIP : Elevator
{
    private string _code = "1111";
    private bool _authenticate = false;

    public VIP(int currentFloor, int floorCount) : base(currentFloor, floorCount)
    {
        _currentFloor = currentFloor;
        _floorCount = floorCount;
    }

    public void Authenticate()
    {
        bool loop = true;

        while (loop)
        {
            Console.WriteLine("Please enter VIP password: ");
            string attempt = Console.ReadLine();

            if (attempt == _code)
            {
                _authenticate = true;
                loop = false;
            }
            else
            {
                Console.WriteLine("Password incorrect. Please try again. ");
            }
        }
    }

    public void ListFloorsVIP()
    {
        Authenticate();
        if (_authenticate == true)
        {
            base.ListFloors();
        }
    }

}