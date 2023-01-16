using System.Text.Json.Serialization;

namespace minimallAPI_rest.modelos
{
    public class Menu_Mobile
    {
        public Guid id_MenuMobile { get; set; }
        public string plato { get; set; }
         public int id_Categoria { get; set; }

        public string fecha_creacion { get; set; }

        public string url_foto_menu { get; set; }
        public string informacion_plato { get; set; }

        public Categoria categoria { get; set; }
        public double precio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Menu_Pedido_Mobile> pedido_Menus { get; set; }
    }
}
