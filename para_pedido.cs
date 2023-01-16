namespace minimallAPI_rest
{
    public class para_pedido
    {
     
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }

        public string id_mesa { get; set; }

        public string fecha { get; set; }
        public string hora { get; set; }
        public Menu_acantidad[] menu_s { get; set; }
    }
}
