using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Task_Doc_mangmnt.BuisnessClass;

namespace Task_Doc_mangmnt.BuisnessClass
{
    public class clsTask
    {
        DBConnection objDB = new DBConnection();



        public DataTable Selecttaskreport(int status, int cid, int userid, string startdate, string enddate,int taskid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[6];


                para[0] = new SqlParameter("@status", status);
                para[1] = new SqlParameter("@cid", cid);             
                para[2] = new SqlParameter("@uid",userid);

                para[3] = new SqlParameter("@sd", startdate);
                para[4] = new SqlParameter("@ed", enddate);
                para[5] = new SqlParameter("@tid", taskid);
                dt = objDB.Getdata("Selecttaskreport", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


       public DataTable SelecttaskMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectTaskmaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
       public DataTable Inserttaskmaster(string Name, string Description, DateTime Startdate, DateTime Enddate, int userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[5];
                para[0] = new SqlParameter("@Name", Name);
                para[1] = new SqlParameter("@Description", Description);
                para[2] = new SqlParameter("@Userid", userId);
                para[3] = new SqlParameter("@startdate", Startdate);
                para[4] = new SqlParameter("@enddate", Enddate);

                dt= objDB.Getdata("InsertTaskmaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Updatetaskmaster(int id, string Name, string Description, DateTime Startdate, DateTime Enddate,int userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[6];
                para[0] = new SqlParameter("@id", id);
                para[1] = new SqlParameter("@Name", Name);
                para[2] = new SqlParameter("@Description", Description);
                para[3] = new SqlParameter("@Userid", userId);
                para[4] = new SqlParameter("@startdate", Startdate);
                para[5] = new SqlParameter("@enddate", Enddate);

                objDB.ExecuteNon("UpdateTaskmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Deletetaskmaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id", id);
                objDB.ExecuteNon("DeleteTaskmaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelecttaskID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("selecttask_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelecttaskasignMaster()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[0];

                dt = objDB.Getdata("SelectTaskAsignMaster", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Inserttaskasignmaster(int taskid, int statusid, int companyid, int employeeid, DateTime Startdate, DateTime Enddate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[6];
                para[0] = new SqlParameter("@taskid", taskid);
                para[1] = new SqlParameter("@statusid", statusid);
                para[2] = new SqlParameter("@companyid", companyid);
                para[3] = new SqlParameter("@employeeid", employeeid);
                para[4] = new SqlParameter("@startdate", Startdate);
                para[5] = new SqlParameter("@enddate", Enddate);


                objDB.ExecuteNon("InsertTaskAsignmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdatetaskAsignmaster(int id, int taskid, int statusid, int companyid, int employeeid, DateTime Startdate, DateTime Enddate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[7];
                para[0] = new SqlParameter("@taskasignid", id);
                para[1] = new SqlParameter("@taskid", taskid);
                para[2] = new SqlParameter("@statusid", statusid);
                para[3] = new SqlParameter("@comapanyid", companyid);
                para[4] = new SqlParameter("@employeeid", employeeid);
                para[5] = new SqlParameter("@startdate", Startdate);
                para[6] = new SqlParameter("@enddate", Enddate);


               
                objDB.ExecuteNon("UpdateTaskAsignmaster", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Deletetaskasignmaster(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id", id);
                objDB.ExecuteNon("DeleteTaskAsignmaster", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelecttaskasignID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", id);
                dt = objDB.Getdata("SelectTaskasign_byid", para);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void InsertTaskdocument(int task_ID, string DocumentName)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Task_Id", task_ID);

                para[1] = new SqlParameter("@DocumentName", DocumentName);




                objDB.ExecuteNon("InsertTaskDocument", para);


            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Updatetasknotification(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@taskassignid", id);
                


                objDB.ExecuteNon("UpdateTaskNotification", para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

}
}