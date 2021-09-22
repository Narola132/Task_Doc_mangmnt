using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;


    public class DBConnection
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter ad;

        public DBConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["HABITATConnectionString1"].ToString());
        }

        public void status()
        {

            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }
        public DataTable GetDataTable(string query)
        {
            try
            {

                DataTable dt = new DataTable();

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);


                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                ad.Dispose();
                con.Close();
            }


        }
        public void ExecuteNonQuery(string query)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                //ad.Dispose();
                con.Close();
            }
        }

        public DataTable GetData()
        {
            try
            {

                DataTable dt = new DataTable();
                //status();
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select_reg";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                
                
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                ad.Dispose();
                con.Close();
            }
        }

        public static int SendMail(string toaddress, string subject, string strHTML)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["Username"].ToString(), "Test");

                // You can specify the host name or ipaddress of your server
                // Default in IIS will be localhost 

                smtpClient.Host = ConfigurationManager.AppSettings["SMTP"].ToString();

                //Default port will be 25
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"].ToString());

                //From address will be given as a MailAddress Object
                message.From = fromAddress;

                // To address collection of MailAddress
                message.To.Add(toaddress);
                message.Subject = subject;


                message.IsBodyHtml = true;

                // Message body content
                message.Body = strHTML;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                // Send SMTP mail
                // ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

                smtpClient.Send(message);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable InsertShareHoldingMaster(int Fld_ScripCode, decimal? Fld_QuarterId, string Fld_Notes, DateTime? Fld_LetterDate,
                                DateTime? Fld_StampDate, string Fld_StatusNotRelicated, DateTime? Fld_EndDate, Int64? Fld_Tot_Cap_AC, DateTime? Fld_AuthoriseDateSubmitDateTime,
                                string Fld_DocumentName, decimal Fld_DocumentRecId)
        {
            DataTable dt = new DataTable();
            try
            {

                //status();
                con.Open();
                cmd = new SqlCommand("InsertShareHoldingMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Fld_ScripCode == 0)
                    cmd.Parameters.AddWithValue("@Fld_ScripCode", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Fld_ScripCode", Fld_ScripCode);
                cmd.Parameters.AddWithValue("@Fld_QuarterId", Fld_QuarterId);
                cmd.Parameters.AddWithValue("@Fld_Notes", Fld_Notes);
                cmd.Parameters.AddWithValue("@Fld_LetterDate", Fld_LetterDate);
                cmd.Parameters.AddWithValue("@Fld_StampDate", Fld_StampDate);
                cmd.Parameters.AddWithValue("@Fld_StatusNotRelicated", Fld_StatusNotRelicated);
                cmd.Parameters.AddWithValue("@Fld_EndDate", Fld_EndDate);
                cmd.Parameters.AddWithValue("@Fld_Tot_Cap_AC", Fld_Tot_Cap_AC);
                cmd.Parameters.AddWithValue("@Fld_AuthoriseDateSubmitDateTime", Fld_AuthoriseDateSubmitDateTime);
                cmd.Parameters.AddWithValue("@Fld_DocumentName", Fld_DocumentName);
                cmd.Parameters.AddWithValue("@Fld_DocumentRecId", Fld_DocumentRecId);
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                return dt;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                ad.Dispose();
                con.Close();

            }

        }

        public DataTable Getdata(string sp, SqlParameter[] para=null)
        {
            DataTable dt = new DataTable();
            try
            {

            con.Open();
            cmd = new SqlCommand(sp,con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
            {
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.AddWithValue(para[i].ParameterName, para[i].Value);
                    //cmd.Parameters.Add(para[i]);
                }

            }
            ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);

            return dt;
        }
             catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                //ad.Dispose();
                con.Close();
            }
        }

        public void ExecuteNon(string p, SqlParameter[] para)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                //ad.Dispose();
                con.Close();
            }
        }
    }
