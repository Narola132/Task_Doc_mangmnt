using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Task_Doc_mangmnt.BuisnessClass;
namespace Task_Doc_mangmnt
{
    public partial class frmforgotpswd : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Trim() != null)
            {
                DataTable dt = objC.checkemail(txtusername.Text);

                if (dt.Rows.Count > 0)
                {
                    string strHtml = "<table><tr><td colspan='2'>Kindly find below your requested password :</td></tr><tr><td>password :</td><td>" + dt.Rows[0]["Password"].ToString() + "</td></tr></table>";
                    DBConnection.SendMail(txtusername.Text.Trim(), "Forgot Password", strHtml);
                    lblmsg.Text = "Email Sending Successfully !!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }

                else
                {
                    lblmsg.Text = "Invalid Email ID !!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

        }

        
    }
}