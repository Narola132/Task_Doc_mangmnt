using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

using System.Web;

namespace Task_Doc_mangmnt.BuisnessClass
{
    public class clsCustom
    {
        DBConnection objDB = new DBConnection();

        public void Changepassword(int id, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@Password", password);
                objDB.ExecuteNon("ChangePassword", para);

            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        

             public DataTable GetComponyReport(string search)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@search", search);

                dt = objDB.Getdata("SELECT_SEARCH_REPORT_COMPANY", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public DataTable GetUserReport(string search)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@search", search);

                dt = objDB.Getdata("SELECT_SEARCH_REPORT", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable checkemail(string Username)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Username", Username);


                dt = objDB.Getdata("forgotpswd", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }





        public DataTable CheckAuthentication(string Username, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Username", Username);
                para[1] = new SqlParameter("@Password", password);

                dt = objDB.Getdata("CheckAuthenticaation", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable CheckExitUser(string Username)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Username", Username);
                

                dt = objDB.Getdata("CheckExistUser", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable SelectprofileID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selectprofile_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateProfile(int id, string Name, string Address, string Phone, string File)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[5];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@Name", Name);
                para[2] = new SqlParameter("@Address", Address);
                para[3] = new SqlParameter("@Phone", Phone);
                para[4] = new SqlParameter("@FileUpload", File);
                objDB.ExecuteNon("UpdateProfile", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable GetselectRoleMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("selectRoleMaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void InsertRolemaster(string Name)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Name", Name);

                objDB.ExecuteNon("InsertRolemaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdateRolemaster(int id, string Name)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Roleid", id);
                para[1] = new SqlParameter("@Name", Name);

                objDB.ExecuteNon("UpdateRolemaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void DeleteRolemaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Roleid", id);
                objDB.ExecuteNon("DeleteRolemaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectRoleID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selectRole_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectstatusMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectStatusmaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            } 

        }
        public void Insertstatusmaster(string Name)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Name", Name);

                objDB.ExecuteNon("InsertStatusmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Updatestatusmaster(int id, string Name)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Statusid", id);
                para[1] = new SqlParameter("@Name", Name);

                objDB.ExecuteNon("UpdateStatusmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Deletestatusmaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Statusid", id);
                objDB.ExecuteNon("DeleteStatusmaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectstatusID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selectStatus_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectDesignTemplateMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectDesignTemplatemaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void InsertDesigntemplatemaster(string Name,int Userid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@TemplateName", Name);
                para[1] = new SqlParameter("@Userid", Userid);
                objDB.ExecuteNon("InsertDesignTemplatemaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdateDesigntemplatemaster(int id, string Name,int Userid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@TemplateName", Name);
                para[2] = new SqlParameter("@Userid", Userid);

                objDB.ExecuteNon("UpdateDesignTemplatemaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void DeleteDesigntemplatemaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id ", id);
                objDB.ExecuteNon("DeleteDesignTemplatemaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectDesigntemplatebyID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("SelectDesignTemplate_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable SelecttempfieldMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectTemplatefieldmaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Inserttempfieldmaster(int tempid, string fieldname, int userid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("@templateid", tempid);
                para[1] = new SqlParameter("@fieldname ", fieldname);
                para[2] = new SqlParameter("@userid", userid);
              


                objDB.ExecuteNon("InsertTemplatefieldmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Updatetempfieldmaster(int tempfieldid, int tempid, string fieldname, int userid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter("@templatefield", tempfieldid);
                para[1] = new SqlParameter("@templateid", tempid);
                para[2] = new SqlParameter("@fieldname ", fieldname);
                para[3] = new SqlParameter("@userid", userid);


                objDB.ExecuteNon("UpdateTemplatefieldmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Deletetempfieldmaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id", id);
                objDB.ExecuteNon("DeleteTemplatefieldmaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelecttempfieldID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("SelectTemplatefieldmaster_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}