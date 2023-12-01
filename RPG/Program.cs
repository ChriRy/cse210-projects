Console.Clear();
Medication steve = new Medication("Steve from Accounting");
Medication mike = new Medication("Mike from HR");
Boredom boredom1 = new Boredom("Boredom 1");
Boredom boredom2 = new Boredom("Boredom 2");

Team party = new Team(steve);
party.AddPartyMember(mike);

List<Enemy> enemies = new List<Enemy>() { boredom1 };

Battle round = new Battle(party, enemies);
round.BattleLoop();

