using PE_DE130011.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_DE130011.dao
{
    class ClassDAO
    {
        public bool Insert(DTO dto)
        {
            string sql = "INSERT INTO test2 (name, code) VALUES ( @name , @code )";
            using (SqlConnection con = DBHelper.GetDBConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = dto.Name;
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = dto.Code;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    e.StackTrace.ToString();
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
            return false;
        }

        public bool Update(DTO dto)
        {
            string sql = "UPDATE test2 SET name= @name, code = @code WHERE id= @id";
            using (SqlConnection con = DBHelper.GetDBConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = dto.Name;
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = dto.Code;
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = dto.ID;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    e.StackTrace.ToString();
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
            return false;
        }

        public bool Delete(DTO dto)
        {
            string sql = "DELETE FROM test2 WHERE id= @id";
            using (SqlConnection con = DBHelper.GetDBConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = dto.ID;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    e.StackTrace.ToString();
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
            return false;
        }

        public DataTable IsExisted(string name)
        {
            string sql = "SELECT * FROM test2 WHERE name = @name";
            DataTable dt = null;
            using (SqlConnection con = DBHelper.GetDBConnection())
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    dt = new DataTable();
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    con.Close();
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }
                return dt;
            }
        }

        public DataTable FindAll()
        {
            string sql = "SELECT * FROM test";
            DataTable dt = null;
            using (SqlConnection con = DBHelper.GetDBConnection())
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    dt = new DataTable();
                    // if have parameter -  cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
                catch (Exception e)
                {
                    con.Close();
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }
                return dt;
            }
        }
    }
}
