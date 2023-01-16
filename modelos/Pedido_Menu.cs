using minimallAPI_rest.Properties.modelos;

namespace minimallAPI_rest.modelos
{
    public class Pedido_Menu
    { 
      public Guid ID_PEDIDO_MENU { get; set; }
        public Guid pedido_ID { get; set; }
        public Guid ID_MENU { get; set; }

        public int cantidad { get; set; }
        public Menu menu { get; set; }
        public Pedido pedidoss {get;set;}

    }
}
