using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        // I think you have to put the name of the function once before bc it's saying what
        // data type, like string or int
        job1._companyName = "Dade County Library";
        job1._jobTitle = "Librarian";
        job1._startYear = 2021;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._companyName = "Church of Jesus Christ of Latter-day Saints";
        job2._jobTitle = "Missionary";
        job2._startYear = 2023;
        job2._endYear = 2025;

        // now to display
       // job1.DisplayJob();
        //job2.DisplayJob();

        Resume resume = new Resume();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.DisplayResume();
    }
}