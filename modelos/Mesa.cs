using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Mesa
    {
        public Guid id_mesa { get; set; }
        public int numero_mesa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reserva> reservas_mesas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido> pedido_mesa { get; set; }

    }
}
