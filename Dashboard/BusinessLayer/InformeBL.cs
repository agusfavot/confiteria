using System;
using DataAccessLayer;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InformeBL
    {
        private static InformeBL informeBL = null;
        private InformeBL() { }

        public static InformeBL getInstance() {
            return informeBL == null ? new InformeBL() : informeBL;
        }

        public DataTable reportCantItem()
        {
            return AccessReportData.getInstance().reportCantItem();
        }

        public DataTable reportVentasXMozo()
        {
            return AccessReportData.getInstance().reportVentasXMozo();
        }

    }
}
