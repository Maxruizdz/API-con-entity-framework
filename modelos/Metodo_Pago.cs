using minimallAPI_rest.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Metodo_Pago
    {
        public int id_MetodoPago { get; set; }
        public string tipo_pago { get; set; }

        [JsonIgnore]
        public virtual ICollection<Pedido> pedidos_metodos_pago { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido_Mobile> pedido_mobile { get; set; }

    }
}
