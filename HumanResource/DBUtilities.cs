using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource
{
    class DBUtilities
    {
        private string SERVER;
        private string DB;
        private string USERNAME;
        private string PASSWORD;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DBUtilities()
        {
            this.SERVER = @"HAMZA\MSSQLSERVER2012;";
            this.DB = "HumanResourceDB;";
            this.USERNAME = "sa;";
            this.PASSWORD = "Admin1234;";

            connection = new SqlConnection(ConstructConnectionString());
        }

        public DataTable QueryTable(string query)
        {
            try
            {
                DataTable table = new DataTable();  
                using (SqlCommand cmd = new SqlCommand())
                {
                    OpenConnection();
                    cmd.Connection = connection;
                    cmd.CommandText = query;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    CloseConnection();
                }
                return table;
            }
            catch(Exception ex)
            {
                string msg = ex.Message; // for debugging
                //return null;
                return null;
            }
        }

        private void OpenConnection()
        {
            try
            {
                if ((connection != null) && (connection.State == System.Data.ConnectionState.Closed))
                {
                    connection.Open();                   
                }               
            }
            catch (Exception ex)
            {
                
            }
        }

        private void CloseConnection()
        {
            try
            {
                if ((connection != null) && (connection.State == System.Data.ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool IsConnected()
        {
            try
            {
                if ((connection != null) && (connection.State == System.Data.ConnectionState.Closed))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private string ConstructConnectionString()
        {
            string returnVal = "Data Source=" + this.SERVER +
                                "Initial Catalog=" + this.DB +
                                "User Id=" + this.USERNAME +
                                "Password=" + this.PASSWORD;

            return returnVal;
        }
    }
}
