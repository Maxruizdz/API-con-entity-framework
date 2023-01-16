using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Factura
    {
        public Guid  id_factura { get; set; }
        public Guid pedidoID { get; set; }

        public double Total { get; set; }

       
        public Pedido pedido { get; set; }





    }
}
