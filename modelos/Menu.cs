using minimallAPI_rest.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Menu
    {
        public Guid id_menu { get; set; }
         
        public string comida { get; set; }
         public int idcategoria { get; set; }


         public double precio { get; set; }

        public Categoria categoria { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido_Menu> pedido_Menus { get; set; }
    }
}
