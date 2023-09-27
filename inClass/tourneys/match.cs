public class Match
{
    private Team _team1;
    private Team _team2;

    public Match(Team team1, Team team2)
    {
        _team1 = team1;
        _team2 = team2;
    }

    public void DecideWin()
    {
        Console.WriteLine("Which team won?");
        Console.WriteLine($"{_team1.GetTeamName}");
        Console.WriteLine($"{_team2.GetTeamName}");
        string winner = Console.ReadLine();
        if(winner == "1")
        {
            _team1.AddWin();
            _team2.AddLosses();
        }
        else
        {
            _team1.AddLosses();
            _team2.AddWin();
        }
    }
}