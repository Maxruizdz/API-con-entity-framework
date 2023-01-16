using minimallAPI_rest.Properties.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.modelos
{
    public class Cliente
    {
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public string dni { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido> pedidos { get; set; }

    }
}
