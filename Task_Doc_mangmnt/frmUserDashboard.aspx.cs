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
    public partial class frmUserDashboard : System.Web.UI.Page
    {
        clsRegistration objR = new clsRegistration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

            }
        }
        protected void BindGrid()
        {
            DataTable dt = objR.SelectUserdashboard(Convert.ToInt32(Session["UserID"]));
            griddetails.DataSource = dt;
            griddetails.DataBind();
        }

        protected void griddetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                DataTable dtdes = new DBConnection().GetDataTable("select * from TaskAssign_Master where TaskAssign_Id=" + e.CommandArgument);
                Response.Redirect("frmUSerRemarks.aspx?TaskID=" + dtdes.Rows[0]["Task_Id"] + "&TaskAsignID=" + e.CommandArgument);
            }


        }

        protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            griddetails.PageIndex = e.NewPageIndex;
            BindGrid();
        }


    }
}
