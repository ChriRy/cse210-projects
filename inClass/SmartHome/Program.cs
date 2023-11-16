// See https://aka.ms/new-console-template for more information

House H = new House();
Room FrontRoom = new Room("Front Room");
H.AddRoom(FrontRoom);

SmartDevice FrontRoomLight = new SmartLight("Light Switch");
SmartDevice FrontRoomLamp = new SmartLight("Lamp");
FrontRoom.AddDevice(FrontRoomLamp);
FrontRoom.AddDevice(FrontRoomLight);
FrontRoomLight.TurnDeviceOn();
Console.WriteLine(FrontRoomLight.DeviceIsOn());
Thread.Sleep(3000);
Console.WriteLine(FrontRoomLight.GetRunTime());
Console.WriteLine(FrontRoomLight.Display());
FrontRoomLight.TurnDeviceOff();
FrontRoom.ListDevices();
FrontRoom.TurnOnAllLights();
H.ListDevices();
Thread.Sleep(3000);
H.ListDevices();


