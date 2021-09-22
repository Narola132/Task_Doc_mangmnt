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
    public partial class frmUserprofile : System.Web.UI.Page
    {
        clsCustom objC = new clsCustom();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                EditRecord();
            }
        }
        protected void EditRecord()
        {

            DataTable dt = objC.SelectprofileID(Convert.ToInt32(Session["UserID"]));

            if (dt.Rows.Count > 0)
            {
                txtname.Text = Convert.ToString(dt.Rows[0]["Name"]);
                txtaddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                txtphone.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                userImage.Src = Convert.ToString(dt.Rows[0]["FileUpload"]);
            }

        }
        protected void btn_Upadatedetails_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            if (file.HasFile)
            {
                 
                
                filename = "FileUpload/" + txtname.Text + "." + file.FileName.Split('.').Last();
                file.SaveAs(Server.MapPath(filename));
            }
            else
            {
                filename = userImage.Src;
            }

            objC.UpdateProfile(Convert.ToInt32(Session["UserID"]), txtname.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), filename);
            Session["User_Image"] = filename;
            userImage.Src = filename;
            Response.Redirect("frmUserprofile.aspx");

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("defaultUser.aspx");
        }
    }
}