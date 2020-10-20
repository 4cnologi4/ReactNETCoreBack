namespace ReactCore.Models
{
    public class RespuestaJS
    {
        public static int ESTADO_EXITO = 1;
        public static int ESTADO_ERROR = 0;

        public object datos { get; set; }
        public int estado { get; set; }
        public string mensaje { get; set; }
        public int httpCode { get; set; }


        public RespuestaJS()
        {
            datos = new object();
            estado = -1;
            mensaje = "";
            httpCode = 200;
        }

    }
}
