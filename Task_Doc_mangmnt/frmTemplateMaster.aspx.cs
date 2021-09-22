using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task_Doc_mangmnt.BuisnessClass;

namespace Task_Doc_mangmnt
{
    public partial class frmTemplateMaster : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TempID"] = 0;

                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataTable dt = objC.SelectDesignTemplateMaster();
            gridtemp.DataSource = dt;
            gridtemp.DataBind();

        }

        protected void addstemp_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["TempID"] = 0;
            txttmpname.Text = "";
           
            
        }

        protected void gridstemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["TempID"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord();

            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["TempID"] = e.CommandArgument;
                objC.DeleteDesigntemplatemaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }
        }

        protected void EditRecord()
        {
            DataTable dt = objC.SelectDesigntemplatebyID(Convert.ToInt32(ViewState["TempID"]));

            if (dt.Rows.Count > 0)
            {
                txttmpname.Text = Convert.ToString(dt.Rows[0]["TemplateName"]);
               
            }

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (Convert.ToInt32(ViewState["TempID"]) > 0)
            {
                objC.UpdateDesigntemplatemaster(Convert.ToInt32(ViewState["TempID"]), txttmpname.Text.Trim(), Convert.ToInt32(Session["UserID"].ToString()));
            }
            else
            {
                objC.InsertDesigntemplatemaster(txttmpname.Text.Trim(), Convert.ToInt32(Session["UserID"].ToString()));
            }
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
        }

        protected void gridtemp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridtemp.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}