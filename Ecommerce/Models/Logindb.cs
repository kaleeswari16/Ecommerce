using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Models
{
    public class Logindb
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True;");

        public string saverecord(Login lg)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("details", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fname", lg.Name);
                    cmd.Parameters.AddWithValue("@lname", lg.lastname);
                    cmd.Parameters.AddWithValue("@email", lg.email);
                    cmd.Parameters.AddWithValue("@phno", lg.phoneno);
                    cmd.Parameters.AddWithValue("@dob", lg.dob);
                    cmd.Parameters.AddWithValue("@stad1", lg.stad1);
                    cmd.Parameters.AddWithValue("@stad2", lg.stad2);
                    cmd.Parameters.AddWithValue("@city", lg.city);
                    cmd.Parameters.AddWithValue("@state", lg.state);
                    cmd.Parameters.AddWithValue("@country", lg.country);
                    cmd.Parameters.AddWithValue("@postal", lg.postal);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return ("OK");
            }
                catch (Exception ex)
            {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    return (ex.Message.ToString());
               
            }
        }
        public List<Login>logins()
        {
            List<Login> cust_list = new List<Login>();
            try
            {
               
                //Employee em = new Employee();
                //DataSet ds = new DataSet();
              //  SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = Master; Integrated Security = True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("list", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cust_list.Add(new Login
                    {


                        Name = dr["fname"].ToString(),
                        lastname= dr["lname"].ToString(),
                        email = dr["email"].ToString(),
                        phoneno = dr["phno"].ToString(),
                        dob = dr["dob"].ToString(),
                        stad1 = dr["stad1"].ToString(),
                        stad2 = dr["stad2"].ToString(),
                        city = dr["City"].ToString(),
                        state = dr["state"].ToString(),
                        postal = dr["postal"].ToString(),
                        country = dr["country"].ToString(),
                       
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return cust_list;
        }
    }
 }
    
