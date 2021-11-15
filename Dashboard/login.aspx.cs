using BusinessLayer;
using System;


namespace Dashboard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void logIn(object sender, EventArgs e)
        {
            try
            {
                if (!UserBL.getInstance().isValidUser(name.Text.Trim(), pass.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "<script> swal('Usuario Incorrecto!', 'You clicked the button!', 'warning') </script>");
                    return;
                }
                Response.Redirect("Ticket.aspx");

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "<script> swal('¡Ups! Ha ocurrido un error inesperado', 'Vuelva a intentarlo mas tarde!', 'warning') </script>");
            }
        }
    }
}