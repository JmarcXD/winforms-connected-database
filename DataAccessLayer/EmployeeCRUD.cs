using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseWinforms
{
    public class EmployeeCRUD
    {
        private SqlConnection _connection;

        public EmployeeCRUD()
        {
            ConnectionDatabase cd = new ConnectionDatabase();
            _connection = cd.SqlConnection;
        }

        public List<Employee> GetEmployeeListFromDB()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                _connection.Open();


                string query = "SELECT * FROM employees;";
                SqlCommand cmd = new SqlCommand(query, _connection);

                // Recuperamos un lector...
                SqlDataReader records = cmd.ExecuteReader();

                while (records.Read())
                {
                    Employee employee = new Employee();

                    employee.Employee_id = records.GetInt32(records.GetOrdinal("employee_id"));
                    employee.First_name = records.GetString(records.GetOrdinal("first_name"));
                    employee.Last_name = records.GetString(records.GetOrdinal("last_name"));
                    employee.Email = records.GetString(records.GetOrdinal("email"));
                    employee.Phone_number = records.IsDBNull(records.GetOrdinal("phone_number")) ? (string)null : records.GetString(records.GetOrdinal("phone_number"));
                    employee.Salary = records.IsDBNull(records.GetOrdinal("salary")) ? (decimal?)null : records.GetDecimal(records.GetOrdinal("salary"));
                    employee.Manager_id = records.IsDBNull(records.GetOrdinal("manager_id")) ? (int?)null : records.GetInt32(records.GetOrdinal("manager_id"));
                    employee.Department_id = records.IsDBNull(records.GetOrdinal("department_id")) ? (int?)null : records.GetInt32(records.GetOrdinal("department_id"));


                    employees.Add(employee);
                }
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return employees;
        }

        public void InsertEmployeeToDB(Employee newEmployee)
        {
            try
            {
                this._connection.Open();
                string sql = @"INSERT INTO employees(first_name, 
                                             last_name, 
                                             email, 
                                             phone_number,
                                             hire_date,
                                             job_id,
                                             salary,
                                             manager_id,
                                             department_id) 

                                VALUES (@FirstName, 
                                        @LastName, 
                                        @Email, 
                                        @PhoneNumber, 
                                        @HireDate, 
                                        @JobId, 
                                        @Salary, 
                                        @ManagerId, 
                                        @DepartmentId)";


                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", newEmployee.First_name);
                    cmd.Parameters.AddWithValue("@LastName", newEmployee.Last_name);
                    cmd.Parameters.AddWithValue("@Email", newEmployee.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrWhiteSpace(newEmployee.Phone_number) ? (object)DBNull.Value : newEmployee.Phone_number);
                    cmd.Parameters.AddWithValue("@HireDate", newEmployee.Hire_date);
                    cmd.Parameters.AddWithValue("@JobId", newEmployee.Job_id);
                    cmd.Parameters.AddWithValue("@Salary", newEmployee.Salary);
                    cmd.Parameters.AddWithValue("@ManagerId", (object)newEmployee.Manager_id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepartmentId", (object)newEmployee.Department_id ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
