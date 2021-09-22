using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Task_Doc_mangmnt.BuisnessClass;

namespace Task_Doc_mangmnt.BuisnessClass
{
    public class clsRemarks
    {
        DBConnection objDB = new DBConnection();

        public DataTable SelectTaskRemarksMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectTaskRemarksmaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable InsertTaskRemarksmaster(int taskasignid, string remarks, int employeeid, int status)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter("@taskasign_id", taskasignid);
                para[1] = new SqlParameter("@remarks ", remarks);
                para[2] = new SqlParameter("@employee_id", employeeid);
                para[3] = new SqlParameter("@status", status);

                dt = objDB.Getdata("InsertRemarksmaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdateTaskRemarkmaster(int id, int taskasignid, string remarks, int employeeid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@taskasign_id", taskasignid);
                para[2] = new SqlParameter("@remarks ", remarks);
                para[3] = new SqlParameter("@employee_id", employeeid);

                objDB.ExecuteNon("UpdateRemarks", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void DeletetaskRemarksmaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id", id);
                objDB.ExecuteNon("DeleteRemarks", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelecttaskRemarksID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selectremarks_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void InsertTaskRemarksdocument(int taskremarksid, string Documentpath)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Taskremarksid", taskremarksid);

                para[1] = new SqlParameter("@Documentpath ", Documentpath);

                objDB.ExecuteNon("InsertRemarksDoc", para);


            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}