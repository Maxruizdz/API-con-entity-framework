using minimallAPI_rest.Properties.modelos;
using System.Security.Cryptography;
using System.Text;
namespace minimallAPI_rest
{
    public static class Comprobaciones
    {
    public    static async void creacionesde_mesa(string fecha, RestauranteContext dbContext)
        {

            foreach (Mesa mesa in dbContext.mesas)
            {
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid() , hora_reserva= "08:00"});
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "10:00" });
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "12:00" });
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "14:00" });
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "17:00" });
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "20:00" });
                dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("38043687-c388-4a59-ad74-766fd2677441"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "22:00" });




            }

            await dbContext.SaveChangesAsync();



        }
    public static  Boolean comprobacion_existen_reser(string fecha, RestauranteContext dbContext)
        {
            bool existen_reser = false;
            foreach (Reserva reserva in dbContext.reserva)
            {
                if (string.Compare(reserva.fecha_de_reseva, fecha) == 0)
                {

                    existen_reser = true;
                    break;


                }



            }
            return existen_reser;



        }
        public static int comprobacion_reser_posible(string fecha) {
            int dias = 0;
            DateTime dia_Actual = DateTime.Now;
            DateTime dia_a_reservar = Convert.ToDateTime(fecha);
            TimeSpan timeSpan = dia_a_reservar.Date - dia_Actual.Date;
            int dif_dias = timeSpan.Days;



            return dif_dias;
        
        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }




    }
}