Console.Clear();
Medication steve = new Medication("Steve from Accounting");
Counselor mike = new Counselor("Mike from HR");



Team party = new Team(steve);
party.AddPartyMember(mike);
party.AddGold(20);

List<Item> itemList = new List<Item>() { new Ether(), new Ether(), new Potion(), new Potion(), new Mtndew(), new Mtndew() };
party.AddItems(itemList);

// Shop store = new Shop(party);

List<Enemy> enemies = new List<Enemy>() { new Boredom(), new Anxiety(), new Loneliness() };

Battle round = new Battle(party, enemies);
round.BattleLoop();