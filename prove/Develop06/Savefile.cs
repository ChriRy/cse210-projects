using System.Collections;
using System.IO;

public class Savefile
{
    string _filename;

    public Savefile(string filename, string name = "Empty")
    {
        _filename = filename;
    }

    public void DisplayFile(int i)
    {
        if (File.Exists($"file{i}.txt"))
        {
            string[] lines = System.IO.File.ReadAllLines(_filename);
            string userLine = lines[0];
            string[] userArray = userLine.Split(":");
            string[] userData = userArray[1].Split("|");

            string name = userData[0];
            string rank = userData[1];
            int level = Convert.ToInt16(userData[3]);

            Console.WriteLine($"Profile {i}: {name} - Level {level} {rank}");
        }
        else
        {
            Console.WriteLine($"Profile {i}: Empty");
        }
    }

    public string GetFilename()
    {
        return _filename;
    }

    public User Load()
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);

        //create user
        string userLine = lines[0];
        string[] userArray = userLine.Split(":");
        string[] userData = userArray[1].Split("|");
        User user = CreateUser(userData);

        //create goals
        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            string classify = parts[0];
            string dataLine = parts[1];
            string[] data = dataLine.Split("|");

            if (classify != "User")
            {
                var goal = CreateGoal(data);
                user.AddGoal(goal);
            }
        }

        return user;
    }

    public void Save(User user, string message = "Save Successful")
    {
        string userData = user.Stringify();
        List<Goal> goalList = user.GetGoals();

        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            outputFile.WriteLine(userData);

            foreach (Goal goal in goalList)
            {
                string goalData = goal.Stringify();
                outputFile.WriteLine(goalData);
            }
        }

        Console.WriteLine(message);
    }

    // basically a reset
    public void Delete()
    {

    }

    public User CreateUser(string[] data)
    {
        string name = data[0];
        string rank = data[1];
        int exp = Convert.ToInt16(data[2]);
        int level = Convert.ToInt16(data[3]);

        User user = new User(name, rank, exp, level);
        return user;
    }

    public Goal CreateGoal(string[] data)
    {
        string type = data[0];
        string name = data[1];
        string description = data[2];
        int difficulty = Convert.ToInt16(data[3]);
        int hp = Convert.ToInt16(data[4]);
        bool defeat = Convert.ToBoolean(data[5]);
        int defeatCount = 0;
        if (type == "Eternal")
        {
            defeatCount = Convert.ToInt16(data[6]);
        }

        switch (type)
        {
            case "Simple":
                Goal goal = new Goal(name, description, difficulty, defeat);
                return goal;
            case "Checklist":
                Checklist list = new Checklist(hp, name, description, difficulty, defeat);
                return list;
            case "Eternal":
                Eternal eternal = new Eternal(name, description, difficulty, defeat, defeatCount);
                return eternal;
            default:
                Goal basic = new Goal(name, description, difficulty, defeat);
                return basic;
        }
    }



}