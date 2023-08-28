using SGTest.DTO.Models;
using SGTest.Models;
using SGTest.Repositories;

namespace SGTest.DTO.Services
{
    internal class JobTitleService
    {
        public void SaveJobTitle(JobTitleDTO jobTitleDto)
        {
            JobTitle jobTitle = new JobTitle();
            jobTitle.Title = jobTitleDto.Title;

            using (var jobTitleRepository = new JobTitleRepository())
            {
                var isJobTitleExist = jobTitleRepository.IsJobTitleExist(jobTitle.Title);
                if (!isJobTitleExist)
                {
                    jobTitleRepository.Add(jobTitle);
                }
            }

        }
    }
}
