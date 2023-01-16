using System.Text.Json.Serialization;

namespace minimallAPI_rest.modelos
{
    public class Estado_Pedido
    {
        public int id_estado_pedido { get; set; }
        public string estado_pedido { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido_Mobile> pedido_mobile { get; set; }
    }
}
