using System;
using System.Data;
using System.Web.Services;
using EntityLayer;
using BusinessLayer;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Dashboard
{
    public partial class Rubros : System.Web.UI.Page
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
        public static List<Sector> loadGrid()
        {

            var list = new List<Sector>();
            try
            {
                list = SectorBL.getInstance().searchAllSector();
            }
            catch (Exception)
            {

            }
            return list;
        }

        [WebMethod]
        public static bool addSector(string name)
        {
            int value = 0;
            try
            {
                var sector = new Sector(name);
                value = SectorBL.getInstance().newSector(sector);
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

        [WebMethod]
        public static bool updateSector(string id, string name)
        {
            int value = 0;
            try
            {
                var sector = new Sector(int.Parse(id), name);
                value = SectorBL.getInstance().editSector(sector);
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

        [WebMethod]
        public static bool deleteSector(string id)
        {
            int value = 0;
            try
            { 
                value = SectorBL.getInstance().removeSector(int.Parse(id));
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }
    }
}