using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimallAPI_rest;
using minimallAPI_rest.modelos;
using minimallAPI_rest.Properties.modelos;
using ExpressTimezone;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);





















builder.Services.AddCors(option =>
{

    option.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.SetIsOriginAllowed
(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();

    });

});



factura_para_enviar n1 = new factura_para_enviar();


builder.Services.AddSqlServer<RestauranteContext>(builder.Configuration.GetConnectionString("bd1"));

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);




app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] RestauranteContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});
app.MapPost("/api/usuario_create", async ([FromServices] RestauranteContext dbContext, [FromBody] Usuario Usuario_nuevo) =>

{
    string password_hash = Comprobaciones.GetSHA256(Usuario_nuevo.password).ToString();
    bool nicknamerepetido = false;
    bool email_repetido = false;
    bool dni_repetido = false;
    foreach (Usuario usuario in dbContext.usuarios)
    {
        if ((string.Compare(usuario.email, Usuario_nuevo.email)) == 0)
        {
            email_repetido = true;
        }
        if ((string.Compare(usuario.nickname, Usuario_nuevo.nickname)) == 0)
        {
            nicknamerepetido = true;
        }
        if ((string.Compare(usuario.dni, Usuario_nuevo.dni)) == 0)
        {
            dni_repetido = true;
        }
    }


    if (nicknamerepetido == true && email_repetido == true && dni_repetido == true)
    {

        Results.NotFound("el email, nickname y dni ya estan utilizados");

    }
    else if (email_repetido == true && nicknamerepetido == true && dni_repetido == false)
    {

        return Results.NotFound("El email y nickname ya esta registrado");
    }


    else if (nicknamerepetido == true && email_repetido == false && dni_repetido == false)
    {

        return Results.NotFound("El nickname ya estan siendo utilizado");


    }
    else if (email_repetido == true && nicknamerepetido == false && dni_repetido == false)
    {

        return Results.NotFound("El email ya esta registrado");
    }
    else if (email_repetido == true && nicknamerepetido == false && dni_repetido == true)
    {

        return Results.NotFound("El email y dni ya esta registrado");
    }
    else if (email_repetido == false && nicknamerepetido == true && dni_repetido == true)
    {

        return Results.NotFound("El nickname y dni ya esta registrado");
    }
    else if (email_repetido == false && nicknamerepetido == false && dni_repetido == true)
    {

        return Results.NotFound("El dni ya esta registrado");
    }

    else
    {

        Usuario_nuevo.password = password_hash;
        Usuario_nuevo.id_usuario = Guid.NewGuid();
        await dbContext.AddAsync(Usuario_nuevo);

        await dbContext.SaveChangesAsync();
        return Results.Ok(Usuario_nuevo);
    }
    return Results.NotFound();


});
app.MapPut("/api/login", async ([FromServices] RestauranteContext dbcontext, [FromBody] Usuario usuario_nuevo) =>
{
    bool cuentacorrecta = false;
    usuario_nuevo.password = Comprobaciones.GetSHA256(usuario_nuevo.password);

    foreach (Usuario usuario in dbcontext.usuarios)
    {
        if (string.Compare(usuario.password, usuario_nuevo.password) == 0 && string.Compare(usuario.email, usuario_nuevo.email) == 0)
        {
            usuario_nuevo.id_usuario = usuario.id_usuario;
            cuentacorrecta = true;
            break;

        }



    }
    if (cuentacorrecta == true)
    {
        var usuario = dbcontext.usuarios.Find(usuario_nuevo.id_usuario);
        return Results.Ok(usuario);

    }
    return Results.NotFound();




});








app.MapGet("/api/reservas/reserva/{fecha}/{hora}", async ([FromServices] RestauranteContext dbContext, [FromRoute] string fecha, [FromRoute] string hora) =>
{

    if (comprobacion_existen_reser(fecha, dbContext) == false)
    {

        creacionesde_mesa(fecha, dbContext);

        await dbContext.SaveChangesAsync();

    };





    return Results.Ok(dbContext.reserva.Include(p => p.MESA).Where(p => string.Compare(p.fecha_de_reseva, fecha) == 0 && string.Compare(p.hora_reserva, hora) == 0 && p.reservado == false));


});

app.MapGet("/api/reservas/{id_usuario}", async ([FromServices] RestauranteContext dbContext, [FromRoute] string id_usuario) =>
{
    Guid id_usu = Guid.Parse(id_usuario);

    return Results.Ok(dbContext.reserva.Include(p => p.MESA).Where(p => p.reservado == true && p.ID_usuario == id_usu));




});


app.MapPut("api/cancelar_reserva/{id_reserva}", async ([FromServices] RestauranteContext dbContext, [FromRoute] string id_reserva) =>
{
    Guid reserva_id = Guid.Parse(id_reserva);
    var reserva_actual = dbContext.reserva.Find(reserva_id);
    if (reserva_actual != null)
    {
        reserva_actual.cantidad_personas = 0;
        reserva_actual.ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c");
        reserva_actual.reservado = false;
        await dbContext.SaveChangesAsync();
        return Results.Ok();





    }
    return Results.NotFound();








});

app.MapDelete("/api/eliminar/{id_eliminar}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] Guid id_eliminar) =>
{

    foreach (Reserva resrva_eliminar in dbcontext.reserva)
    {

        if (resrva_eliminar.ID_usuario == id_eliminar)
        {

            dbcontext.reserva.Remove(resrva_eliminar);

        }


    }
    await dbcontext.SaveChangesAsync();
    return Results.Ok(dbcontext.reserva);




});


app.MapPut("/api/para_reservar/{id_usuario}/{id_mesa}/{cantidad_personas}/{fecha}/{hora}", async ([FromServices] RestauranteContext dbContext, [FromRoute] string id_mesa, [FromRoute] string id_usuario, [FromRoute] string cantidad_personas, [FromRoute] string fecha, [FromRoute] string hora) =>
{
    bool reserva_registrada = false;
    string id_reser = "";
    Guid mesa_id = Guid.Parse(id_mesa);
    Guid usuario = Guid.Parse(id_usuario);

    foreach (Reserva reservas in dbContext.reserva)
    {

        if (reservas.id_MESA == mesa_id && string.Compare(reservas.fecha_de_reseva, fecha) == 0 && reservas.reservado == false && string.Compare(reservas.hora_reserva, hora) == 0)
        {
            id_reser = reservas.id_reservar.ToString();
            dbContext.Remove(reservas);
            dbContext.Add(new Reserva() { reservado = true, fecha_de_reseva = fecha, id_MESA = mesa_id, ID_usuario = usuario, cantidad_personas = int.Parse(cantidad_personas), id_reservar = Guid.Parse(id_reser), hora_reserva = hora });
            reserva_registrada = true;

            break;
        }



    }




    await dbContext.SaveChangesAsync();
    if (reserva_registrada == true)
    {
        return Results.Ok(dbContext.reserva.Include(p => p.MESA).Include(p => p.usuario).Where(p => p.id_MESA == mesa_id && p.ID_usuario == usuario && string.Compare(p.fecha_de_reseva, fecha) == 0 && string.Compare(p.hora_reserva, hora) == 0));

    }
    else
        return Results.NotFound();




});
app.MapDelete("/api/eliminar_mesa/{id_eliminar}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] Guid id_eliminar) =>
{

    foreach (Reserva resrva_eliminar in dbcontext.reserva)
    {

        if (resrva_eliminar.id_MESA == id_eliminar)
        {

            dbcontext.Remove(resrva_eliminar);

        }


    }
    await dbcontext.SaveChangesAsync();
    return Results.Ok();




});
app.MapDelete("/api/eliminar_usuario", async ([FromServices] RestauranteContext dbcontext) =>
{



    foreach (Reserva resrva_eliminar in dbcontext.reserva)
    {

        dbcontext.Remove(resrva_eliminar);


    }
    await dbcontext.SaveChangesAsync();


});


app.MapPut("api/confirmar_pago/{id_reserva}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_reserva) =>
{
    Guid id = Guid.Parse(id_reserva);
    var reserva_actual = dbcontext.reserva.Find(id);

    if (reserva_actual != null)
    {
        reserva_actual.confirmo_reserva = true;
        await dbcontext.SaveChangesAsync();
        return Results.Ok();




    }
    else

        return Results.NotFound();




});
app.MapGet("api/get/menu", async ([FromServices] RestauranteContext dbcontext) =>
{




    return Results.Ok(dbcontext.Menus);




});
app.MapPost("create_ped/{nombre}/{apellido}/{dni}/{id_mesa}/{fecha}/{hora}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string nombre, [FromRoute] string apellido, [FromRoute] string dni, [FromRoute] string id_mesa, [FromRoute] string fecha, [FromRoute] string hora) =>
{



    var cliente = dbcontext.clientes.Find(dni);
    if (cliente == null)
    {
        Cliente cliente_nuevo = new Cliente();
        cliente_nuevo.dni = dni;
        cliente_nuevo.nombre_cliente = nombre;
        cliente_nuevo.apellido_cliente = apellido;
        dbcontext.AddAsync(cliente_nuevo);


    };

    var pedido_usuario = new Pedido();
    pedido_usuario.fecha_pedido = fecha;
    pedido_usuario.hora_pedido = hora;
    pedido_usuario.id_dni_cliente = dni;
    pedido_usuario.id_mesaa = Guid.Parse(id_mesa);
    pedido_usuario.id_Pedido = Guid.NewGuid();
    pedido_usuario.metodo_pago_pedido = 5;

    ganancia_met_pago n1 = new ganancia_met_pago();
    n1.id_ganacia = pedido_usuario.id_Pedido;
    n1.met_pagado = pedido_usuario.metodo_pago_pedido;
    n1.total = 0;
    n1.fecha = pedido_usuario.fecha_pedido;

    dbcontext.AddAsync(pedido_usuario);
    dbcontext.AddAsync(n1);






    await dbcontext.SaveChangesAsync();
    return Results.Ok(dbcontext.pedidos.Include(p => p.cliente).Include(p => p.mesa_pedido).Where(p => p.id_Pedido == pedido_usuario.id_Pedido));











});
app.MapPost("/crear/menu_pedido/{id_pedido}/{id_menu}/{cantidad}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido, [FromRoute] string id_menu, [FromRoute] string cantidad) =>
{

    var pedido = dbcontext.pedidos.Find(Guid.Parse(id_pedido));
    var menu = dbcontext.Menus.Find(Guid.Parse(id_menu));
    if (pedido != null && menu != null)
    {
        var menu_pedido = new Pedido_Menu();
        menu_pedido.ID_MENU = Guid.Parse(id_menu);
        menu_pedido.ID_PEDIDO_MENU = Guid.NewGuid();
        menu_pedido.pedido_ID = Guid.Parse(id_pedido);
        menu_pedido.cantidad = int.Parse(cantidad);
        dbcontext.AddAsync(menu_pedido);
        await dbcontext.SaveChangesAsync();
        return Results.Ok(menu_pedido);

    }
    else return Results.NotFound();







});


app.MapGet("api/get/metodo_pago", async ([FromServices] RestauranteContext dbcontext) =>
{




    return Results.Ok(dbcontext.metodo_Pagos);




});
app.MapGet("api/get/usuarios", async ([FromServices] RestauranteContext dbcontext) =>
{





    return Results.Ok(dbcontext.usuarios);




});

app.MapGet("api/get/mesas_reservadas/{fecha}/{hora}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string fecha, [FromRoute] string hora) =>
{



    return Results.Ok(dbcontext.reserva.Include(p => p.MESA).Where(p => string.Compare(p.fecha_de_reseva, fecha) == 0 && string.Compare(p.hora_reserva, hora) == 0 && p.reservado == true));



});
app.MapGet("api/get/mesas_Reser", async ([FromServices] RestauranteContext dbcontext) =>
{



    return Results.Ok(dbcontext.reserva.Include(p => p.MESA).Where(p => p.confirmo_reserva == true));



});
app.MapPut("confirmacion_depago/{id_pedido}/{metodo_pago}", async ([FromServices] RestauranteContext dbContext, [FromRoute] string id_pedido, string metodo_pago) =>
{

    Guid ig = Guid.Parse(id_pedido);
    var pedido_actual = dbContext.pedidos.Find(ig);
    var ganacia_pago = dbContext.ganado_metodo.Find(ig);


    if (pedido_actual != null)
    {


        pedido_actual.metodo_pago_pedido = int.Parse(metodo_pago);
        ganacia_pago.met_pagado = int.Parse(metodo_pago);
        await dbContext.SaveChangesAsync();
        return Results.Ok(dbContext.pedidos.Include(p => p.cliente).Include(p => p.mesa_pedido).Include(p => p.metodo).Where(p => p.id_Pedido == ig));


    }
    else
        return Results.NotFound();



});
app.MapPost("api/create_Empleado/{modo_rol}", async ([FromServices] RestauranteContext dbcontex, [FromBody] Empleado nuevo_empleado, [FromRoute] string modo_rol) =>

{

    bool nicknamerepetido = false;
    bool email_repetido = false;

    foreach (Empleado empleado in dbcontex.empleados)
    {
        if ((string.Compare(empleado.email_empleado, nuevo_empleado.email_empleado)) == 0)
        {
            email_repetido = true;
        }
        if ((string.Compare(empleado.nickname_empleado, nuevo_empleado.nickname_empleado)) == 0)
        {
            nicknamerepetido = true;
        }

    }


    if (nicknamerepetido == true && email_repetido == true)
    {

        Results.NotFound("el email, nickname ya estan utilizados");

    }
    else if (email_repetido == true && nicknamerepetido == false)
    {

        return Results.NotFound("El email ya esta registrado");
    }


    else if (nicknamerepetido == true && email_repetido == false)
    {

        return Results.NotFound("El nickname ya estan siendo utilizado");


    }
    else
    {

        nuevo_empleado.password_empleado = Comprobaciones.GetSHA256(nuevo_empleado.password_empleado);
        nuevo_empleado.rol = int.Parse(modo_rol);
        nuevo_empleado.id_empleado = Guid.NewGuid();
        await dbcontex.AddAsync(nuevo_empleado);

        await dbcontex.SaveChangesAsync();
        return Results.Ok(nuevo_empleado);
    }
    return Results.NotFound();




});


app.MapPut("/api/login_empleado", async ([FromServices] RestauranteContext dbcontext, [FromBody] Empleado empleado_nuevo) =>
{
    bool cuentacorrecta = false;
    empleado_nuevo.password_empleado = Comprobaciones.GetSHA256(empleado_nuevo.password_empleado);

    foreach (Empleado usuario in dbcontext.empleados)
    {
        if (string.Compare(usuario.password_empleado, empleado_nuevo.password_empleado) == 0 && string.Compare(usuario.email_empleado, empleado_nuevo.email_empleado) == 0)
        {
            empleado_nuevo.id_empleado = usuario.id_empleado;
            cuentacorrecta = true;
            break;

        }



    }
    if (cuentacorrecta == true)
    {
        var usuario = dbcontext.empleados.Find(empleado_nuevo.id_empleado);
        return Results.Ok(usuario);

    }
    return Results.NotFound();






});
app.MapPost("api/create_Pedido", async ([FromServices] RestauranteContext dbcontext, [FromBody] para_pedido pedido) =>
{

    var cliente = dbcontext.clientes.Find(pedido.dni);
    if (cliente == null)
    {
        Cliente cliente_nuevo = new Cliente();
        cliente_nuevo.dni = pedido.dni;
        cliente_nuevo.nombre_cliente = pedido.nombre;
        cliente_nuevo.apellido_cliente = pedido.apellido;
        dbcontext.AddAsync(cliente_nuevo);


    };

    Pedido pedido_usuario = new Pedido();
    pedido_usuario.fecha_pedido = pedido.fecha;
    pedido_usuario.hora_pedido = pedido.hora;
    pedido_usuario.id_dni_cliente = pedido.dni;
    pedido_usuario.id_mesaa = Guid.Parse(pedido.id_mesa);
    pedido_usuario.id_Pedido = Guid.NewGuid();
    pedido_usuario.metodo_pago_pedido = 5;




    dbcontext.AddAsync(pedido_usuario);




    creacion_De_menus(pedido.menu_s, pedido_usuario.id_Pedido, dbcontext);

    await dbcontext.SaveChangesAsync();
    return Results.Ok(dbcontext.pedidos.Include(p => p.cliente).Include(p => p.mesa_pedido).Where(p => p.id_Pedido == pedido_usuario.id_Pedido));
});

app.MapGet("probando_pedidos", async ([FromServices] RestauranteContext dbcontext) =>
{


    return Results.Ok(dbcontext.pedidos.Include(p => p.mesa_pedido).Include(p => p.cliente).Include(p => p.metodo));
});



void creacionesde_mesa(string fecha, RestauranteContext dbContext)
{

    foreach (Mesa mesa in dbContext.mesas)
    {
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "08:00" });
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "10:00" });
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "12:00" });
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "14:00" });
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "17:00" });
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "20:00" });
        dbContext.Add(new Reserva() { reservado = false, fecha_de_reseva = fecha, id_MESA = mesa.id_mesa, ID_usuario = Guid.Parse("b8c0f145-9824-4980-b280-185db05bb52c"), cantidad_personas = 0, id_reservar = Guid.NewGuid(), hora_reserva = "22:00" });




    }





}
void creacion_De_menus(Menu_acantidad[] cantidad_menu, Guid id_pedido, RestauranteContext db_context)
{

    for (int i = 0; i < cantidad_menu.Length; i++)
    {
        if (cantidad_menu[i] != null)
        {

            Pedido_Menu nuevo_pedido = new Pedido_Menu();
            nuevo_pedido.ID_PEDIDO_MENU = Guid.NewGuid();
            nuevo_pedido.pedido_ID = id_pedido;
            nuevo_pedido.ID_MENU = Guid.Parse(cantidad_menu[i].id_men);
            nuevo_pedido.cantidad = cantidad_menu[i].cantidad;
            db_context.AddAsync(nuevo_pedido);



        }







    }





}
Boolean comprobacion_existen_reser(string fecha, RestauranteContext dbContext)
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
app.MapGet("probando_menus_pedido/{id_pedido}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) =>

{


    return Results.Ok(dbcontext.pedidos_menus.Where(p => p.pedido_ID == Guid.Parse(id_pedido)));


});


app.MapPost("create_factura/{id_pedido}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) =>
{

    Guid idpedi = Guid.Parse(id_pedido);
    var pedido_Actual = dbcontext.pedidos.Find(idpedi);




    return Results.Ok(dbcontext.pedidos_menus.Include(p => p.menu).Where(p => p.pedido_ID == idpedi).Include(p => p.pedidoss));

});
app.MapGet("create_factura/get_cliente/{id_pedido}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) =>
{

    Guid idpedi = Guid.Parse(id_pedido);
    var pedido_Actual = dbcontext.pedidos.Find(idpedi);
    var cliente_actual = dbcontext.clientes.Find(pedido_Actual.id_dni_cliente);





    return Results.Ok(dbcontext.clientes.Where(p => p.dni != null && string.Compare(p.dni, cliente_actual.dni) == 0));

});


//DateTime fecha_in = Convert.ToDateTime(fecha_inicial);
//DateTime fecha_fi = Convert.ToDateTime(fecha_final);
//met_pagcs[] metodos_utilizados = new met_pagcs[metodos_requeridos.Length];

//for (int i = 0; i < metodos_requeridos.Length; i++)
//{

//    metodos_utilizados[i] = new met_pagcs() { metodo_pago = metodos_requeridos[i], Total = 0 };
//};
//foreach (Pedido pedidos in dbcontext.pedidos) {
//    DateTime fecha_comparar = Convert.ToDateTime(pedidos.fecha_pedido);
//    if (fecha_comparar.Date >= fecha_in.Date && fecha_comparar.Date <= fecha_fi.Date) {

//        for (int i = 0; i < metodos_requeridos.Length; i++) {
//            if (pedidos.metodo_pago_pedido == metodos_requeridos[i])
//            {
//                foreach (Pedido_Menu pedido_menu in dbcontext.pedidos_menus) {

//                if(pedidos.id_Pedido == pedido_menu.pedido_ID) {
//                        double total = 0;
//               total =pedido_menu.menu.precio*pedido_menu.cantidad;
//                        metodos_utilizados[i].Total = total;
//                }





//            }

//        }





//        }



//        }

//        return Results.Ok(metodos_requeridos);






app.MapGet("MOSTRAR_totales_ganado/{fecha_inicial}/{fecha_final}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string fecha_inicial, [FromRoute] string fecha_final, [FromBody] List<int> metodos_requeridos) =>
{
    DateTime fecha_in = Convert.ToDateTime(fecha_inicial);
    int[] metods = metodos_requeridos.ToArray();
    DateTime fecha_fi = Convert.ToDateTime(fecha_final);
    double probando_que = 0;

    met_pagcs[] metodos_utilizados = new met_pagcs[metods.Length];
    for (int o = 0; o < metodos_utilizados.Length; o++)
    {
        if (metods[o] == 1)
        {
            metodos_utilizados[o] = new met_pagcs() { metodo_pago = metods[o], tipo_de_pago = "Efectivo", Total = 0 };
        }
        else if (metods[o] == 2)
        {
            metodos_utilizados[o] = new met_pagcs() { metodo_pago = metods[o], tipo_de_pago = "Tarjeta de Credito", Total = 0 };
        }
        else if (metods[o] == 3)
        {
            metodos_utilizados[o] = new met_pagcs() { metodo_pago = metods[o], tipo_de_pago = "Tarjeta de Debito", Total = 0 };
        }
        else if (metods[o] == 4)
        {
            metodos_utilizados[o] = new met_pagcs() { metodo_pago = metods[o], tipo_de_pago = "Plataforma Digital", Total = 0 };
        }
    }
    met_pagcs metod = new met_pagcs();
    informe informe = new informe();



    List<Pedido> pedidos = dbcontext.pedidos.Where(p => (metodos_requeridos.Contains(p.metodo_pago_pedido))).Include(p => p.pedido_MenuS_pedidos).Include(p => p.metodo).ToList();
    double total_todo = 0;

    foreach (Pedido pedi in pedidos)
    {
        DateTime fecha_comparar = Convert.ToDateTime(pedi.fecha_pedido);

        if (fecha_comparar.Date >= fecha_in.Date && fecha_comparar.Date <= fecha_fi.Date)
        {

            foreach (Pedido_Menu pedidos_menu in dbcontext.pedidos_menus.Include(p => p.menu))
            {


                if (pedidos_menu.pedido_ID == pedi.id_Pedido)
                {


                    for (int i = 0; i < metodos_utilizados.Length; i++)
                    {


                        if (pedi.metodo_pago_pedido == metods[i])
                        {

                            metodos_utilizados[i].metodo_pago = pedi.metodo_pago_pedido;
                            metodos_utilizados[i].Total += pedidos_menu.menu.precio * pedidos_menu.cantidad;
                            total_todo += pedidos_menu.menu.precio * pedidos_menu.cantidad;


                        }



                    }


                }



            }



        }
    }


    informe nuevo_informe = new informe();
    nuevo_informe.metodos_utilizados = metodos_utilizados.ToArray();
    nuevo_informe.Total = total_todo;
    var probando = nuevo_informe;
    return Results.Ok(probando);

});





app.MapPost("crear_plato", async ([FromServices] RestauranteContext dbcontext, [FromBody] Menu menu) =>

{
    menu.id_menu = Guid.NewGuid();
    dbcontext.AddAsync(menu);
    await dbcontext.SaveChangesAsync();

    return Results.Ok(menu);





});
app.MapGet("subir_platos_deldia", async ([FromServices] RestauranteContext dbcontex) => 
{
    DateTime dia_actual = DateTime.Now.Date;
    string fecha_Actual = dia_actual.Date.ToString();
    


    string fecha = fecha_Actual.Replace("/", "-");
    string fech = fecha.Substring(0, 10);
    return Results.Ok(dbcontex.menu_Mobiles.Where(p=>p.id_MenuMobile != null && string.Compare(p.fecha_creacion,fech) == 0).Include(p=>p.categoria));

});
app.MapGet("ver_categorias", async ([FromServices] RestauranteContext dbcontext) =>
{

    return Results.Ok(dbcontext.categorias);

});
app.MapGet("ver_mesas", async ([FromServices] RestauranteContext dbcontext) =>
{



    return Results.Ok(dbcontext.mesas);


});

app.MapPost("crear_menus_mobiles", async ([FromServices] RestauranteContext dbcontext, [FromBody] Menu_Mobile menu) =>
{
    menu.id_MenuMobile = Guid.NewGuid();
    dbcontext.AddAsync(menu);
    await dbcontext.SaveChangesAsync();

    return Results.Ok(dbcontext.menu_Mobiles.Where(p=>p.id_MenuMobile== menu.id_MenuMobile).Include(p=>p.categoria));



});
app.MapPost("creacion_pedido_mobile/{id_usuario}", async ([FromServices] RestauranteContext dbcontext,[FromBody] Pedido_Mobile pedido, [FromRoute] string id_usuario ) =>
{


    pedido.Id_PedidoMobile = Guid.NewGuid();
    pedido.id_usuario = Guid.Parse(id_usuario);
    
    dbcontext.Add(pedido);
    await dbcontext.SaveChangesAsync();


    return Results.Ok(pedido.Id_PedidoMobile);



});
app.MapPost("creando_menu_pedido", async ([FromServices] RestauranteContext dbcontext, List<Menu_Pedido_Mobile> menu_pedido) => 
{
    foreach (Menu_Pedido_Mobile menu in menu_pedido) {
        menu.id_pedido_menu_mobile = Guid.NewGuid();
        dbcontext.Add(menu);
    
    
    
    }

    await dbcontext.SaveChangesAsync();

    return Results.Ok(dbcontext.pedidos_menu_mobiles.Include(p=>p.menu_mobile).Include(p=>p.pedido_mobile));

});

app.MapGet("ver_pedido_individual/{id_pedido}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) => 
{
    int cont = 0;
    double total = 0;
    var Pedido_actual = dbcontext.pedidos_mobiles.Find(Guid.Parse(id_pedido));
    List<Menu_Pedido_Mobile> menu_pedidos = new List<Menu_Pedido_Mobile>();
    if (Pedido_actual != null)
    {
        menu_pedidos = dbcontext.pedidos_menu_mobiles.Where(p => p.id_pedido_mobile == Guid.Parse(id_pedido)).Include(p => p.menu_mobile).ToList();
        informaci_menu[] informaci_Menus = new informaci_menu[menu_pedidos.Count];
        foreach (Menu_Pedido_Mobile menu_mobile in menu_pedidos)
        {

            informaci_Menus[cont] = new informaci_menu() { plato = menu_mobile.menu_mobile.plato, porciones = menu_mobile.cantidad, total = menu_mobile.menu_mobile.precio * menu_mobile.cantidad,urlfoto=menu_mobile.menu_mobile.url_foto_menu };
            total += menu_mobile.menu_mobile.precio * menu_mobile.cantidad;

            cont++;

        }

        var usuario = dbcontext.usuarios.Find(Pedido_actual.id_usuario);
        var metodo_pago = dbcontext.metodo_Pagos.Find(Pedido_actual.id_metodo_pago);
        var metodo_busqueda = dbcontext.metodos_busqueda.Find(Pedido_actual.id_metodo_busqueda);
        var estados_pedidos = dbcontext.estados_pedidos.Find(Pedido_actual.id_estado_pedido);
        Informacion_Pedido informacion_pedido = new Informacion_Pedido() { id_pedidos=Pedido_actual.Id_PedidoMobile,menu_pedido = informaci_Menus, direccion = Pedido_actual.direccion, forma_De_retiro = metodo_busqueda.tipo_deBusqueda, metodo_de_pago = metodo_pago.tipo_pago, fecha = Pedido_actual.fecha, hora = Pedido_actual.hora, nickname = usuario.nickname,estados_pedido= estados_pedidos.estado_pedido, Total = total };


        var pedido = informacion_pedido;

        return Results.Ok(pedido);


    }
    else return Results.NotFound();





});
app.MapGet("ver_listado_pedidos_mobile/{id_usuario}", async([FromServices] RestauranteContext dbcontext,[FromRoute] string id_usuario) => 
{
    var usuario = dbcontext.usuarios.Find(Guid.Parse(id_usuario));
    List<Informacion_Pedido> informacion_ = new List<Informacion_Pedido>();
    List<Menu_Pedido_Mobile> menu_pedidos = new List<Menu_Pedido_Mobile>();
    List<Pedido_Mobile> pedido_mobiles = dbcontext.pedidos_mobiles.Where(p => p.id_usuario == usuario.id_usuario).Where(p=>p.id_estado_pedido<6).ToList();
    List<Informacion_Pedido> informacion_Pedidos = new List<Informacion_Pedido>();
    foreach (Pedido_Mobile pedi_mobile in pedido_mobiles) {

        double total =0;
        int cont = 0;
        menu_pedidos = dbcontext.pedidos_menu_mobiles.Where(p => p.id_pedido_mobile == pedi_mobile.Id_PedidoMobile).Include(p => p.menu_mobile).ToList();
        informaci_menu[] informaci_Menus = new informaci_menu[menu_pedidos.Count];
        foreach (Menu_Pedido_Mobile menu_mobile in menu_pedidos)
        {

            informaci_Menus[cont] = new informaci_menu() { plato = menu_mobile.menu_mobile.plato, porciones = menu_mobile.cantidad, total = menu_mobile.menu_mobile.precio * menu_mobile.cantidad,urlfoto=menu_mobile.menu_mobile.url_foto_menu };
            total += menu_mobile.menu_mobile.precio * menu_mobile.cantidad;

            cont++;

        }
        var usuarios = dbcontext.usuarios.Find(pedi_mobile.id_usuario);
        var metodo_pago = dbcontext.metodo_Pagos.Find(pedi_mobile.id_metodo_pago);
        var metodo_busqueda = dbcontext.metodos_busqueda.Find(pedi_mobile.id_metodo_busqueda);
        var estados_pedidos = dbcontext.estados_pedidos.Find(pedi_mobile.id_estado_pedido);

        Informacion_Pedido informacion_pedido = new Informacion_Pedido() {id_pedidos=pedi_mobile.Id_PedidoMobile, menu_pedido = informaci_Menus, direccion = pedi_mobile.direccion, forma_De_retiro = metodo_busqueda.tipo_deBusqueda, metodo_de_pago = metodo_pago.tipo_pago, fecha = pedi_mobile.fecha, hora = pedi_mobile.hora, nickname = usuario.nickname, estados_pedido = estados_pedidos.estado_pedido, Total = total };
        informacion_Pedidos.Add(informacion_pedido);


    }


    var listado_pedido = informacion_Pedidos;


    return Results.Ok(listado_pedido);



});
app.MapGet("ver_listado_pedidos_mobile_terminados/{id_usuario}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_usuario) =>
{
    var usuario = dbcontext.usuarios.Find(Guid.Parse(id_usuario));
    List<Informacion_Pedido> informacion_ = new List<Informacion_Pedido>();
    List<Menu_Pedido_Mobile> menu_pedidos = new List<Menu_Pedido_Mobile>();
    List<Pedido_Mobile> pedido_mobiles = dbcontext.pedidos_mobiles.Where(p => p.id_usuario == usuario.id_usuario).Where(p => p.id_estado_pedido >= 6).ToList();
    List<Informacion_Pedido> informacion_Pedidos = new List<Informacion_Pedido>();
    foreach (Pedido_Mobile pedi_mobile in pedido_mobiles)
    {

        double total = 0;
        int cont = 0;
        menu_pedidos = dbcontext.pedidos_menu_mobiles.Where(p => p.id_pedido_mobile == pedi_mobile.Id_PedidoMobile).Include(p => p.menu_mobile).ToList();
        informaci_menu[] informaci_Menus = new informaci_menu[menu_pedidos.Count];
        foreach (Menu_Pedido_Mobile menu_mobile in menu_pedidos)
        {

            informaci_Menus[cont] = new informaci_menu() { plato = menu_mobile.menu_mobile.plato, porciones = menu_mobile.cantidad, total = menu_mobile.menu_mobile.precio * menu_mobile.cantidad, urlfoto=menu_mobile.menu_mobile.url_foto_menu };
            total += menu_mobile.menu_mobile.precio * menu_mobile.cantidad;

            cont++;

        }
        var usuarios = dbcontext.usuarios.Find(pedi_mobile.id_usuario);
        var metodo_pago = dbcontext.metodo_Pagos.Find(pedi_mobile.id_metodo_pago);
        var metodo_busqueda = dbcontext.metodos_busqueda.Find(pedi_mobile.id_metodo_busqueda);
        var estados_pedidos = dbcontext.estados_pedidos.Find(pedi_mobile.id_estado_pedido);

        Informacion_Pedido informacion_pedido = new Informacion_Pedido() { id_pedidos = pedi_mobile.Id_PedidoMobile, menu_pedido = informaci_Menus, direccion = pedi_mobile.direccion, forma_De_retiro = metodo_busqueda.tipo_deBusqueda, metodo_de_pago = metodo_pago.tipo_pago, fecha = pedi_mobile.fecha, hora = pedi_mobile.hora, nickname = usuario.nickname, estados_pedido = estados_pedidos.estado_pedido, Total = total };
        informacion_Pedidos.Add(informacion_pedido);


    }


    var listado_pedido = informacion_Pedidos;


    return Results.Ok(listado_pedido);



});

app.MapPut("actualizar_el_estadoPedidos/{id_pedido}", async([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) =>
{
    var pedido_actual = dbcontext.pedidos_mobiles.Find(Guid.Parse(id_pedido));
    if (pedido_actual.id_estado_pedido>=6){ }
    else { if (pedido_actual.id_metodo_busqueda == 2)
        {

            if (pedido_actual.id_estado_pedido == 3)
            {

                pedido_actual.id_estado_pedido = 5;


            }
            else if (pedido_actual.id_estado_pedido == 5) {



                pedido_actual.id_estado_pedido = 7;


            }
            else
            {

                pedido_actual.id_estado_pedido = pedido_actual.id_estado_pedido + 1;

            }



        }
        else {
            if (pedido_actual.id_estado_pedido == 3)
            {

                pedido_actual.id_estado_pedido = 4;


            }
           else if (pedido_actual.id_estado_pedido == 4)
            {

                pedido_actual.id_estado_pedido = 6;


            }
            else
            {

                pedido_actual.id_estado_pedido = pedido_actual.id_estado_pedido + 1;

            }


        }
    }
    await dbcontext.SaveChangesAsync();
   return Results.Ok();



});

app.MapDelete("eliminar_pedido_mobile/{id_pedido}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) =>
{
    var pedido_actual = dbcontext.pedidos_mobiles.Find(Guid.Parse(id_pedido));
    if (pedido_actual != null)
    {
        if (pedido_actual.id_estado_pedido <=2)
        {


            dbcontext.Remove(pedido_actual);
            await dbcontext.SaveChangesAsync();
            return Results.Ok("Su pedido fue cancelado");
         
        }
        else {
            return Results.Ok("su pedido no puede ser cancelado");
        }
        
        
        
    }
    else return Results.NotFound("el id ingresado no existe");    
});
app.MapPut("cancelar_pedido/{id_pedido}", async ([FromServices] RestauranteContext dbcontext, [FromRoute] string id_pedido) =>
{
    var pedido_actual = dbcontext.pedidos_mobiles.Find(Guid.Parse(id_pedido));
    if (pedido_actual != null)
    {
        if (pedido_actual.id_estado_pedido <= 2)
        {

            pedido_actual.id_estado_pedido = 10;
            await dbcontext.SaveChangesAsync();
            return Results.Ok("Su pedido fue cancelado");
        }
        else {

            return Results.Ok("Su pedido no puede ser cancelado");
        
        }

       
        
        
    }
    else return Results.NotFound();




});
app.MapGet("ver_menu_mobile/{id_menu}", async([FromServices] RestauranteContext dbcontext, [FromRoute]string id_menu) => 
{

   return Results.Ok(dbcontext.menu_Mobiles.Include(p => p.categoria).Where(p => p.id_MenuMobile == Guid.Parse(id_menu)));




});
app.MapGet("traer_menu_dia/{fecha}" , async([FromServices]RestauranteContext dbcontext, [FromRoute]string fecha) => 
{


    var menus_dia = dbcontext.menu_Mobiles.Where(p=>p.id_MenuMobile != null && string.Compare(p.fecha_creacion,fecha)==00).Include(p=>p.categoria);

    return Results.Ok(menus_dia);

    //var utctime= DateTime.UtcNow;
    //var argentinaTime = utctime.UTCToRegionalTime("America/Buenos_Aires");
    //DateTime zona_argen = argentinaTime;
    //return Results.Ok(zona_argen);
    


});
app.MapGet("ver_catconmenu/{fecha}/{id_categoria}", async([FromServices] RestauranteContext dbcontext,[FromRoute]string fecha, [FromRoute]string id_categoria) => 
{
    var menus_categoria = dbcontext.menu_Mobiles.Where(p => p.id_Categoria == int.Parse(id_categoria)&& string.Compare(p.fecha_creacion, fecha)==0).Include(p=>p.categoria);

    return Results.Ok(menus_categoria);

});


app.Run();
