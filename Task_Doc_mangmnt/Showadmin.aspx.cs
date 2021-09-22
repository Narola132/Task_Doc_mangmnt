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
    public partial class Showadmin : System.Web.UI.Page
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
            DataTable dt = objR.SelectadminRegistration();
            gridadmin.DataSource = dt;
            gridadmin.DataBind();

        }

        protected void gridadmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridadmin.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridadmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}