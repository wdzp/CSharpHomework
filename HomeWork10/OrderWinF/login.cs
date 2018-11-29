using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Login
{
    public class Program
    {
        static void data()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM userinfo";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    string name = reader.GetString(reader.GetOrdinal("name"));
                    string pwd = reader.GetString(reader.GetOrdinal("password"));
                    int age = reader.GetInt32(reader.GetOrdinal("age"));
                    string sex = reader.GetString(reader.GetOrdinal("sex"));
                    string phone = reader.GetString(reader.GetOrdinal("phone"));
                    string address = reader.GetString(reader.GetOrdinal("Address"));
                    Console.Write("ID:{0},Name:{1},PWD:{2},Age:{3},Sex:{4},Phone{5},Address:{6}\n", id, name, pwd, age, sex, phone, address);
                }
            }
            Console.ReadKey();
        }
        static string GetConnectString()
        {
            return "Data Source=(local);Initial Catalog=db1;Integrated Security=SSPI;";
        }

    }

}

