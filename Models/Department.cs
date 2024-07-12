namespace DataBaseWinforms.Entities
{
    public class Department
    {
        private int department_id;
        private string department_name;
        private int location_id;

        public int Department_id { get => department_id; set => department_id = value; }
        public string Department_name { get => department_name; set => department_name = value; }
        public int Location_id { get => location_id; set => location_id = value; }

        public Department(int department_id, string department_name, int location_id)
        {
            this.department_id = department_id;
            this.department_name = department_name;
            this.location_id = location_id;
        }

        public Department()
        {
        }
    }
}
