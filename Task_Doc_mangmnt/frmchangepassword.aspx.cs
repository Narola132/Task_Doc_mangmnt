using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task_Doc_mangmnt.BuisnessClass;

namespace Task_Doc_mangmnt
{
    public partial class frmchangepassword : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRegistration.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (Convert.ToInt32(Session["UserID"]) > 0)
            {
                objC.Changepassword(Convert.ToInt32(Session["UserID"]), txtpassword.Text);
                txtpassword.Text = "";
                txtcnfpswd.Text = "";
                lblmsg.Text = "Password sucessfully changed";
            }


        }
    }
}