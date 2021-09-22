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
    public partial class frmCmpRegistration : System.Web.UI.Page
    {
        clsCompany objC = new clsCompany();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["CompID"] = 0;
                
                BindGrid();
            }
        }

       
        protected void BindGrid()
        {
            DataTable dt = objC.SelectCompanymaster();
            gridcomp.DataSource = dt;
            gridcomp.DataBind();

        }
        
        protected void addcompany_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["CompID"] = 0;

            txtcmpname.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtusername.Text = "";
            txtuserphone.Text = "";
            txtuseremail.Text = "";
            ltrdoc.Text = "";
        }

        protected void gridcomp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["CompID"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                ltrdoc.Text = "";
                EditRecord();
             
            }
            else if (e.CommandName=="DeleteMode")
            {
                ViewState["CompID"]= e.CommandArgument;
                objC.DeleteCompanymaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }
        }


        protected void EditRecord()
        {
            DataTable dt = objC.SelectCompanyRegistrationID(Convert.ToInt32(ViewState["CompID"]));

            if (dt.Rows.Count > 0)
            {
                txtcmpname.Text = Convert.ToString(dt.Rows[0]["ComponyName"]);
                txtaddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                txtphone.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                txtemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                txtusername.Text = Convert.ToString(dt.Rows[0]["ContactPersonName"]);
                txtuserphone.Text = Convert.ToString(dt.Rows[0]["ContactPhone"]);
                txtuseremail.Text = Convert.ToString(dt.Rows[0]["ContactEmail"]);

                DataTable dtdoc = new DBConnection().GetDataTable("select * from ComponyDocument_Master where Compony_Id=" + ViewState["CompID"]);
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
            if (Convert.ToInt32(ViewState["CompID"]) > 0)
            {
                objC.Updatecompanymaster(Convert.ToInt32(ViewState["CompID"]), txtcmpname.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), txtemail.Text.Trim(), txtusername.Text.Trim(), txtuserphone.Text.Trim(), txtuseremail.Text.Trim());
                if (fldupload.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fldupload.PostedFiles)
                    {
                        string fnname = Convert.ToInt32(ViewState["CompID"]) + "_" + uploadedFile.FileName;
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/CompanyDocument/"),
                        fnname));
                        ltrdoc.Text += "<a href='CompanyDocument/" + fnname + "' target='_blank'>" + uploadedFile.FileName + "</a><br />";
                        objC.Insertcompanydocument(Convert.ToInt32(ViewState["CompID"]), uploadedFile.FileName, fnname, Convert.ToInt32(Session["UserID"]));
                    }
                }
            }
            else
            {
                DataTable dt=objC.Insertcompanymaster(txtcmpname.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), txtemail.Text.Trim(), txtusername.Text.Trim(), txtuserphone.Text.Trim(), txtuseremail.Text.Trim());
                if (fldupload.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fldupload.PostedFiles)
                    {
                        string fnname = Convert.ToInt32( dt.Rows[0]["Compony_Id"].ToString())+"_"+uploadedFile.FileName;
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/CompanyDocument/"),
                        fnname));

                        ltrdoc.Text += "<a href='CompanyDocument/" + fnname + "' target='_blank'>" + uploadedFile.FileName + "</a><br />";
                        objC.Insertcompanydocument(Convert.ToInt32(dt.Rows[0]["Compony_Id"].ToString()), uploadedFile.FileName, fnname, Convert.ToInt32(Session["UserID"]));
                    }
                }
            }
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }
        
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            txtcmpname.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtusername.Text = "";
            txtuserphone.Text = "";
            txtuseremail.Text = "";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;
        }

        protected void gridcomp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridcomp.PageIndex = e.NewPageIndex;
            BindGrid();
        }


    }
}