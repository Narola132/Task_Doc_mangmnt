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
    public partial class frmRegistration : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        clsRegistration objR = new clsRegistration();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RegID"] = 0;
                BindRoleType();
                BindGrid();
            }

        }

        protected void BindRoleType()
        {

            DataTable dt = objC.GetselectRoleMaster();
            ddlrole.DataSource = dt;
            ddlrole.DataTextField = "RoleName";
            ddlrole.DataValueField = "Role_Id";
            ddlrole.DataBind();
            ddlrole.Items.Insert(0, new ListItem("Select Role", "0"));
            ddlrole.SelectedIndex = 0;

        }




        protected void BindGrid()
        {
            DataTable dt = objR.SelectRegistration();
            gridreg.DataSource = dt;
            gridreg.DataBind();

        }

        protected void adduser_Click(object sender, EventArgs e)
        {
            pnlhdn.Visible = true;
            pnlshw.Visible = false;

            ViewState["RegID"] = 0;

            txtname.Text = "";
            txtpassword.Text = "";
            txtphone.Text = "";
            txtusername.Text = "";
            ddlrole.SelectedValue = "0";

            txtaddress.Text = "";
        }

        protected void gridreg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMode")
            {
                ViewState["RegID"] = e.CommandArgument;
                pnlhdn.Visible = true;
                pnlshw.Visible = false;
                EditRecord();
            }
            else if (e.CommandName == "DeleteMode")
            {
                ViewState["RegID"] = e.CommandArgument;
                GridViewRow gr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int i = Convert.ToInt32(gridreg.DataKeys[gr.RowIndex].Values[0]);
                if (i != 1)
                {
                    objR.DeleteRegistration(Convert.ToInt32(e.CommandArgument));
                    BindGrid();
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('User successfully deleted!!!');", true);
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Admin user can not be delete!!!');", true);
            }

        }

        protected void EditRecord()
        {
            DataTable dt = objR.SelectRegistrationID(Convert.ToInt32(ViewState["RegID"]));

            if (dt.Rows.Count > 0)
            {
                txtname.Text = Convert.ToString(dt.Rows[0]["Name"]);
                txtaddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                txtphone.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                txtusername.Text = Convert.ToString(dt.Rows[0]["Username"]);
                //txtpassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
                txtpassword.Attributes.Add("value", "Password");
                ddlrole.SelectedValue = Convert.ToString(dt.Rows[0]["Role_Id"]);
                userImage.Src = Convert.ToString(dt.Rows[0]["FileUpload"]);
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            DataTable dt = objC.CheckExitUser(Convert.ToString(txtusername.Text.Trim()));
            //if (dt.Rows.Count == 0)
            //{

            string filename = string.Empty;
            if (file.HasFile)
            {
                filename = "FileUpload/" + txtname.Text + '_' + "." + file.FileName.Split('.').Last();
                file.SaveAs(Server.MapPath(filename));
            }
            else
            {
                filename = userImage.Src;
            }
            if (Convert.ToInt32(ViewState["RegID"]) > 0)
            {
                objR.UpdateRegistration(Convert.ToInt32(ViewState["RegID"]), txtname.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), txtusername.Text.Trim(), txtpassword.Text.Trim(), Convert.ToInt32(ddlrole.SelectedValue), filename);
                Session["User_Image"] = filename;
                BindGrid();

                pnlhdn.Visible = false;
                pnlshw.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('User successfully updated!!!');", true);
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    objR.InsertRegistration(txtname.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), txtusername.Text.Trim(), txtpassword.Text.Trim(), Convert.ToInt32(ddlrole.SelectedValue), filename);
                    BindGrid();

                    pnlhdn.Visible = false;
                    pnlshw.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('User successfully created!!!');", true);
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('User already exist!!!');", true);
            }


            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('User already exist!!!');", true);
            //}
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {


            txtname.Text = "";
            txtpassword.Text = "";
            txtphone.Text = "";
            txtusername.Text = "";
            ddlrole.SelectedValue = "0";

            txtaddress.Text = "";


        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            BindGrid();

            pnlhdn.Visible = false;
            pnlshw.Visible = true;

        }

       
        protected void gridreg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridreg.PageIndex = e.NewPageIndex;
            BindGrid();
        }


    }
}