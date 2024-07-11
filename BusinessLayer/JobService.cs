using DataBaseWinforms.DataAccessLayer;
using DataBaseWinforms.Entities;
using System.Collections.Generic;

namespace DataBaseWinforms.BusinessLayer
{
    public class JobService
    {
        private JobCRUD _jobcrud;

        public JobService()
        {
            _jobcrud = new JobCRUD();
        }

        public List<Job> GetJobsList()
        {
            return _jobcrud.GetJobsListFromDB();
        }
    }
}
