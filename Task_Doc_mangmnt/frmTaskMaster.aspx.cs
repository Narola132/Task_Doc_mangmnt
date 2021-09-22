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
    public partial class frmTaskMaster_aspx : System.Web.UI.Page
    {
        clsCompany objC = new clsCompany();
        clsTask objT = new clsTask();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TaskID"] = 0;

                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataTable dt = objT.SelecttaskMaster();
            gridtask.DataSource = dt;
            gridtask.DataBind();

        }
        protected void addtask_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["TaskID"] = 0;
            txttskname.Text = "";
            txtDescription.Text = "";
            txtstartdate.Text = "";
            txtenddate.Text = "";
            ltrdoc.Text = "";
            
        }

        protected void gridtask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["TaskID"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord();

            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["TaskID"] = e.CommandArgument;
                objT.Deletetaskmaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }
        }
        protected void EditRecord()
        {
            DataTable dt = objT.SelecttaskID(Convert.ToInt32(ViewState["TaskID"]));

            if (dt.Rows.Count > 0)
            {
                txttskname.Text = Convert.ToString(dt.Rows[0]["TaskName"]);
                txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                txtstartdate.Text = Convert.ToDateTime(dt.Rows[0]["StartDate"]).ToString("yyyy-MM-dd");
                txtenddate.Text = Convert.ToDateTime(dt.Rows[0]["EndDate"]).ToString("yyyy-MM-dd");

                DataTable dtdoc = new DBConnection().GetDataTable("select * from ComponyDocument_Master where Compony_Id=" + ViewState["TaskID"]);
                foreach (DataRow dr in dtdoc.Rows)
                {
                    ltrdoc.Text += "<a href='CompanyDocument/" + dr["FilePath"].ToString() + "' target='_blank'>" + dr["DocumentName"].ToString() + "</a><br />";
                }
            }

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (Convert.ToDateTime(txtstartdate.Text) <= Convert.ToDateTime(txtenddate.Text))
            {

                if (Convert.ToInt32(ViewState["TaskID"]) > 0)
                {
                    objT.Updatetaskmaster(Convert.ToInt32(ViewState["TaskID"]), txttskname.Text.Trim(), txtDescription.Text.Trim(), Convert.ToDateTime(txtstartdate.Text), Convert.ToDateTime(txtenddate.Text), Convert.ToInt32(Session["UserID"].ToString()));
                    if (fldupload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in fldupload.PostedFiles)
                        {
                            string fnname = Convert.ToInt32(ViewState["TaskID"]) + "_" + uploadedFile.FileName;
                            uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/TaskDocument/"),
                            fnname));
                            ltrdoc.Text += "<a href='TaskDocument/" + fnname + "' target='_blank'>" + uploadedFile.FileName + "</a><br />";

                            objT.InsertTaskdocument(Convert.ToInt32(ViewState["TaskID"]), fnname);
                        }
                    }
                }


                else
                {
                    DataTable dt = objT.Inserttaskmaster(txttskname.Text.Trim(), txtDescription.Text.Trim(), Convert.ToDateTime(txtstartdate.Text), Convert.ToDateTime(txtenddate.Text), Convert.ToInt32(Session["UserID"].ToString()));
                    if (fldupload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in fldupload.PostedFiles)
                        {
                            string fnname = Convert.ToInt32(dt.Rows[0]["Task_Id"].ToString()) + "_" + uploadedFile.FileName;
                            uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/TaskDocument/"), fnname));

                            ltrdoc.Text += "<a href='TaskDocument/" + fnname + "' target='_blank'>" + uploadedFile.FileName + "</a><br />";
                            objT.InsertTaskdocument(Convert.ToInt32(dt.Rows[0]["Task_Id"].ToString()), fnname);
                        }
                    }
                }
                BindGrid();

                pnlhdn.Visible = false;
                pnlshw.Visible = true;
            }
            else 
            {
                lblenddt.Text = "Invalid Enddate *";
                pnlhdn.Visible = true;
                pnlshw.Visible = false;

            }
          

        }

        
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
        }

        protected void gridtask_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridtask.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}