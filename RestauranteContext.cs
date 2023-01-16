using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using minimallAPI_rest.modelos;
using minimallAPI_rest.Properties.modelos;

namespace minimallAPI_rest
{
    public class RestauranteContext: DbContext
    {
        public DbSet<Reserva> reserva { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Mesa> mesas { get; set; }
        public DbSet<Empleado> empleados { get; set; }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Metodo_Pago> metodo_Pagos { get; set; }

        public DbSet<Factura> facturas { get; set; }
        public DbSet<Pedido> pedidos { get; set; }

        public DbSet<Pedido_Menu> pedidos_menus { get; set; }
        public DbSet<Categoria> categorias { get ; set; }
         
        public DbSet<tickect_mandar> tickets_mandar { get; set; }
         
        public DbSet<ganancia_met_pago> ganado_metodo { get; set; }

        public DbSet<Metodo_Busqueda> metodos_busqueda { get; set; }
        public DbSet<Estado_Pedido> estados_pedidos { get; set; }
        public DbSet<Menu_Mobile> menu_Mobiles { get;set; }
        public DbSet<Pedido_Mobile> pedidos_mobiles { get; set; }
        public DbSet<Menu_Pedido_Mobile> pedidos_menu_mobiles { get; set; }

        public RestauranteContext(DbContextOptions<RestauranteContext> option) : base(option) { 
       
      
        
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder) {

            List<Mesa> initmesas = new List<Mesa>();
            List<Metodo_Pago> init_metodo_Pagos = new List<Metodo_Pago>();
            List<Categoria> init_categoria = new List<Categoria>();
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse(" fe2de405-c38e-4c90-ac52-da0540dfb4ef"), numero_mesa = 1 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), numero_mesa = 2 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb403"), numero_mesa = 3 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb404"), numero_mesa = 4 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb405"), numero_mesa = 5 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb406"), numero_mesa = 6 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb407"), numero_mesa = 7 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb408"), numero_mesa = 8 });
            initmesas.Add(new Mesa() { id_mesa = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb409"), numero_mesa = 9 });
            List<Menu> initMenu = new List<Menu>();
            initMenu.Add(new Menu { id_menu = Guid.Parse("0f860902-f798-4c59-a513-1ebd0b39bbe8"), comida = "Medialunas", idcategoria = 1, precio = 100 });
            init_metodo_Pagos.Add(new Metodo_Pago { id_MetodoPago = 1, tipo_pago = "Efectivo" });
            init_metodo_Pagos.Add(new Metodo_Pago { id_MetodoPago = 2, tipo_pago = "Tarjeta de Credito" });
            init_metodo_Pagos.Add(new Metodo_Pago { id_MetodoPago = 3, tipo_pago = "Tarjeta de Debito" });
            init_metodo_Pagos.Add(new Metodo_Pago { id_MetodoPago = 4, tipo_pago = "Plataforma Digital" });
            init_metodo_Pagos.Add(new Metodo_Pago { id_MetodoPago = 5, tipo_pago = "No se realizo el pago" });
            init_categoria.Add(new Categoria() { CategoriaId = 1, tipo_categoria = "Cafe" });
            init_categoria.Add(new Categoria() { CategoriaId = 2, tipo_categoria = "Te" });
            init_categoria.Add(new Categoria() { CategoriaId = 3, tipo_categoria = "Platos Principales" });
            init_categoria.Add(new Categoria() { CategoriaId = 4, tipo_categoria = "Factura" });
            init_categoria.Add(new Categoria() { CategoriaId = 5, tipo_categoria = "Entradas" });
            init_categoria.Add(new Categoria() { CategoriaId = 6, tipo_categoria = "Postres" });
            init_categoria.Add(new Categoria() { CategoriaId = 7, tipo_categoria = "Bebidas" });
            init_categoria.Add(new Categoria() { CategoriaId = 8, tipo_categoria = "Tragos" });
           
            List<Estado_Pedido> estados_pedido_init = new List<Estado_Pedido>();
            estados_pedido_init.Add(new Estado_Pedido() {id_estado_pedido= 1 , estado_pedido="Por confirmar"});
            estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 2, estado_pedido = "Pedido confirmado" });
            estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 3, estado_pedido = "En preparacion" });
            estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 4, estado_pedido = "En camino" });
          estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 5, estado_pedido = "Listo para retirar" });
            estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 6, estado_pedido = "Entregado" });
            estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 7, estado_pedido = "Retirado" });

            estados_pedido_init.Add(new Estado_Pedido() { id_estado_pedido = 10, estado_pedido = "Cancelado" });

            List<Metodo_Busqueda> init_met_busqueda = new List<Metodo_Busqueda>();
            init_met_busqueda.Add(new Metodo_Busqueda() {id_metodoBusqueda=1 ,tipo_deBusqueda="Delivery"});
            init_met_busqueda.Add(new Metodo_Busqueda() {id_metodoBusqueda=2 , tipo_deBusqueda="Retirar por el local"});
            modelbuilder.Entity<Mesa>(mesa => {

                mesa.ToTable("Mesa");
                mesa.HasKey(p => p.id_mesa);
                mesa.Property(p => p.numero_mesa).IsRequired();
                mesa.HasData(initmesas);




            });
            modelbuilder.Entity<Usuario>(usuario => {
                usuario.ToTable("usuario");
                usuario.HasKey(p => p.id_usuario);
                usuario.Property(p => p.email).HasMaxLength(30).IsRequired();
                usuario.Property(p => p.nickname).HasMaxLength(18).IsRequired(false);
                usuario.Property(p => p.password).HasMaxLength(200).IsRequired();
                usuario.Property(p => p.dni).IsRequired(false);
            });
            modelbuilder.Entity<Menu>(menu => {


                menu.ToTable("Menu");
                menu.HasKey(p => p.id_menu);
                menu.HasOne(p => p.categoria).WithMany(p => p.menus_categoria).HasForeignKey(p => p.idcategoria);
                menu.Property(p => p.comida).IsRequired();
                menu.Property(p => p.precio).IsRequired();
                menu.HasData(initMenu);



            });
            modelbuilder.Entity<Reserva>(reserva =>
            {
                reserva.ToTable("Reservas");
                reserva.HasKey(p => p.id_reservar);
                reserva.HasOne(p => p.MESA).WithMany(p => p.reservas_mesas).HasForeignKey(p => p.id_MESA);
                reserva.HasOne(p => p.usuario).WithMany(p => p.reservas).HasForeignKey(p => p.ID_usuario).IsRequired(false);
                reserva.Property(p => p.fecha_de_reseva).IsRequired();
                reserva.Property(p => p.hora_reserva).IsRequired();
                reserva.Property(p => p.confirmo_reserva);
                reserva.Property(p => p.cantidad_personas);







            });
            modelbuilder.Entity<Empleado>(empleado => {


                empleado.ToTable("Empleado");
                empleado.HasKey(p => p.id_empleado);
                empleado.Property(p => p.rol).IsRequired();
                empleado.Property(p => p.nickname_empleado).IsRequired();
                empleado.Property(p => p.email_empleado).IsRequired();
                empleado.Property(p => p.password_empleado).IsRequired();




            });
            modelbuilder.Entity<Cliente>(cliente => {



                cliente.ToTable("Cliente");
                cliente.HasKey(C => C.dni);
                cliente.Property(C => C.nombre_cliente).IsRequired();
                cliente.Property(C => C.apellido_cliente).IsRequired(); ;







            });
            modelbuilder.Entity<Metodo_Pago>(metodoPago =>
             {

                 metodoPago.ToTable("Metodo_Pago");
                 metodoPago.HasKey(m => m.id_MetodoPago);
                 metodoPago.Property(m => m.tipo_pago).IsRequired();
                 metodoPago.HasData(init_metodo_Pagos);













             });
            modelbuilder.Entity<Pedido>(pedido =>

            {
                pedido.ToTable("Pedido");
                pedido.HasKey(m => m.id_Pedido);
                pedido.HasOne(p => p.cliente).WithMany(p => p.pedidos).HasForeignKey(p => p.id_dni_cliente);
                pedido.HasOne(p => p.mesa_pedido).WithMany(p => p.pedido_mesa).HasForeignKey(p => p.id_mesaa);
                pedido.HasOne(p => p.metodo).WithMany(p => p.pedidos_metodos_pago).HasForeignKey(p => p.metodo_pago_pedido).IsRequired(false);
                pedido.Property(p => p.fecha_pedido).IsRequired();
                pedido.Property(p => p.hora_pedido).IsRequired();
            });



            modelbuilder.Entity<Factura>(factura =>
            {
                factura.ToTable(" Factura ");
                factura.HasKey(p => p.id_factura);
                factura.HasOne(p => p.pedido).WithOne(p => p.factura).HasForeignKey<Factura>(p => p.pedidoID);
                factura.Property(p => p.Total).IsRequired();







            });
            modelbuilder.Entity<Pedido_Menu>(pedi_menu =>
            {

                pedi_menu.ToTable("Pedido_Menu");
                pedi_menu.HasKey(p => p.ID_PEDIDO_MENU);
                pedi_menu.HasOne(p => p.menu).WithMany(p => p.pedido_Menus).HasForeignKey(p => p.ID_MENU);
                pedi_menu.HasOne(p => p.pedidoss).WithMany(p => p.pedido_MenuS_pedidos).HasForeignKey(p => p.pedido_ID);
                pedi_menu.Property(p => p.cantidad);

            });
            modelbuilder.Entity<Categoria>(categoria =>

            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.tipo_categoria).IsRequired();
                categoria.Property(p => p.url_foto).IsRequired(false);
                categoria.HasData(init_categoria);



            });
            modelbuilder.Entity<tickect_mandar>(P =>

            {

                P.ToTable("Ticket");
                P.HasKey(p => p.id_tickect);
                P.Property(p => p.plato);
                P.Property(p => p.precio_plat);





            });
            modelbuilder.Entity<ganancia_met_pago>(metodo =>
            {
                metodo.ToTable("Ganancia_metodo");
                metodo.HasKey(P => P.id_ganacia);
                metodo.Property(p => p.met_pagado);
                metodo.Property(p => p.total);
                metodo.Property(p => p.fecha).IsRequired(false);








            });
            modelbuilder.Entity<Metodo_Busqueda>(busqueda =>
            {

                busqueda.ToTable("Metodo_Busqueda");
                busqueda.HasKey(p => p.id_metodoBusqueda);
                busqueda.Property(p => p.tipo_deBusqueda);
                busqueda.HasData(init_met_busqueda);

            });
            modelbuilder.Entity<Menu_Mobile>(men_mob =>
            {
                men_mob.ToTable("Menu_Mobile");
                men_mob.HasKey(p => p.id_MenuMobile);
                men_mob.Property(p => p.plato).IsRequired();
                men_mob.HasOne(p => p.categoria).WithMany(p => p.menus_Mobile_categoria).HasForeignKey(p => p.id_Categoria);
                men_mob.Property(p => p.fecha_creacion).IsRequired();
                men_mob.Property(p => p.url_foto_menu).IsRequired(false);
                men_mob.Property(p => p.informacion_plato).IsRequired(false);
                men_mob.Property(p=> p.precio);





            });
            modelbuilder.Entity<Estado_Pedido>(estado =>
            {
                estado.ToTable("Estado_Pedido");
                estado.HasKey(p=>p.id_estado_pedido);
                estado.Property(p=>p.estado_pedido);
                estado.HasData(estados_pedido_init);
            
            
            
            
            });

            modelbuilder.Entity<Pedido_Mobile>(pedido => {
                pedido.ToTable("Pedido_Mobile");
                pedido.HasKey(p => p.Id_PedidoMobile);
                pedido.HasOne(p => p.usuario).WithMany(p => p.pedido_mobile).HasForeignKey(p=>p.id_usuario);
                pedido.HasOne(p => p.metodo_pago).WithMany(p => p.pedido_mobile).HasForeignKey(p => p.id_metodo_pago);
                pedido.HasOne(p => p.Estado_Pedido).WithMany(p => p.pedido_mobile).HasForeignKey(p => p.id_estado_pedido);
                pedido.HasOne(p => p.Metodo_Busqueda).WithMany(p => p.pedido_mobile).HasForeignKey(p => p.id_metodo_busqueda);
                pedido.Property(p=>p.direccion);
                pedido.Property(p => p.fecha);
                pedido.Property(p => p.hora);







            });
            modelbuilder.Entity<Menu_Pedido_Mobile>(menuPed => 
            {
                menuPed.ToTable("Menu_Pedido_Mobiles");
                menuPed.HasKey(p => p.id_pedido_menu_mobile);
                menuPed.HasOne(p => p.menu_mobile).WithMany(p => p.pedido_Menus).HasForeignKey(p=> p.id_menuMobile);
                menuPed.HasOne(p => p.pedido_mobile).WithMany(p => p.pedido_Menus).HasForeignKey(p => p.id_pedido_mobile);
                menuPed.Property(p=>p.cantidad);



            });



        }

    }
}
