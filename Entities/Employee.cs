namespace DataBaseWinforms
{
    public class Employee
    {
        private int employee_id;
        private string first_name;
        private string last_name;
        private string email;
        private string phone_number;
        private string hire_date;
        private int job_id;
        private decimal salary;
        private int manager_id;
        private int department_id;

        public int Employee_id { get => employee_id; set => employee_id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Hire_date { get => hire_date; set => hire_date = value; }
        public int Job_id { get => job_id; set => job_id = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public int Manager_id { get => manager_id; set => manager_id = value; }
        public int Department_id { get => department_id; set => department_id = value; }

        public Employee(int employee_id, string first_name, string last_name, string email, string phone_number, string hire_date, int job_id, decimal salary, int manager_id, int department_id)
        {
            this.Employee_id = employee_id;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Email = email;
            this.Phone_number = phone_number;
            this.Hire_date = hire_date;
            this.Job_id = job_id;
            this.Salary = salary;
            this.Manager_id = manager_id;
            this.Department_id = department_id;
        }

        public Employee()
        {
        }
    }
}
