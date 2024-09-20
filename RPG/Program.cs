Console.Clear();
Medication steve = new Medication("Steve from Accounting");
Counselor mike = new Counselor("Mike from HR");

Team party = new Team(steve);
party.AddPartyMember(mike);

party.AddGold(20);

List<Item> itemList = new List<Item>() { new Ether(), new Snickers(), new Potion(), new Redbull(), new Mtndew(), new Mtndew() };
party.AddItems(itemList);

Shop store = new Shop(party);

List<Enemy> enemies = new List<Enemy>() { new Boredom("Monster 1"), new Anxiety("Monster 2"), new Loneliness("Monster 3") };

// Battle round = new Battle(party, enemies);
// round.BattleLoop();



Cutscene intro = new Cutscene("textfiles/intro.txt");
Console.Clear();

Console.WriteLine("Hero, what is your name? ");
string name = Console.ReadLine()!;
Medication hero = new Medication(name);
party = new Team(hero);
Console.Clear();

Cutscene tutorial = new Cutscene("textfiles/tutorial.txt");

List<Enemy> enemies1 = new List<Enemy>() { new Boredom() };
Battle round1 = new Battle(party, enemies1);

Cutscene scene1 = new Cutscene("textfiles/scene1.txt");
Counselor thera = new Counselor("Thera");
party.AddPartyMember(thera);
List<Enemy> enemies2 = new List<Enemy>() { new Boredom(), new Anxiety(), new Loneliness() };
Battle round2 = new Battle(party, enemies2);

Cutscene scene2 = new Cutscene("textfiles/scene2.txt");
Shop shop = new Shop(party);

Cutscene scene3 = new Cutscene("textfiles/scene3.txt");

