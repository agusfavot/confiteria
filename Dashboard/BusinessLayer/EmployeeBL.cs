using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;


namespace BusinessLayer
{
    public class EmployeeBL
    {
        #region
        private static EmployeeBL sectorBL = null;
        private EmployeeBL() { }
        public static EmployeeBL getInstance()
        {
            return sectorBL == null ? new EmployeeBL() : sectorBL;
        }
        #endregion

        public int newMozo(Employee mozo)
        {
            return AccessEmployeeData.getInstance().insertEmployee(new Dictionary<object, object> { { "name", mozo.Name }, { "lastName", mozo.LastName }, { "@commission", mozo.Commission } });
        }

        public int editMozo(Employee mozo)
        {
            return AccessEmployeeData.getInstance().updateEmployee(new Dictionary<object, object> { { "@id", mozo.Id }, { "name", mozo.Name }, { "lastName", mozo.LastName }, { "@commission", mozo.Commission } });
        }

        public int removeMozo(int id)
        {
            return AccessEmployeeData.getInstance().deleteEmployee(new Dictionary<object, object> { { "@id", id } });
        }

        public List<Employee> searchAllEmployee() 
        {
            return AccessEmployeeData.getInstance().searchAllEmployee();
        }
    }
}
