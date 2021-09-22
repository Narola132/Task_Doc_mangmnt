using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Task_Doc_mangmnt.BuisnessClass;
namespace Task_Doc_mangmnt
{
    public partial class frmStatusMaster_aspx : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Statusid"] = 0;
                BindGrid();

            }
        }
        protected void BindGrid()
        {
            DataTable dt = objC.SelectstatusMaster();
            gridstatus.DataSource = dt;
            gridstatus.DataBind();

        }
        protected void gridrole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["Statusid"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord();
            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["Statusid"] = e.CommandArgument;
                objC.Deletestatusmaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }
        }
        protected void addstatus_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["Statusid"] = 0;
            txtstsname.Text = "";
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (Convert.ToInt32(ViewState["Statusid"]) > 0)
            {
                objC.Updatestatusmaster(Convert.ToInt32(ViewState["Statusid"]), txtstsname.Text.Trim());

            }
            else
            {
                objC.Insertstatusmaster(txtstsname.Text.Trim());
            }
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
         }
        protected void EditRecord()
        {
            DataTable dt = objC.SelectstatusID(Convert.ToInt32(ViewState["Statusid"]));

            if (dt.Rows.Count > 0)
            {
                txtstsname.Text = Convert.ToString(dt.Rows[0]["StatusName"]);


            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
        }

        protected void gridstatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridstatus.PageIndex = e.NewPageIndex;
            BindGrid();
        }

       
        
    }
}