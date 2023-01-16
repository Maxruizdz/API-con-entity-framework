using minimallAPI_rest.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Usuario
    {

        public Guid id_usuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nickname { get; set; }
         public string dni { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reserva> reservas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido_Mobile> pedido_mobile { get; set; }
    }
}
