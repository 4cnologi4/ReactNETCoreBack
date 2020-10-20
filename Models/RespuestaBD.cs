using System.Data;

namespace ReactCore.Models
{
    public class RespuestaBD
    {
        public static int CORRECTA = 1;
        public static int ERROR = 0;

        public int id { get; set; }
        public int transaccion { get; set; }
        public string mensaje { get; set; }
        public DataTable datos { get; set; }
        public DataSet dataSet { get; set; }

        public RespuestaBD()
        {
            id = -1;
            transaccion = 0;
            mensaje = "";
            datos = new DataTable();
            dataSet = new DataSet();
        }
    }
}
