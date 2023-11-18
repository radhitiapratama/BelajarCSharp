using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace BelajarWindowsForm
{
    class Utils
    {
        public static SqlConnection con;

        public static void initCon()
        {
            con = new SqlConnection("Data Source=MYLAPTOP\\SQLEXPRESS;Initial Catalog=SocialNetwork;Integrated Security=True");
        }

        public static void open()
        {
            con.Open();
        }

        public static void close()
        {
            con.Close();
        }
    }

    class Encrypt
    {
        public static string enc(string data)
        {
            SHA256Managed managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(Encoding.UTF8.GetBytes(data)));

        }
    }
}
