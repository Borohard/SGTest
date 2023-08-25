using SGTest.DTO.Models;
using SGTest.Models;
using SGTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
