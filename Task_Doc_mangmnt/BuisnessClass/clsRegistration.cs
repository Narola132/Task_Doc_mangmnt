using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Task_Doc_mangmnt.BuisnessClass
{

    public class clsRegistration
    {
        DBConnection objDB = new DBConnection();
        public DataTable SelectadminRegistration()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectadminRegistration", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectRegistration()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectRegistration", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable SelectRegistrationID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selectregistration_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteRegistration(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                 objDB.ExecuteNon("DeleteRegistration", para);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void InsertRegistration(string Name, string Address, string Phone, string Username, string Password, int Role, string File)

        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[7];
                para[0] = new SqlParameter("@Name", Name);
                para[1] = new SqlParameter("@Address", Address);
                para[2] = new SqlParameter("@Phone", Phone);
                para[3] = new SqlParameter("@Username", Username);
                para[4] = new SqlParameter("@Password", Password);
                para[5] = new SqlParameter("@Role_Id", Role);
                para[6] = new SqlParameter("@FileUpload", File);

                objDB.ExecuteNon("InsertRegistration", para);
            }
            catch (Exception e)
            {
                    throw e;
            }

       }

        public void UpdateRegistration(int id, string Name, string Address, string Phone, string Username, string Password, int Role, string File)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[8];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@Name", Name);
                para[2] = new SqlParameter("@Address", Address);
                para[3] = new SqlParameter("@Phone", Phone);
                para[4] = new SqlParameter("@Username", Username);
                para[5] = new SqlParameter("@Password", Password);
                para[6] = new SqlParameter("@Role_Id", Role);
                para[7] = new SqlParameter("@FileUpload", File);
                objDB.ExecuteNon("UpdateRegistration", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable SelectUserdashboard(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@userid", id);

                dt = objDB.Getdata("SelectUserDashboardMaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectAdmindashboard()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];
               

                dt = objDB.Getdata("SelectAdminDashboardMaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}