using DataBaseWinforms.BusinessLayer;
using DataBaseWinforms.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBaseWinforms
{
    public partial class EmployeeForm : Form
    {
        private EmployeeService _employeeService;
        private DepartmentService _departmentService;
        private JobService _jobService;
        public EmployeeForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            _jobService = new JobService();
            this.Load += new EventHandler(ListJobs_Load);
            this.Load += new EventHandler(ListDepartment_Load);
            this.Load += new EventHandler(ListEmployee_Load);
        }

        private void addNewEmployeeBtn_Click(object sender, EventArgs e)
        {
            ComboBoxItem jobSelected = (ComboBoxItem)this.jobCB.SelectedItem;
            ComboBoxItem managerSelected = (ComboBoxItem)this.managerCB.SelectedItem;
            ComboBoxItem departmentSelected = (ComboBoxItem)this.departmentCB.SelectedItem;


            if (CheckTextBox())
            {
                this._employeeService.InsertEmployee(this.nameEmployeeTB.Text, this.lastNameEmployeeTB.Text,
                                                    this.emailEmployeeTB.Text, this.phoneNumberEmployeeTB.Text,
                                                    this.hireDateEmployeeDP.Text, (int)jobSelected.Value,
                                                    (decimal)this.salaryEmployeeNUD.Value, (int)managerSelected.Value,
                                                    (int)departmentSelected.Value);
                MessageBox.Show("Se ha registrado el nuevo empleado!");
            }
        }

        private bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(this.nameEmployeeTB.Text))
            {
                MessageBox.Show("Introduce el nombre del empleado");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.lastNameEmployeeTB.Text))
            {
                MessageBox.Show("Introduce los apellidos del empleado");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.emailEmployeeTB.Text))
            {
                MessageBox.Show("Introduce el correo del empleado");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.phoneNumberEmployeeTB.Text))
            {
                MessageBox.Show("Introduce el numero de telefono del empleado");
                return false;
            }
            else
                return true;
        }

        private void ListJobs_Load(object sender, EventArgs e)
        {

            List<ComboBoxItem> items = new List<ComboBoxItem>();

            foreach (Job d in _jobService.GetJobsList())
            {
                items.Add(new ComboBoxItem(d.Job_id, $"{d.Job_title}"));
            }

            // Asignar la lista al Combobox
            this.jobCB.DataSource = items;
            this.jobCB.DisplayMember = "Text";
            this.jobCB.ValueMember = "Value";

        }
        private void ListDepartment_Load(object sender, EventArgs e)
        {

            List<ComboBoxItem> items = new List<ComboBoxItem>();

            foreach (Department d in _departmentService.GetDepartmentList())
            {
                items.Add(new ComboBoxItem(d.Department_id, $"{d.Department_name}"));
            }

            // Asignar la lista al Combobox
            this.departmentCB.DataSource = items;
            this.departmentCB.DisplayMember = "Text";
            this.departmentCB.ValueMember = "Value";

        }
        private void ListEmployee_Load(object sender, EventArgs e)
        {

            List<ComboBoxItem> items = new List<ComboBoxItem>();

            foreach (Employee d in _employeeService.GetEmployeeList())
            {
                items.Add(new ComboBoxItem(d.Employee_id, $"{d.First_name}"));
            }

            // Asignar la lista al Combobox
            this.managerCB.DataSource = items;
            this.managerCB.DisplayMember = "Text";
            this.managerCB.ValueMember = "Value";

        }

    }
}
