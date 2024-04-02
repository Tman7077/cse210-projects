using System;
//www.plantuml.com/plantuml/png/fP3Dhi8W48NtF0NBUtFJi6_keZ4QjyO-W25bD1E1DipWJuplRfjI8bjTyZ7pdGCDiGuSdHMTrKHoSuFG8O5uY4eUZ6Qe9N50VvhE3drae5gYPo7-f59Ru3ME3j_1psyjZxRNhDHorGu0fkGZtUctuHcrqJaTxXEzz6Z4CzNPH-_7xDGc1IsRysePdurbT1Qky9nzD8ry8sklw5pMMJtGPxRbq-L_LUKd5p3LBbXERy2RwEmB
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity> // list of example activities
        {
            new Running("April 1st", 20, 2),
            new Biking("April 2nd", 30, 20),
            new Swimming("April 3rd", 40, 80)
        };

        // display the summary for each activity
        foreach (Activity a in activities)
        {
            a.GetSummary();
        }
    }
}