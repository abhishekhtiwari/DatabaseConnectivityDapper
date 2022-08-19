using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Dapper;

namespace DatabaseConnectivity.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection con;
         
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: Home
        public void Index()
        {
            //Additing the employess      
            try
            {
                connection();
                con.Open();
                var data = SqlMapper.Query(con, "Select * from users");
                //IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(con, "GetEmployees").ToList();
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}