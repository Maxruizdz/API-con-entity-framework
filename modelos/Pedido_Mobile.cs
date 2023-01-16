using minimallAPI_rest.Properties.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.modelos
{
    public class Pedido_Mobile
    {
        public Guid Id_PedidoMobile { get; set; }
        public Guid id_usuario { get; set; }
        public int id_metodo_pago { get; set; }
        public int id_metodo_busqueda { get; set; }
         public string direccion { get; set; }
        public int id_estado_pedido { get; set; }

        public string fecha { get; set; }
         
        public string hora { get; set; }
        public Usuario usuario { get; set; }
        public Metodo_Pago metodo_pago { get; set; }

        public Metodo_Busqueda Metodo_Busqueda { get; set; }

        public Estado_Pedido Estado_Pedido { get; set; }

        [JsonIgnore]
        public virtual ICollection<Menu_Pedido_Mobile> pedido_Menus { get; set; }
    }
}
