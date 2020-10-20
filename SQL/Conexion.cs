using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCore.SQL
{
    public class Conexion
    {
        public string ConnectionString;
        public SqlConnection SqlConnection;
        private int CommandTimeOut = 10;
        public string error;
        public IConfiguration _configuration;

        public Conexion(IConfiguration _configuration)
        {
            this._configuration = _configuration;
            try
            {
                ConnectionString = _configuration.GetConnectionString("REACTConnection");
            }
            catch (Exception ex)
            {
                ConnectionString = "";
                SqlConnection = null;
                error = "Error! " + ex;
            }
        }

        public void getConnectionString()
        {
            try
            {
                ConnectionString = _configuration.GetConnectionString("REACTConnection");
            }
            catch (Exception ex)
            {
                error = "Error! " + ex;
            }
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (ConnectionString == "")
                    getConnectionString();

                SqlConnection = new SqlConnection(ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }

            return SqlConnection;
        }
    }
}
