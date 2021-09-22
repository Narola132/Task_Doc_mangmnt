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
    public partial class FrmAdminDashboard : System.Web.UI.Page
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
            DataTable dt = objR.SelectAdmindashboard();
            gridadmveiw.DataSource = dt;
            gridadmveiw.DataBind();
        }

        protected void gridadmveiw_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                DataTable dtdes = new DBConnection().GetDataTable("select * from TaskAssign_Master where TaskAssign_Id=" + e.CommandArgument);
                Response.Redirect("frmAdminRemarks.aspx?TaskID=" + dtdes.Rows[0]["Task_Id"] + "&TaskAsignID=" + e.CommandArgument);
            }

        }

        protected void gridadmveiw_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridadmveiw.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}