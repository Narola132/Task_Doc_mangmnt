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
    public partial class frmUserReport : System.Web.UI.Page
    {
        clsRegistration objR = new clsRegistration();
        clsCompany objCO = new clsCompany();
        clsCustom objCU = new clsCustom();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridreg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridreg.PageIndex = e.NewPageIndex;
            DataTable dt = objCO.SelectCompanymaster();
            gridreg.DataSource = dt;
            gridreg.DataBind();

            pnlbtndwnrsdt.Visible = true;
        }

        protected void btndwnrsdnt_Click(object sender, EventArgs e)
        {
            DataTable dt = objCU.GetComponyReport(txtrsdnt.Text.Trim());
            string str = "";
            if (dt.Rows.Count > 0)
            {
                txtrsdnt.Text = Convert.ToString(dt.Rows[0]["Compony_Id"]);
                foreach (DataRow dr in dt.Rows)
                {
                    str += dr["ComponyName"] + ",";

                    str += dr["Address"] + "," + "," + ",";
                    str += dr["Phone"] + "," + ",";
                    str += dr["Email"] + "," + ",";
                    str += dr["ContactPersonName"] + "," + ",";
                    str += dr["ContactPhone"] + "," + ",";

                    str += dr["ContactEmail"] + "," + "\n";
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

        protected void lnkbtnall_Click(object sender, EventArgs e)
        {
            DataTable dt = objCO.SelectCompanymaster();
            gridreg.DataSource = dt;
            gridreg.DataBind();

            lblmsg.Text = "";
            pnlbtndwnrsdt.Visible = true;
        }

        protected void btnsrsdnt_Click(object sender, EventArgs e)
        {
            if (txtrsdnt.Text.Trim() != "")
            {
                DataTable dt = objCU.GetComponyReport(txtrsdnt.Text);
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