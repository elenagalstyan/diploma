using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElenaGalstyan
{
    class Class1
    {
        private static SqlConnection getConnection()
        {
            return new SqlConnection ("Data Source =.\\SQLEXPRESS; Initial Catalog = reestr17; Integrated Security = true;");

        }
        //"Data Source =.\\SQLEXPRESS; Initial Catalog = reestr17; Integrated Security = true;"
        //@"Server=MZSASPRUT\SPRUT;Initial Catalog=reestr17;Integrated Security= true;"
        public static List<string> loadDataNamTech()
        {
            List<string> result = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand("SELECT NameTech FROM NAZVANIE", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader["NameTech"].ToString());
            }
            connection.Close();
            return result;
        }

        public static List<string> loadDataRazdel()
        {
            List<string> result = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand("SELECT NAME_IZMENEIA FROM RAZDEL_IZMENENIA", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader["NAME_IZMENEIA"].ToString());
            }
            connection.Close();
            return result;
        }
        public static List<string> loadDataNameizmenen()
        {
            List<string> result = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand("SELECT NAME FROM NAZVANIE_SPIS", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader["NAME"].ToString());
            }
            connection.Close();
            return result;
        }
        public static List<string> loadDataOtdelRazmeshen()
        {
            List<string> result = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand("SELECT OTDEL FROM NAZVANIE_OTDEL", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader["OTDEL"].ToString());
            }
            connection.Close();
            return result;
        }
        public static List<string> loadDataZakemchisl()
        {
            List<string> result = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand("SELECT CHISL FROM ZA_KEM_CHISLIT", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader["CHISL"].ToString());
            }
            connection.Close();
            return result;
        }


    }
}
