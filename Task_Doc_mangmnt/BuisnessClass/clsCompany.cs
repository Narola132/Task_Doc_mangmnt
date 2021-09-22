using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Task_Doc_mangmnt.BuisnessClass
{
    public class clsCompany
    {
        DBConnection objDB = new DBConnection();
        public DataTable SelectCompanymaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectCompanymaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void DeleteCompanymaster(int Company_id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id", Company_id);
                objDB.ExecuteNon("DeleteCompanymaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable Insertcompanymaster(string Name, string Address, string Phone,string Email ,string ContactpersonName, string Contactphone, string Contactemail)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[7];
                para[0] = new SqlParameter("@Name", Name);
                para[1] = new SqlParameter("@Address", Address);
                para[2] = new SqlParameter("@Phone", Phone);
                para[3] = new SqlParameter("@Email", Email);
                para[4] = new SqlParameter("@ContactPersonName", ContactpersonName);
                para[5] = new SqlParameter("@ContactPhone", Contactphone);
                para[6] = new SqlParameter("@ContactEmail", Contactemail);

                dt = objDB.Getdata("InsertCompanymaster", para);
                return dt;
                
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Insertcompanydocument(int Compony_Id, string DocumentName, string FilePath, int User_Id)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter("@Compony_Id", Compony_Id);
                para[1] = new SqlParameter("@DocumentName", DocumentName);
                para[2] = new SqlParameter("@FilePath", FilePath);
                para[3] = new SqlParameter("@User_Id", User_Id);


                objDB.ExecuteNon("InsertCompanyDocument", para);


            }
            catch (Exception e)
            {
                throw e;
            }
        }
              

        public void Updatecompanymaster(int id, string Name, string Address, string Phone,string Email, string ContactpersonName, string Contactphone, string Contactemail)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[8];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@Name", Name);
                para[2] = new SqlParameter("@Address", Address);
                para[3] = new SqlParameter("@Phone", Phone);
                para[4] = new SqlParameter("@Email", Email);
                para[5] = new SqlParameter("@ContactPersonName", ContactpersonName);
                para[6] = new SqlParameter("@ContactPhone", Contactphone);
                para[7] = new SqlParameter("@ContactEmail", Contactemail);

                objDB.ExecuteNon("UpdateCompanymaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable SelectCompanyRegistrationID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selectCompanyregistration_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }


}