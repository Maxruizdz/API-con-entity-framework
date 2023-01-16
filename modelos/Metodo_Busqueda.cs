using System.Text.Json.Serialization;

namespace minimallAPI_rest.modelos
{
    public class Metodo_Busqueda
    {
        public int id_metodoBusqueda { get; set; }
        public string tipo_deBusqueda { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido_Mobile> pedido_mobile { get; set; }
    }
}
