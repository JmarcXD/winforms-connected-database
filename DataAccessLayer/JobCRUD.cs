using DataBaseWinforms.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseWinforms.DataAccessLayer
{
    public class JobCRUD
    {
        private SqlConnection _connection;

        public JobCRUD()
        {
            ConnectionDatabase cd = new ConnectionDatabase();
            _connection = cd.SqlConnection;
        }

        public List<Job> GetJobsListFromDB()
        {
            List<Job> jobs = new List<Job>();

            _connection.Open();
            try
            {

                string query = "SELECT * FROM jobs;";
                SqlCommand cmd = new SqlCommand(query, this._connection);

                // Recuperamos un lector...
                SqlDataReader records = cmd.ExecuteReader();

                while (records.Read())
                {
                    Job job = new Job();
                    job.Job_id = records.GetInt32(records.GetOrdinal("job_id"));
                    job.Job_title = records.GetString(records.GetOrdinal("job_title"));
                    job.Min_salary = records.IsDBNull(records.GetOrdinal("min_salary")) ? (decimal?)null : records.GetDecimal(records.GetOrdinal("min_salary"));
                    job.Max_salary = records.IsDBNull(records.GetOrdinal("max_salary")) ? (decimal?)null : records.GetDecimal(records.GetOrdinal("max_salary"));

                    // Agrega más campos según la estructura de tu tabla y tu clase Job
                    jobs.Add(job);
                }
                _connection.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return jobs;
        }
    }
}
