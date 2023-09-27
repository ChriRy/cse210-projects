// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Players
Player joanna = new Player("Joanna Mother", 21);
Player yoshi = new Player("Yoshi Fauter", 42);
Player steve = new Player("Steve From Accounting", 84);
Player meredith = new Player("Meredith from HR", 168);
Player harambe = new Player("Harambe", 0);
Player grumpy = new Player("Grumpy Cat", 00);
Player gabe = new Player("Gabe Dog", 000);

// Teams
Team rents = new Team("'Rents");
rents.AddPlayer(joanna);
rents.AddPlayer(yoshi);

rents.DisplayRoster();

Team corporate = new Team("Corporate");
corporate.AddPlayer(steve);
corporate.AddPlayer(meredith);

corporate.DisplayRoster();

Team revivals = new Team("Revivals");
revivals.AddPlayer(harambe);
revivals.AddPlayer(grumpy);
revivals.AddPlayer(gabe);

revivals.DisplayRoster();


