using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Dashboard.Pages
{
    public partial class Articulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                loadDropDownList();
            }
        }

        [WebMethod]
        public static List<Item> loadGrid() {

            List<Item> list = new List<Item>();
            try
            {
                list = ItemBL.getInstance().searAllArticles();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        [WebMethod]
        public static bool addArticle(string name, string description, string price, string idSector) {
            
            int value = 0;
            try
            {
                var item = new Item(name, description, float.Parse(price), int.Parse(idSector));
                value = ItemBL.getInstance().newItem(item);

            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;            
        }


        [WebMethod]
        public static bool updateArticle(string id, string name, string description, string price, string idSector)
        {
            
            int value = 0;
            try
            {
                var item = new Item(int.Parse(id), name, description, float.Parse(price), int.Parse(idSector));
                value = ItemBL.getInstance().editItem(item);
            }
            catch (Exception ex)
            {
                
            }
            return value == 0 ? false : true ;
        }


        [WebMethod]
        public static bool deleteArticle(string id) {
            int value = 0;
            try
            {
                value = ItemBL.getInstance().removeItem(int.Parse(id));
            }
            catch (Exception ex)
            {
                throw;
            }
            return value == 0 ? false : true;
        }

        private void loadDropDownList() {
            try
            {
                DropDownListSector.DataSource = SectorBL.getInstance().searchAllSector();
                DropDownListSector.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(),"","");                
            }
        }
    }
}