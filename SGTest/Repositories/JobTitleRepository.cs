using SGTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Repositories
{
    public class JobTitleRepository : IDisposable
    {
        private ApplicationContext _context;
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

        public bool IsJobTitleExist(string? title)
        {
            var employee = _context.JobTitles.Where(x => x.Title == title).FirstOrDefault();
            return employee != null ? true : false;
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
