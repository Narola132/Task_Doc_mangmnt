using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

using Task_Doc_mangmnt.BuisnessClass;


namespace Task_Doc_mangmnt
{
    public partial class Showusers : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        clsRegistration objR = new clsRegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["RegID"] = 0;
            BindGrid();
        }
        protected void BindGrid()
        {
            DataTable dt = objR.SelectRegistration();
            griduser.DataSource = dt;
            griduser.DataBind();

        }
        protected void griduser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void griduser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            griduser.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}