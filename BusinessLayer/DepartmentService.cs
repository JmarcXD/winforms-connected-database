using DataBaseWinforms.DataAccessLayer;
using DataBaseWinforms.Entities;
using System.Collections.Generic;

namespace DataBaseWinforms.BusinessLayer
{
    public class DepartmentService
    {
        private DepartmentCRUD _departmentCrud;

        public DepartmentService()
        {
            _departmentCrud = new DepartmentCRUD();
        }

        public List<Department> GetDepartmentList()
        {
            return _departmentCrud.GetDepartmentListFromDB();
        }
    }
}
