using System;

class Program
{
    static void Main(string[] args)
    {
        
        Job job1 = new Job();
        job1._position = "Route Manager";
        job1._company = "Aptive";
        job1._startYear = 2020;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._position = "Associate";
        job2._company = "In-N-Out";
        job2._startYear = 2020;
        job2._endYear = 2023;

        Resume resume = new Resume();
        resume._name = "Tyler Bartle";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}