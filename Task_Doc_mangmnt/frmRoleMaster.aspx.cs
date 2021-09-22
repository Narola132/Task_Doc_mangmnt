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
    public partial class frmRollMaster : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Roleid"] = 0;
                BindGrid();

            }

        }

       
        protected void BindGrid()
        {
            DataTable dt = objC.GetselectRoleMaster();
            gridrole.DataSource = dt;
            gridrole.DataBind();

        }

        protected void gridrole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["Roleid"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord();
            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["Roleid"] = e.CommandArgument;
                objC.DeleteRolemaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }

        }
        protected void addrole_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["Roleid"] = 0;

            txtrolename.Text = "";
            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (Convert.ToInt32(ViewState["Roleid"]) > 0)
            {
                objC.UpdateRolemaster(Convert.ToInt32(ViewState["Roleid"]), txtrolename.Text.Trim());
              
            }
            else 
            {
                objC.InsertRolemaster(txtrolename.Text.Trim());
            }
            BindGrid();
          
            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }
        protected void EditRecord()
        {
            DataTable dt = objC.SelectRoleID(Convert.ToInt32(ViewState["Roleid"]));

            if (dt.Rows.Count > 0)
            {
                txtrolename.Text = Convert.ToString(dt.Rows[0]["RoleName"]);
                

            }
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }

        protected void gridrole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridrole.PageIndex = e.NewPageIndex;
            BindGrid();
        }

    }
}