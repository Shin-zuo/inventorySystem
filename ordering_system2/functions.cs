using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;


namespace ordering_system2
{
     class functions
    {
        private MySqlConnection Con;
        private MySqlCommand Cmd;
        private DataTable dt;
        private MySqlDataAdapter Sda;
        private string ConStr;

        public functions() 
        {
            ConStr = "Server=127.0.0.1;Port=3306;User Id=root;Database=cms2;";
            Con = new MySqlConnection(ConStr);
            Cmd = new MySqlCommand();
            Cmd.Connection = Con;

        }
        public MySqlConnection GetConnection() // New method to return the connection
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open(); // Open the connection if it is closed
            }
            return Con;
        }

        public DataTable GetData(string Query )
        {
            dt = new DataTable();
            using (Sda = new MySqlDataAdapter(Query, ConStr))
            {
                Sda.Fill(dt);
            }
            return dt;
        }

        public int SetData(string Query)
        {
            int Cnt = 0;
            if ( Con.State == ConnectionState.Closed ) 
            {
                Con.Open(); 
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
    }
}
