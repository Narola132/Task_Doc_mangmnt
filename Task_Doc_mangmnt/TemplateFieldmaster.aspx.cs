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
    public partial class TemplateFieldmaster : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TempfieldID"] = 0;
                BindGrid();
                BindTempType();
                
            }
        }
        protected void BindTempType()
        {

            DataTable dt = objC.SelectDesignTemplateMaster();
            ddltemp.DataSource = dt;
            ddltemp.DataTextField = "TemplateName";
            ddltemp.DataValueField = "Template_Id";
            ddltemp.DataBind();
            ddltemp.Items.Insert(0, new ListItem("Select Template", "0"));
            ddltemp.SelectedIndex = 0;

            ddltempdownload.DataSource = dt;
            ddltempdownload.DataTextField = "TemplateName";
            ddltempdownload.DataValueField = "Template_Id";
            ddltempdownload.DataBind();
            ddltempdownload.Items.Insert(0, new ListItem("Select Template", "0"));
            ddltempdownload.SelectedIndex = 0;

        }
        protected void BindGrid()
        {
            DataTable dt = objC.SelecttempfieldMaster();
            gridtempfield.DataSource = dt;
            gridtempfield.DataBind();

        }

        protected void addtemp_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["TempfieldID"] = 0;
            ViewState["Template_Id"] = 0;
            ddltemp.SelectedValue = "0";
            txttempfieldname.Text = "";
        }

        protected void gridtempfield_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["Template_Id"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord(Convert.ToInt32(e.CommandArgument));
            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["TempfieldID"] = e.CommandArgument;
                objC.Deletetempfieldmaster(Convert.ToInt32(e.CommandArgument));
                BindGrid();
            }

        }
        protected void EditRecord(int tempid)
        {
            DataTable dt = objC.SelecttempfieldID(tempid);

            if (dt.Rows.Count > 0)
            {

                ddltemp.SelectedValue = Convert.ToString(dt.Rows[0]["Template_Id"]);
                foreach (DataRow dr in dt.Rows)
                {
                    txttempfieldname.Text += dr["FieldName"]+",";
                }
                if (txttempfieldname.Text.Length > 0)
                    txttempfieldname.Text = txttempfieldname.Text.Remove(txttempfieldname.Text.Length - 1, 1);
               

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            if (Convert.ToInt32(ViewState["Template_Id"]) > 0)
            {
                new DBConnection().ExecuteNonQuery("delete from TemplateField_Master where Template_Id="+ViewState["Template_Id"]);
                string[] str = txttempfieldname.Text.Trim().Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Trim() != "")
                        objC.Inserttempfieldmaster(Convert.ToInt32(ddltemp.SelectedValue), str[i].Trim(), Convert.ToInt32(Session["UserID"].ToString()));
                }    
            }
            else
            {
                string[] str = txttempfieldname.Text.Trim().Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    if(str[i].Trim()!="")
                        objC.Inserttempfieldmaster(Convert.ToInt32(ddltemp.SelectedValue), str[i].Trim(), Convert.ToInt32(Session["UserID"].ToString()));
                }
            }
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {

            ddltemp.SelectedIndex = 0;
            txttempfieldname.Text = "";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }

        protected void btndownload_Click(object sender, EventArgs e)
        {
            DataTable dt = objC.SelecttempfieldID(Convert.ToInt32(ddltempdownload.SelectedValue));
            string str = "";
            if (dt.Rows.Count > 0)
            {

                ddltemp.SelectedValue = Convert.ToString(dt.Rows[0]["Template_Id"]);
                foreach (DataRow dr in dt.Rows)
                {
                   str += dr["FieldName"] + ",";
                }
                if (str.Length > 0)
                    str = str.Remove(str.Length - 1, 1);

                string name = DateTime.Now.ToString("ddMMyyyyhhmmss");
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename="+name+".csv");
                Response.Charset = "";
                Response.ContentType = "application/csv";
                Response.Output.Write(str);
                Response.Flush();
                Response.End();
            }
        }

        protected void gridtempfield_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridtempfield.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}