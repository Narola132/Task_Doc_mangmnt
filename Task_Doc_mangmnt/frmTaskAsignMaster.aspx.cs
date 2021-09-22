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
    public partial class frmTaskAsignMaster : System.Web.UI.Page
    {
        clsCompany objB = new clsCompany();
        clsTask objT = new clsTask();
        clsCustom objC = new clsCustom();
        clsRegistration objR = new clsRegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TaskasignID"] = 0;
                BindGrid();
                BindTaskType();
                BindStatusType();
                BindCompanyType();
                BindEmployeeType();
                
            }

        }
        protected void BindTaskType()
        {

            DataTable dt = objT.SelecttaskMaster();
            ddltask.DataSource = dt;
            ddltask.DataTextField = "TaskName";
            ddltask.DataValueField = "Task_Id";
            ddltask.DataBind();
            ddltask.Items.Insert(0, new ListItem("Select Task", "0"));
            ddltask.SelectedIndex = 0;

        }
        protected void BindStatusType()
        {

            DataTable dt = objC.SelectstatusMaster();
            ddlstatus.DataSource = dt;
            ddlstatus.DataTextField = "StatusName";
            ddlstatus.DataValueField = "Status_Id";
            ddlstatus.DataBind();
            ddlstatus.Items.Insert(0, new ListItem("Select Status", "0"));
            ddlstatus.SelectedIndex = 0;

        }
        protected void BindCompanyType()
        {

            DataTable dt = objB.SelectCompanymaster();
            ddlcmp.DataSource = dt;
            ddlcmp.DataTextField = "ComponyName";
            ddlcmp.DataValueField = "Compony_Id";
            ddlcmp.DataBind();
            ddlcmp.Items.Insert(0, new ListItem("Select Company", "0"));
            ddlcmp.SelectedIndex = 0;

        }
        protected void BindEmployeeType()
        {

            DataTable dt = objR.SelectRegistration();
            ddluser.DataSource = dt;
            ddluser.DataTextField = "Name";
            ddluser.DataValueField = "ID";
            ddluser.DataBind();
            ddluser.Items.Insert(0, new ListItem("Select Username", "0"));
            ddluser.SelectedIndex = 0;

        }

        protected void BindGrid()
        {
            DataTable dt = objT.SelecttaskasignMaster();
            griddetails.DataSource = dt;
            griddetails.DataBind();

        }


        protected void adddetails_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["TaskasignID"] = 0;

            ddltask.SelectedValue = "0";
            ddlstatus.SelectedValue = "0";
            ddlcmp.SelectedValue = "0";
            ddluser.SelectedValue = "0";
            txtstartdate.Text = "";
            txtenddate.Text = "";

            
        }

        protected void griddetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["TaskasignID"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord();
            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["TaskasignID"] = e.CommandArgument;
                objT.Deletetaskasignmaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }

        }
        protected void EditRecord()
        {
            DataTable dt = objT.SelecttaskasignID(Convert.ToInt32(ViewState["TaskasignID"]));

            if (dt.Rows.Count > 0)
            {

                ddltask.SelectedValue = Convert.ToString(dt.Rows[0]["Task_Id"]);
                ddlstatus.SelectedValue = Convert.ToString(dt.Rows[0]["Status_Id"]);
                ddlcmp.SelectedValue = Convert.ToString(dt.Rows[0]["Compony_Id"]);
                ddluser.SelectedValue = Convert.ToString(dt.Rows[0]["Employee_Id"]);
                
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (Convert.ToInt32(ViewState["TaskasignID"]) > 0)
            {
                objT.UpdatetaskAsignmaster(Convert.ToInt32(ViewState["TaskasignID"]), Convert.ToInt32(ddltask.SelectedValue), Convert.ToInt32(ddlstatus.SelectedValue), Convert.ToInt32(ddlcmp.SelectedValue), Convert.ToInt32(ddluser.SelectedValue), Convert.ToDateTime(txtstartdate.Text), Convert.ToDateTime(txtenddate.Text));
            }
            else
            {
                objT.Inserttaskasignmaster(Convert.ToInt32(ddltask.SelectedValue), Convert.ToInt32(ddlstatus.SelectedValue), Convert.ToInt32(ddlcmp.SelectedValue), Convert.ToInt32(ddluser.SelectedValue), Convert.ToDateTime(txtstartdate.Text), Convert.ToDateTime(txtenddate.Text));
            }
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ddltask.SelectedIndex = 0;
            ddlstatus.SelectedIndex = 0;
            ddlcmp.SelectedIndex = 0;
            ddluser.SelectedIndex = 0;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
        }

        protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            griddetails.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}