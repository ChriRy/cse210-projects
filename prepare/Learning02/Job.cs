public class Job {
    
    public string _company;

    public string _jobTitle;

    public int _startYear;

    public int _endYear;

    public Job(string company, string jobTitle, int startYear, int endYear) 
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;

    }

    public void DisplayJobDetails() 
    {
        Console.WriteLine($"{_company} ({_jobTitle}) {_startYear}-{_endYear}");
    }
}