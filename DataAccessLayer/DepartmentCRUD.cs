using DataBaseWinforms.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseWinforms.DataAccessLayer
{
    public class DepartmentCRUD
    {
        private SqlConnection _connection;

        public DepartmentCRUD()
        {
            ConnectionDatabase cd = new ConnectionDatabase();
            this._connection = cd.SqlConnection;
        }

        public List<Department> GetDepartmentListFromDB()
        {
            _connection.Open();
            List<Department> departments = new List<Department>();

            string query = "SELECT * FROM departments;";
            SqlCommand cmd = new SqlCommand(query, _connection);

            // Recuperamos un lector...
            SqlDataReader records = cmd.ExecuteReader();

            while (records.Read())
            {
                Department department = new Department();

                department.Department_id = records.GetInt32(records.GetOrdinal("department_id"));
                department.Department_name = records.GetString(records.GetOrdinal("department_name"));
                department.Location_id = records.GetInt32(records.GetOrdinal("location_id"));
         

                departments.Add(department);
            }
            _connection.Close();

            return departments;
        }
    }
}
