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
    public class ADOUsers : Conexion
    {
        public ADOUsers(IConfiguration configuration) : base(configuration)
        { }
        public RespuestaBD RolAcciones(string caso, Users user)
        {
            RespuestaBD respuestaBD = new RespuestaBD();
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UsersSP"
                };

                cmd.Parameters.AddWithValue("@caso", caso);
                cmd.Parameters.AddWithValue("@UserId", user._UserId);
                cmd.Parameters.AddWithValue("@user_name", user._UserName);
                cmd.Parameters.AddWithValue("@last_name", user._LastName);
                cmd.Parameters.AddWithValue("@discharge_date", user._DischargeDate);
                cmd.Parameters.AddWithValue("@age", user._Age);
                cmd.Parameters.AddWithValue("@Rol_Id", user._RolId);
                cmd.Parameters.AddWithValue("@Status", user._Status);

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

        public RespuestaBD GetUsers()
        {
            RespuestaBD respuestaBD = new RespuestaBD();
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from getInfoUserView"
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
