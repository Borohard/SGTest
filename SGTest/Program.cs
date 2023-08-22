using SGTest;
using SGTest.Models;

using (ApplicationContext db = new ApplicationContext())
{
    JobTitle jobTitle1 = new JobTitle { Title = "Химик"};
    JobTitle jobTitle2 = new JobTitle { Title = "Старшина" };
    JobTitle jobTitle3 = new JobTitle { Title = "Звукорежиссёр" };

    db.JobTitles.AddRange(jobTitle1, jobTitle2, jobTitle3);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    var jobTitles = db.JobTitles.ToList();
    Console.WriteLine("Названия Должностей:");
    foreach (JobTitle jobTitle in jobTitles)
    {
        Console.WriteLine($"{jobTitle.Title}");
    }
}