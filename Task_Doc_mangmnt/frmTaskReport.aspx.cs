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
    public partial class frmTaskReport : System.Web.UI.Page
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




        protected void adddetails_Click(object sender, EventArgs e)
        {
            //  pnlhdn.Visible = true;
            //pnlshw.Visible = false;

            ViewState["TaskasignID"] = 0;

            ddltask.SelectedValue = "0";
            ddlstatus.SelectedValue = "0";
            ddlcmp.SelectedValue = "0";
            ddluser.SelectedValue = "0";


        }
        protected void BindGrid()
        {


        }

        protected void btnsrch_Click(object sender, EventArgs e)
        {


            if ((txtstartdate.Text) == "" || (txtenddate.Text) == "")
            {

                DataTable dt = objT.Selecttaskreport(Convert.ToInt32(ddlstatus.SelectedValue), Convert.ToInt32(ddlcmp.SelectedValue), Convert.ToInt32(ddluser.SelectedValue), Convert.ToString(txtstartdate.Text), Convert.ToString(txtenddate.Text), Convert.ToInt32(ddltask.SelectedValue));
                griddetails.DataSource = dt;
                griddetails.DataBind();

                btndownload.Visible = true;
                lblmsg.Text = "";
                griddetails.Visible = true;
            }
            else

                if (Convert.ToDateTime(txtstartdate.Text) >= Convert.ToDateTime(txtenddate.Text))
                {
                    lblmsg.Text = "Enter valid End Date";
                }
                else
                {

                    if (txtstartdate.Text.Trim() != "")
                    {
                        DataTable dt = objT.Selecttaskreport(Convert.ToInt32(ddlstatus.SelectedValue), Convert.ToInt32(ddlcmp.SelectedValue), Convert.ToInt32(ddluser.SelectedValue), Convert.ToString(txtstartdate.Text), Convert.ToString(txtenddate.Text), Convert.ToInt32(ddltask.SelectedValue));
                        griddetails.DataSource = dt;
                        griddetails.DataBind();

                        btndownload.Visible = true;
                        lblmsg.Text = "";
                        griddetails.Visible = true;

                    }
                    else
                    {
                        lblmsg.Text = "Please Enter a Valid start Date !!!";
                    }
                }
        }


        protected void btnclear_Click(object sender, EventArgs e)
        {
            ddlstatus.SelectedIndex= 0;
            ddlcmp.SelectedIndex = 0;
            ddltask.SelectedIndex =0;
            ddluser.SelectedIndex = 0;
            txtstartdate.Text = "";
            txtenddate.Text = "";

            DataTable dt = objT.Selecttaskreport(Convert.ToInt32(ddlstatus.SelectedValue), Convert.ToInt32(ddlcmp.SelectedValue), Convert.ToInt32(ddluser.SelectedValue), Convert.ToString(txtstartdate.Text), Convert.ToString(txtenddate.Text), Convert.ToInt32(ddltask.SelectedValue));
            griddetails.DataSource = dt;
            griddetails.DataBind();

            btndownload.Visible = true;
            lblmsg.Text = "";
            griddetails.Visible = true;
        }

        protected void btndownload_Click(object sender, EventArgs e)
        {
            DataTable dt = objT.Selecttaskreport(Convert.ToInt32(ddlstatus.SelectedValue), Convert.ToInt32(ddlcmp.SelectedValue), Convert.ToInt32(ddluser.SelectedValue), Convert.ToString(txtstartdate.Text), Convert.ToString(txtenddate.Text), Convert.ToInt32(ddltask.SelectedValue));
            string str = "";
            if (dt.Rows.Count > 0)
            {



                foreach (DataRow dr in dt.Rows)
                {
                    str += dr["Name"] + ",";

                    str += dr["ComponyName"] + "," + "," + ",";
                    str += dr["TaskName"] + "," + ",";

                    str += dr["StatusName"] + "," + "," + ",";


                    str += dr["StartDate"] + "," + "," + ",";

                    str += dr["EndDate"] + "," + "\n";
                }

                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1, 1);
                }
                string name = DateTime.Now.ToString("ddMMyyyyhhmmss");
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-disposition", "attachment;filename=" + name + ".csv");
                Response.Charset = "";
                Response.ContentType = "application/csv";
                Response.Output.Write(str);
                Response.Flush();
                Response.End();
            }

        }



    }
}
