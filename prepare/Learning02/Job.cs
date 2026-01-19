public class Job
{
    // variables for company, job title, start year, end year
    public string _companyName;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void DisplayJob()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_startYear}-{_endYear}");
    }
}