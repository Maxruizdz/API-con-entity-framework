namespace minimallAPI_rest.Properties.modelos
{
    public class Empleado
    {
        public Guid id_empleado { get; set; }
        public int rol { get; set; }
        public string email_empleado { get; set; }
        public string password_empleado { get; set; }
        public string nickname_empleado { get; set; }

    }
}
