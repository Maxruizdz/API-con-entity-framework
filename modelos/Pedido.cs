using minimallAPI_rest.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Pedido
    {
        public Guid id_Pedido { get; set; }
        public Guid id_mesaa { get; set; }

        public string id_dni_cliente { get; set; }

        [JsonIgnore]
        public Factura factura { get; set; }
        public int metodo_pago_pedido { get; set; }
        public string fecha_pedido { get; set; }
        public string hora_pedido { get; set; }

        public Mesa mesa_pedido { get; set; }
        public Metodo_Pago metodo{get;set;} 
        
        public Cliente cliente { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido_Menu> pedido_MenuS_pedidos{ get; set; }











    }

    
}
