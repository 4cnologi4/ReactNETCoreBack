using Microsoft.Extensions.Configuration;
using ReactCore.Models;
using ReactCore.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCore.ADO
{
    public class ADORol : Conexion
    {
        public ADORol(IConfiguration configuration) : base(configuration)
        { }
        public RespuestaBD RolAcciones(string caso, Roles rol)
        {
            RespuestaBD respuestaBD = new RespuestaBD();
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "RolSP"
                };

                cmd.Parameters.AddWithValue("@caso", caso);
                cmd.Parameters.AddWithValue("@Rol_Id", rol._RolId);
                cmd.Parameters.AddWithValue("@Rol_name", rol._RolName);
                cmd.Parameters.AddWithValue("@Status", rol._RolStatus);

                connection.Open();
                respuestaBD.id = cmd.ExecuteNonQuery();
                respuestaBD.transaccion = RespuestaBD.CORRECTA;
                respuestaBD.mensaje = "Se realizó la operación correctamente!!!";
                connection.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                respuestaBD.transaccion = RespuestaBD.ERROR;
                respuestaBD.mensaje = "Ocurrió un error en la conexión o los datos proporcionados no son correctos " + ex.ToString();
            }

            return respuestaBD;
        }

        public RespuestaBD GetRoles()
        {
            RespuestaBD respuestaBD = new RespuestaBD();
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from getRolView"
                };

                connection.Open();
                SqlDataAdapter mySqlData = new SqlDataAdapter(cmd);
                mySqlData.Fill(respuestaBD.datos);
                connection.Close();
                mySqlData.Dispose();

                respuestaBD.mensaje = "Se realizó la operación correctamente!!!";
                respuestaBD.transaccion = RespuestaBD.CORRECTA;

            }
            catch (Exception ex)
            {
                respuestaBD.transaccion = RespuestaBD.ERROR;
                respuestaBD.mensaje = "Ocurrió un error en la conexión o los datos proporcionados no son correctos " + ex.ToString();
            }

            return respuestaBD;
        }

    }
}
