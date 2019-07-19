using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ValidationsAndCRUD_in_MVC_with_ADO.Net.Models
{
    public class EmpDbHandle
    {
        private SqlConnection con;
        private void Connection()
        {

            
            con = new SqlConnection("Data Source=YH10008653DT\\SQLEXPRESS2014;Initial Catalog=EmpDB;Integrated Security=True;Pooling=False");
            // string conString = ConfigurationManager.ConnectionStrings["empconn"].ConnectionString;
            //con = new SqlConnection(conString);
            
        }


        //************************************ADD NEW EMPLOYEE***********************************************
        public bool AddEmployee(Employee em)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddNewEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", em.name);
            cmd.Parameters.AddWithValue("@salary", em.salary);
            cmd.Parameters.AddWithValue("@contact", em.contact);
            cmd.Parameters.AddWithValue("@adderess", em.adderess);
            cmd.Parameters.AddWithValue("@emailId", em.emailId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
                return false;
        }
        //**************************************GET EMPLOYEE DETAILS*******************************************
        public List<Employee> GetEmployee()
        {
            Connection();
            List<Employee> empList = new List<Employee>();
            SqlCommand cmd = new SqlCommand("GetEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
           // con.Open();
            da.Fill(dt);
           // con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                empList.Add(new Employee
                {
                    id = Convert.ToInt32(dr["id"]),
                    name = Convert.ToString(dr["name"]),
                    salary = Convert.ToDouble(dr["salary"]),
                    contact = Convert.ToString(dr["contact"]),
                    adderess = Convert.ToString(dr["adderess"]),
                    emailId = Convert.ToString(dr["emailId"])
                });
            }
            return empList;
        }
        //****************************************UPDATE EMPLOYEE DETAILS***************************************
        public bool UpdateEmployeeDetails(Employee em)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EId", em.id);
            cmd.Parameters.AddWithValue("@name", em.name);
            cmd.Parameters.AddWithValue("@salary", em.salary);
            cmd.Parameters.AddWithValue("@contact", em.contact);
            cmd.Parameters.AddWithValue("@adderess", em.adderess);
            cmd.Parameters.AddWithValue("@emailId", em.emailId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        //******************************************DELETE EMPLOYEE DETAILS**************************************
        public bool DeleteEmployeeDetails(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    
    
    }
}