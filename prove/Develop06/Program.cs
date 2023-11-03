bool loop = true;

while (loop)
{
    Console.WriteLine("Menu Options: ");
    Console.WriteLine(" 1. Start Breathing Activity");
    Console.WriteLine(" 2. Start Reflecting Activity");
    Console.WriteLine(" 3. Start Listing Activity");
    Console.WriteLine(" 4. Quit");

    Console.WriteLine("Select a choice from the menu: ");
    var choice = Console.ReadLine();
    int i = Convert.ToInt16(choice);

    switch (i)
    {
        case 1:
            Breathing activity1 = new Breathing();
            activity1.BreatheActivity();
            break;
        case 2:
            Reflecting activity2 = new Reflecting();
            activity2.ReflectActivity();
            break;
        case 3:
            Listing activity3 = new Listing();
            activity3.ListActivity();
            break;
        case 4:
            Console.WriteLine("Have a nice day!");
            loop = false;
            break;
    }
}
