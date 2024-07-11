using System.Collections.Generic;

namespace DataBaseWinforms.BusinessLayer
{
    public class EmployeeService
    {
        private EmployeeCRUD _employeeCRUD;

        public EmployeeService()
        {
            _employeeCRUD = new EmployeeCRUD();
        }

        public List<Employee> GetEmployeeList()
        {
            return _employeeCRUD.GetEmployeeListFromDB();
        }

        public void InsertEmployee(string first_name, string last_name, string email, string phone_number, string hire_date,int job_id, decimal salary, int manager_id, int department_id)
        {
            Employee newEmployee = new Employee(0,first_name, last_name, email, phone_number, hire_date, job_id, salary,manager_id, department_id);
          
            _employeeCRUD.InsertEmployeeToDB(newEmployee);
        }
    }
}
