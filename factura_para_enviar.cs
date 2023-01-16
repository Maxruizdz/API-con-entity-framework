namespace minimallAPI_rest
{
    public class factura_para_enviar
    {
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string dni { get; set; }
        public string mesa { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }


        public menu_devolver[] menu_Devolvers { get; set; }

        public double total { get; set; }
    }
}
