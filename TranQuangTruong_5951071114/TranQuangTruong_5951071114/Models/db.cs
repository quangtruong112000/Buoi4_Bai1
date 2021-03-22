using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace TranQuangTruong_5951071114.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection(@"Data Source = LAPTOP - 8MK2IUGC; Initial Catalog = DemoCRUD; User ID = sa; Password=123456");
        //Select
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand command = new SqlCommand("Sp_Employee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                command.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                command.Parameters.AddWithValue("@City", emp.City);
                command.Parameters.AddWithValue("@STATE", emp.State);
                command.Parameters.AddWithValue("@Country", emp.Country);
                command.Parameters.AddWithValue("@Department", emp.Department);
                command.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return ds;
            }
        }
        //Insert and Update
        public string Empdml(Employee emp, out string msg)
        {
            msg = "";
            try
            {
                SqlCommand command = new SqlCommand("Sp_Employee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                command.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                command.Parameters.AddWithValue("@City", emp.City);
                command.Parameters.AddWithValue("@STATE", emp.State);
                command.Parameters.AddWithValue("@Country", emp.Country);
                command.Parameters.AddWithValue("@Department", emp.Department);
                command.Parameters.AddWithValue("@flag", emp.flag);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = e.Message;
                return msg;
            }        
        }

    }   
}
