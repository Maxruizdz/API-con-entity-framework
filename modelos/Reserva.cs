using System.Text.Json.Serialization;

namespace minimallAPI_rest.Properties.modelos
{
    public class Reserva
    {
        public Guid id_reservar { get; set; }


        public Guid ID_usuario { get; set; }
        public Boolean confirmo_reserva { get; set; }
        public Guid id_MESA { get; set; }
        public string fecha_de_reseva{get;set;}
         public string hora_reserva { get; set; }
        public int cantidad_personas { get; set; }

        public Boolean reservado { get; set; }
     
        public Mesa MESA { get; set; }
    
        public Usuario usuario { get; set; }
    }
}
