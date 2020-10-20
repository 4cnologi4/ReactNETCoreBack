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
    public class RolController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RolController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<RolController>
        [HttpGet]
        public RespuestaJS GetRoles()
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            List<Roles> ListaRoles;
            RespuestaBD respuestaBD = new ADORol(_configuration).GetRoles();

            if (respuestaBD.transaccion == RespuestaBD.CORRECTA)
            {
                ListaRoles = LlenaLista(respuestaBD.datos.Rows);
                respuestaJS.estado = RespuestaJS.ESTADO_EXITO;
                respuestaJS.datos = ListaRoles;
            }
            else
            {
                respuestaJS.estado = RespuestaJS.ESTADO_ERROR;
                respuestaJS.mensaje = respuestaBD.mensaje;
            }
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }

        // POST api/<RolController>
        [HttpPost]
        public RespuestaJS InsertaRol([FromBody] Roles rol)
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            ADORol dataRol = new ADORol(_configuration);
            RespuestaBD respuestaBD = dataRol.RolAcciones("I", rol);

            respuestaJS.estado = respuestaBD.transaccion == RespuestaBD.CORRECTA ?
                RespuestaJS.ESTADO_EXITO : RespuestaJS.ESTADO_ERROR;
            respuestaJS.mensaje = respuestaBD.mensaje;
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }

        // PUT api/<RolController>/5
        [HttpPut("edita")]
        public RespuestaJS UpdateRol([FromBody] Roles rol)
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            ADORol dataRol = new ADORol(_configuration);
            RespuestaBD respuestaBD = dataRol.RolAcciones("U", rol);

            respuestaJS.estado = respuestaBD.transaccion == RespuestaBD.CORRECTA ?
                RespuestaJS.ESTADO_EXITO : RespuestaJS.ESTADO_ERROR;
            respuestaJS.mensaje = respuestaBD.mensaje;
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }

        // DELETE api/<RolController>/5
        [HttpDelete("borra/{id}")]
        public RespuestaJS DeleteRol(Roles rol)
        {
            RespuestaJS respuestaJS = new RespuestaJS();
            ADORol dataRol = new ADORol(_configuration);
            RespuestaBD respuestaBD = dataRol.RolAcciones("D", rol);

            respuestaJS.estado = respuestaBD.transaccion == RespuestaBD.CORRECTA ?
                RespuestaJS.ESTADO_EXITO : RespuestaJS.ESTADO_ERROR;
            respuestaJS.mensaje = respuestaBD.mensaje;
            respuestaJS.httpCode = Response.StatusCode;
            return respuestaJS;
        }

        //// GET api/<RolController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public List<Roles> LlenaLista(DataRowCollection collection)
        {
            List<Roles> ListaRoles = new List<Roles>();
            foreach (DataRow fila in collection)
            {
                Roles rol = new Roles(
                    Convert.ToInt32(fila["Rol_Id"]),
                    fila["rol_name"].ToString(),
                    Convert.ToInt32(fila["Status"])
                );
                ListaRoles.Add(rol);
            }
            return ListaRoles;
        }
    }
}
