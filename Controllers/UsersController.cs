using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactCore.ADO;
using ReactCore.Models;

namespace ReactCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public RespuestaJS GetUsers()
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            List<Users> ListaUsers;
            RespuestaBD respuestaBD = new ADOUsers(_configuration).GetUsers();

            if (respuestaBD.transaccion == RespuestaBD.CORRECTA)
            {
                ListaUsers = LlenaLista(respuestaBD.datos.Rows);
                respuestaJS.estado = RespuestaJS.ESTADO_EXITO;
                respuestaJS.datos = ListaUsers;
            }
            else
            {
                respuestaJS.estado = RespuestaJS.ESTADO_ERROR;
                respuestaJS.mensaje = respuestaBD.mensaje;
            }
            respuestaJS.httpCode = Response.StatusCode;

            return respuestaJS;
        }

        // GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        public RespuestaJS InsertaUser([FromBody] Users user)
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            ADOUsers dataRol = new ADOUsers(_configuration);
            RespuestaBD respuestaBD = dataRol.RolAcciones("I", user);

            respuestaJS.estado = respuestaBD.transaccion == RespuestaBD.CORRECTA ?
                RespuestaJS.ESTADO_EXITO : RespuestaJS.ESTADO_ERROR;
            respuestaJS.mensaje = respuestaBD.mensaje;
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }

        // PUT api/<UsersController>/5
        [HttpPut("edita")]
        public RespuestaJS UpdateUser([FromBody] Users user)
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            ADOUsers dataRol = new ADOUsers(_configuration);
            RespuestaBD respuestaBD = dataRol.RolAcciones("U", user);

            respuestaJS.estado = respuestaBD.transaccion == RespuestaBD.CORRECTA ?
                RespuestaJS.ESTADO_EXITO : RespuestaJS.ESTADO_ERROR;
            respuestaJS.mensaje = respuestaBD.mensaje;
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("borrar/{id}")]
        public RespuestaJS DeleteUser(Users user)
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            ADOUsers dataRol = new ADOUsers(_configuration);
            RespuestaBD respuestaBD = dataRol.RolAcciones("D", user);

            respuestaJS.estado = respuestaBD.transaccion == RespuestaBD.CORRECTA ?
                RespuestaJS.ESTADO_EXITO : RespuestaJS.ESTADO_ERROR;
            respuestaJS.mensaje = respuestaBD.mensaje;
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }
        //last_name discharge_date  age Rol_Id  rol_name Status
        public List<Users> LlenaLista(DataRowCollection collection)
        {
            List<Users> ListaUsers = new List<Users>();
            foreach (DataRow fila in collection)
            {
                Users user = new Users(
                    Convert.ToInt32(fila["User_Id"]),
                    fila["user_name"].ToString(),
                    fila["last_name"].ToString(),
                    Convert.ToDateTime(fila["discharge_date"]),
                    Convert.ToInt32(fila["age"]),
                    Convert.ToInt32(fila["Rol_Id"]),
                    Convert.ToInt32(fila["Status"])
                );
                user._RolName = fila["rol_name"].ToString();
                ListaUsers.Add(user);
            }
            return ListaUsers;
        }

    }
}
