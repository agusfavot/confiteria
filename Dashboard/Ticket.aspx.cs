using System;
using BusinessLayer;
using EntityLayer;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.SS.Formula.Functions;

namespace Dashboard.Pages
{
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Employee> loadEmployee()
        {
            var list = new List<Employee>();
            try
            {
                list = EmployeeBL.getInstance().searchAllEmployee();
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        [WebMethod]
        public static List<Item> loadItem()
        {
            var list = new List<Item>();
            try
            {
                list = ItemBL.getInstance().searAllArticles();
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        [WebMethod]
        public static bool insertTicket(object json)
        {
            int value = 0;
            string num = null;
            List<object> list = new List<object>();
            bool flag = true;
            try
            {
                var ticket = new EntityLayer.Ticket();
                ticket.Date = DateTime.Now;
                ticket.State = true;
                foreach (var item in json.ToString())
                {
                    if (item != '[' && item != ',' && item != ']')
                    {
                        num += item;
                    }
                    else
                    {
                        if (item == ',' || item == ']')
                        {
                            if (flag)
                            {
                                ticket.IdEmployee = int.Parse(num);
                                num = null;
                                flag = false;
                            }
                            else
                            {
                                var x = int.Parse(num);
                                list.Add(x);
                                num = null;
                            }

                        }
                    }
                }
                int n = TicketBL.getInstance().searchNextNumberTicket();
                n = n == 0 ? n : n + 1;
                value = TicketBL.getInstance().insertTicket(ticket, n,list);
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

    }
}