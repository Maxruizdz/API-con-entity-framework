using minimallAPI_rest.Properties.modelos;
using System.Text.Json.Serialization;

namespace minimallAPI_rest.modelos
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string tipo_categoria { get; set; }
        public string url_foto { get; set; }

       [JsonIgnore]
        public virtual ICollection<Menu_Mobile> menus_Mobile_categoria { get; set; }

        [JsonIgnore]
        public virtual ICollection<Menu> menus_categoria { get; set; }

    }
}
