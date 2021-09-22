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
    public partial class frmCmpReport : System.Web.UI.Page
    {
        clsRegistration objR = new clsRegistration();
        clsCustom objC = new clsCustom();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

  
        protected void lnkbtnall_Click(object sender, EventArgs e)
        {
            DataTable dt = objR.SelectRegistration();
            gridreg.DataSource = dt;
            gridreg.DataBind();

            lblmsg.Text = "";
            pnlbtndwnrsdt.Visible = true;

        }
        protected void btndwnrsdnt_Click(object sender, EventArgs e)
        {
            DataTable dt = objC.GetUserReport(txtrsdnt.Text.Trim());
            string str = "";
            if (dt.Rows.Count > 0)
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    str += dr["Name"] + ",";

                    str += dr["Address"] + "," + "," + ",";
                    str += dr["Phone"] + "," + ",";
                    str += dr["Username"] + "," + "\n";
                }

                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1, 1);
                }
                string name = DateTime.Now.ToString("ddMMyyyyhhmmss");
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-disposition", "attachment;filename=" + name + ".csv");
                Response.Charset = "";
                Response.ContentType = "application/csv";
                Response.Output.Write(str);
                Response.Flush();
                Response.End();
            }

        }

        protected void gridreg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridreg.PageIndex = e.NewPageIndex;
            DataTable dt = objR.SelectRegistration();
            gridreg.DataSource = dt;
            gridreg.DataBind();

            pnlbtndwnrsdt.Visible = true;
        }

        protected void btnsrsdnt_Click(object sender, EventArgs e)
        {
            if (txtrsdnt.Text.Trim() != "")
            {
                DataTable dt = objC.GetUserReport(txtrsdnt.Text);
                gridreg.DataSource = dt;
                gridreg.DataBind();
                

                pnlbtndwnrsdt.Visible = true;

                lblmsg.Text = "";
                gridreg.Visible = true;
                
            }
            else
            {
                lblmsg.Text = "Please Enter a Charecter For Searching the Record !!!";
            }
        }


     
   
    }
}