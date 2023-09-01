using SGTest.Models;

namespace SGTest.Repositories
{
    public class JobTitleRepository : IDisposable
    {
        private readonly ApplicationContext _context;
        public JobTitleRepository()
        {
            _context = new ApplicationContext();
        }

        public JobTitle Get(int id)
        {
            var title = _context.JobTitles.Find(id);
            return title;
        }

        public int GetJobTitleID(string? title)
        {
            var jobTitle = _context.JobTitles.Where(x => x.Title == title).FirstOrDefault();
            return jobTitle != null ? jobTitle.Id : 0;
        }

        public JobTitle? IsJobTitleExist(string? title)
        {
            var jobTitle = _context.JobTitles.Where(x => x.Title == title).FirstOrDefault();
            return jobTitle != null ? jobTitle : null;
        }

        public List<JobTitle> GetAllJobTitles()
        {
            var allTitles = _context.JobTitles.ToList();
            return allTitles;
        }

        public void Add(JobTitle title)
        {
            _context.JobTitles.Add(title);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
