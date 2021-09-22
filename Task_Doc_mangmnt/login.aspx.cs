using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Task_Doc_mangmnt.BuisnessClass;
namespace Task_Doc_mangmnt.Admin
{
    public partial class login : System.Web.UI.Page
    {
        clsCustom ObjC = new clsCustom();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            DataTable dt = ObjC.CheckAuthentication(txtusername.Text.Trim(), txtpassword.Text.Trim());

            if (dt.Rows.Count > 0)
            {
                Session["UserID"] = dt.Rows[0]["ID"].ToString();
                Session["RoleID"] = dt.Rows[0]["Role_Id"].ToString();
                Session["User_name"] = dt.Rows[0]["Name"].ToString();
                Session["User_Image"] = dt.Rows[0]["FileUpload"].ToString() == "" ? "~/img/Noimage.jpg" : dt.Rows[0]["FileUpload"].ToString();

                if (Convert.ToInt32(Session["RoleID"]) == 1)
                    Response.Redirect("FrmAdminDashboard.aspx");
                else
                    Response.Redirect("frmUserDashboard.aspx");
            }

            else
            {
                txtusername.Text = "";
                txtpassword.Text = "";

            }
        
        }



        protected void btnforgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmforgotpswd.aspx");
        }
    }
}