namespace minimallAPI_rest
{
    public class Informacion_Pedido
    { public Guid id_pedidos{get;set;}
        public informaci_menu[] menu_pedido { get; set; }
        public string nickname { get; set; }
        public string direccion { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }

        public string metodo_de_pago { get; set; }
        public string forma_De_retiro { get; set; }
        public string estados_pedido { get; set; }
        public double Total { get; set; }

    }
    public class informaci_menu { 
    public string plato { get; set; }
    public int porciones { get; set; }
    public double total { get; set; }
   public string urlfoto { get; set; }

    
    
    
    }
}
