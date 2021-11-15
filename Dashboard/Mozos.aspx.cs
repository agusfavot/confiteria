using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Dashboard.Pages
{
    public partial class Mozo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void dgvMozo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Employee> loadGrid() {

            var list = new List<Employee>();
            try
            {
                list = EmployeeBL.getInstance().searchAllEmployee();
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;       
        }


        [WebMethod]
        public static bool addEmployee(string name, string lastName, string commission) {
            int value = 0;
            try
            {
                var employee = new Employee(name, lastName, float.Parse(commission));
                value = EmployeeBL.getInstance().newMozo(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

        [WebMethod]
        public static bool updateEmployee(string id, string name, string lastName, string commission) {
            int value = 0;
            try
            {
                var employee = new Employee(int.Parse(id), name, lastName, float.Parse(commission));
                value = EmployeeBL.getInstance().editMozo(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

        [WebMethod]
        public static bool deleteEmployee(string id) {
            int value = 0;
            try
            {
                value = EmployeeBL.getInstance().removeMozo(int.Parse(id));
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

    }
}