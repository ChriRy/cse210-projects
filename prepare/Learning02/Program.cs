using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Microsoft" ,"Software Engingeer", 2019, 2022);

        Job job2 = new Job("Google", "Tech Developer", 2015, 2018);

        Resume resume1 = new Resume();
        resume1._employeeName = "Yolanda Father";

        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.ShowDetails();
    }
}