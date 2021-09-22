using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task_Doc_mangmnt
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Convert.ToInt32(Session["RoleID"]) == 0)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
                Response.AddHeader("pragma", "no-cache");
            }
            setmenu();
        }
            protected void setmenu()
        {
        lblmsg.Text= "Wellcome," + Session["User_name"];
        userImage.Src = Session["User_Image"].ToString();
        }
        }
    }
