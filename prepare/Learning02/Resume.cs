public class Resume 
{
    public string _employeeName;
    public List<Job> _jobs = new List<Job>();

    public void ShowDetails() 
    {
        Console.WriteLine($"Name: {_employeeName}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}