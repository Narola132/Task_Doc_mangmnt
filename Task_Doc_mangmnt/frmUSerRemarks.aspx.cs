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
    public partial class frmRemarks : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        clsTask objT = new clsTask();
        clsRemarks objR = new clsRemarks();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 2)
                {

                    ViewState["TaskID"] = Request.QueryString["TaskID"];
                    ViewState["TaskAsignID"] = Request.QueryString["TaskAsignID"];
                }
                else
                {
                    ViewState["TaskRemarksID"] = 0;
                    ViewState["TaskID"] = 0;
                    ViewState["TaskAsignID"] = 0;
                }
                BindStatusType();
                UpdateTaskNotifacation();
                ViewRecord();
            }
        }
        protected void BindStatusType()
        {

            DataTable dt = objC.SelectstatusMaster();
            ddlsts.DataSource = dt;
            ddlsts.DataTextField = "StatusName";
            ddlsts.DataValueField = "Status_Id";
            ddlsts.DataBind();
            ddlsts.Items.Insert(0, new ListItem("Select Status", "0"));
            ddlsts.SelectedIndex = 0;

        }
        protected void UpdateTaskNotifacation()
        {
            objT.Updatetasknotification(Convert.ToInt32(ViewState["TaskAsignID"]));
        }
        protected void ViewRecord()
        {
            //DataTable dt = objR.SelecttaskRemarksID(Convert.ToInt32(ViewState["TaskRemarksID"]));

            //if (dt.Rows.Count > 0)
            //{
            // txtrks.Text = Convert.ToString(dt.Rows[0]["Remarks"]);

            DataTable dtdes = new DBConnection().GetDataTable("select * from Task_Master where Task_Id=" + ViewState["TaskID"]);
            if (dtdes.Rows.Count > 0)
            foreach (DataRow dr in dtdes.Rows)
            {
                ltrdes.Text = dr["Description"].ToString();
                lblsttdt.Text = Convert.ToDateTime(dr["StartDate"]).ToString("dd-MM-yyyy");
                lblenddt.Text = Convert.ToDateTime(dr["endDate"]).ToString("dd-MM-yyyy");
            }
            

            DataTable dtsts = new DBConnection().GetDataTable("select * from TaskAssign_Master where TaskAssign_Id=" + ViewState["TaskAsignID"]);
            if (dtsts.Rows.Count > 0)
                ddlsts.SelectedValue = dtsts.Rows[0]["Status_Id"].ToString();
           
            DataTable dtdoc = new DBConnection().GetDataTable("select * from TaskDocumentMaster where TaskId=" + ViewState["TaskID"]);
            if (dtdoc.Rows.Count > 0)
            {
                foreach (DataRow dr in dtdoc.Rows)
                {
                    ltrdoc.Text += "<a href='TaskDocument/" + dr["DocumentPath"].ToString() + "' target='_blank'>" + dr["DocumentPath"].ToString() + "</a><br />";
                }
            }
            else
            {
                ltrdoc.Text = "No document(s) found!!!";
            }

            DataTable dtremarks = new DBConnection().GetDataTable("select * from TaskRemarks_Master where TaskAssign_Id=" + ViewState["TaskAsignID"]);
            int i = 1;
            string str = "";
            foreach (DataRow dr in dtremarks.Rows)
            {
                str += "<table border='0' width='100%' style=\"margin-top:20px\">" +
                        "<tr>" +
                            "<td class=\"col-md-7\" style=\"vertical-align:top;text-align:justify;\">" +
                            "<b>RE:"+i.ToString()+" Remarks :</b> <br />" + dr["Remarks"] +
                            "</td>";
                DataTable dtremarksdoc = new DBConnection().GetDataTable("select * from TaskRemarksDocument_Master where TaskRemarks_Id=" + dr["TaskRemarks_Id"]);
                string strdoc = "";
                foreach (DataRow row in dtremarksdoc.Rows)
                {
                    strdoc += "<a href='TaskRemarksDoc/" + row["DocumentPath"].ToString() + "' target='_blank'>" + row["DocumentPath"].ToString() + "</a><br />";
                }
                str += "<td class=\"col-md-3\" style=\"vertical-align:top\">" +
                            "<b>Remarks Document : </b><br />" + strdoc +
                            "</td>" +
                        "</tr>" +
                    "</table>";
                i++;
            }
            ltrremarks.Text = str;
            //}

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            //if (Convert.ToInt32(ViewState["TaskRemarksID"]) > 0)
            //{
            //    objR.UpdateTaskRemarkmaster(Convert.ToInt32(ViewState["TaskRemarksID"]), txtcmpname.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), txtemail.Text.Trim(), txtusername.Text.Trim(), txtuserphone.Text.Trim(), txtuseremail.Text.Trim());
            //    if (fldupload.HasFiles)
            //    {
            //        foreach (HttpPostedFile uploadedFile in fldupload.PostedFiles)
            //        {
            //            string fnname = Convert.ToInt32(ViewState["TaskRemarksID"]) + "_" + uploadedFile.FileName;
            //            uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/TaskDocument/"),
            //            fnname));
            //            ltrdoc.Text += "<a href='TaskDocument/" + fnname + "' target='_blank'>" + uploadedFile.FileName + "</a><br />";
            //            objR.InsertTaskRemarksdocument(Convert.ToInt32(ViewState["TaskRemarksID"]), fnname);
            //        }
            //    }
            //}
            if (!Page.IsValid)
            {
                return;
            }

            DataTable dt = objR.InsertTaskRemarksmaster(Convert.ToInt32(ViewState["TaskAsignID"]), txtrks.Text.Trim(), Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(ddlsts.SelectedValue));
            if (fldupload.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in fldupload.PostedFiles)
                {
                    string fnname = Convert.ToInt32(dt.Rows[0]["TaskRemarks_ID"].ToString()) + "_" + uploadedFile.FileName;
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/TaskRemarksDoc/"), fnname));

                    //ltrdoc.Text += "<a href='TaskDocument/" + fnname + "' target='_blank'>" + uploadedFile.FileName + "</a><br />";
                    objR.InsertTaskRemarksdocument(Convert.ToInt32(dt.Rows[0]["TaskRemarks_Id"].ToString()), fnname);
                }

            }
            ViewRecord();
            txtrks.Text = "";
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmUserDashboard.aspx");

        }


    }
}