namespace minimallAPI_rest.modelos
{
    public class Menu_Pedido_Mobile
    {
        public Guid id_pedido_menu_mobile { get; set; }
        public Guid id_pedido_mobile { get; set; }
        public Guid id_menuMobile { get; set; }
        public int cantidad { get; set; }
        public Menu_Mobile menu_mobile { get; set; }

        public Pedido_Mobile pedido_mobile { get; set; }


    }
}
