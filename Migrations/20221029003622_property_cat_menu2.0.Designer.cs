﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using minimallAPI_rest;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20221029003622_property_cat_menu2.0")]
    partial class property_cat_menu20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("minimallAPI_rest.modelos.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("tipo_categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url_foto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            tipo_categoria = "Cafe"
                        },
                        new
                        {
                            CategoriaId = 2,
                            tipo_categoria = "Te"
                        },
                        new
                        {
                            CategoriaId = 3,
                            tipo_categoria = "Platos Principales"
                        },
                        new
                        {
                            CategoriaId = 4,
                            tipo_categoria = "Factura"
                        },
                        new
                        {
                            CategoriaId = 5,
                            tipo_categoria = "Entradas"
                        },
                        new
                        {
                            CategoriaId = 6,
                            tipo_categoria = "Postres"
                        },
                        new
                        {
                            CategoriaId = 7,
                            tipo_categoria = "Bebidas"
                        },
                        new
                        {
                            CategoriaId = 8,
                            tipo_categoria = "Tragos"
                        });
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Cliente", b =>
                {
                    b.Property<string>("dni")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("apellido_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dni");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Estado_Pedido", b =>
                {
                    b.Property<int>("id_estado_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_estado_pedido"), 1L, 1);

                    b.Property<string>("estado_pedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_estado_pedido");

                    b.ToTable("Estado_Pedido", (string)null);

                    b.HasData(
                        new
                        {
                            id_estado_pedido = 1,
                            estado_pedido = "En espera"
                        },
                        new
                        {
                            id_estado_pedido = 2,
                            estado_pedido = "Su pedido fue tomado"
                        },
                        new
                        {
                            id_estado_pedido = 3,
                            estado_pedido = "Su pedido esta siendo pregarado"
                        },
                        new
                        {
                            id_estado_pedido = 4,
                            estado_pedido = "su pedido esta listo para retirarlo"
                        },
                        new
                        {
                            id_estado_pedido = 5,
                            estado_pedido = "Su pedido fue enviado"
                        },
                        new
                        {
                            id_estado_pedido = 6,
                            estado_pedido = "Finalizado"
                        },
                        new
                        {
                            id_estado_pedido = 10,
                            estado_pedido = "Su pedido fue Cancelado"
                        });
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.ganancia_met_pago", b =>
                {
                    b.Property<Guid>("id_ganacia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("met_pagado")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("id_ganacia");

                    b.ToTable("Ganancia_metodo", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Menu_Mobile", b =>
                {
                    b.Property<Guid>("id_MenuMobile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("fecha_creacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_Categoria")
                        .HasColumnType("int");

                    b.Property<string>("informacion_plato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("plato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<string>("url_foto_menu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_MenuMobile");

                    b.HasIndex("id_Categoria");

                    b.ToTable("Menu_Mobile", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Menu_Pedido_Mobile", b =>
                {
                    b.Property<Guid>("id_pedido_menu_mobile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("id_menuMobile")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_pedido_mobile")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id_pedido_menu_mobile");

                    b.HasIndex("id_menuMobile");

                    b.HasIndex("id_pedido_mobile");

                    b.ToTable("Menu_Pedido_Mobiles", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Metodo_Busqueda", b =>
                {
                    b.Property<int>("id_metodoBusqueda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_metodoBusqueda"), 1L, 1);

                    b.Property<string>("tipo_deBusqueda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_metodoBusqueda");

                    b.ToTable("Metodo_Busqueda", (string)null);

                    b.HasData(
                        new
                        {
                            id_metodoBusqueda = 1,
                            tipo_deBusqueda = "Delivery"
                        },
                        new
                        {
                            id_metodoBusqueda = 2,
                            tipo_deBusqueda = "Retirar por el local"
                        });
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Pedido_Menu", b =>
                {
                    b.Property<Guid>("ID_PEDIDO_MENU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_MENU")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("pedido_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID_PEDIDO_MENU");

                    b.HasIndex("ID_MENU");

                    b.HasIndex("pedido_ID");

                    b.ToTable("Pedido_Menu", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Pedido_Mobile", b =>
                {
                    b.Property<Guid>("Id_PedidoMobile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_estado_pedido")
                        .HasColumnType("int");

                    b.Property<int>("id_metodo_busqueda")
                        .HasColumnType("int");

                    b.Property<int>("id_metodo_pago")
                        .HasColumnType("int");

                    b.Property<Guid>("id_usuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id_PedidoMobile");

                    b.HasIndex("id_estado_pedido");

                    b.HasIndex("id_metodo_busqueda");

                    b.HasIndex("id_metodo_pago");

                    b.HasIndex("id_usuario");

                    b.ToTable("Pedido_Mobile", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.tickect_mandar", b =>
                {
                    b.Property<Guid>("id_tickect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("plato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio_plat")
                        .HasColumnType("float");

                    b.HasKey("id_tickect");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Empleado", b =>
                {
                    b.Property<Guid>("id_empleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email_empleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nickname_empleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password_empleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rol")
                        .HasColumnType("int");

                    b.HasKey("id_empleado");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Factura", b =>
                {
                    b.Property<Guid>("id_factura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<Guid>("pedidoID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id_factura");

                    b.HasIndex("pedidoID")
                        .IsUnique();

                    b.ToTable(" Factura ", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Menu", b =>
                {
                    b.Property<Guid>("id_menu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("comida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idcategoria")
                        .HasColumnType("int");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("id_menu");

                    b.HasIndex("idcategoria");

                    b.ToTable("Menu", (string)null);

                    b.HasData(
                        new
                        {
                            id_menu = new Guid("0f860902-f798-4c59-a513-1ebd0b39bbe8"),
                            comida = "Medialunas",
                            idcategoria = 1,
                            precio = 100.0
                        });
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Mesa", b =>
                {
                    b.Property<Guid>("id_mesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("numero_mesa")
                        .HasColumnType("int");

                    b.HasKey("id_mesa");

                    b.ToTable("Mesa", (string)null);

                    b.HasData(
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            numero_mesa = 1
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            numero_mesa = 2
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb403"),
                            numero_mesa = 3
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb404"),
                            numero_mesa = 4
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb405"),
                            numero_mesa = 5
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb406"),
                            numero_mesa = 6
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb407"),
                            numero_mesa = 7
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb408"),
                            numero_mesa = 8
                        },
                        new
                        {
                            id_mesa = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb409"),
                            numero_mesa = 9
                        });
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Metodo_Pago", b =>
                {
                    b.Property<int>("id_MetodoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_MetodoPago"), 1L, 1);

                    b.Property<string>("tipo_pago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_MetodoPago");

                    b.ToTable("Metodo_Pago", (string)null);

                    b.HasData(
                        new
                        {
                            id_MetodoPago = 1,
                            tipo_pago = "Efectivo"
                        },
                        new
                        {
                            id_MetodoPago = 2,
                            tipo_pago = "Tarjeta de Credito"
                        },
                        new
                        {
                            id_MetodoPago = 3,
                            tipo_pago = "Tarjeta de Debito"
                        },
                        new
                        {
                            id_MetodoPago = 4,
                            tipo_pago = "Plataforma Digital"
                        },
                        new
                        {
                            id_MetodoPago = 5,
                            tipo_pago = "No se realizo el pago"
                        });
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Pedido", b =>
                {
                    b.Property<Guid>("id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("fecha_pedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hora_pedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_dni_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("id_mesaa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("metodo_pago_pedido")
                        .HasColumnType("int");

                    b.HasKey("id_Pedido");

                    b.HasIndex("id_dni_cliente");

                    b.HasIndex("id_mesaa");

                    b.HasIndex("metodo_pago_pedido");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Reserva", b =>
                {
                    b.Property<Guid>("id_reservar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidad_personas")
                        .HasColumnType("int");

                    b.Property<bool>("confirmo_reserva")
                        .HasColumnType("bit");

                    b.Property<string>("fecha_de_reseva")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hora_reserva")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_MESA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("reservado")
                        .HasColumnType("bit");

                    b.HasKey("id_reservar");

                    b.HasIndex("ID_usuario");

                    b.HasIndex("id_MESA");

                    b.ToTable("Reservas", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Usuario", b =>
                {
                    b.Property<Guid>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("nickname")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("id_usuario");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Menu_Mobile", b =>
                {
                    b.HasOne("minimallAPI_rest.modelos.Categoria", "categoria")
                        .WithMany("menus_Mobile_categoria")
                        .HasForeignKey("id_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Menu_Pedido_Mobile", b =>
                {
                    b.HasOne("minimallAPI_rest.modelos.Menu_Mobile", "menu_mobile")
                        .WithMany("pedido_Menus")
                        .HasForeignKey("id_menuMobile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.modelos.Pedido_Mobile", "pedido_mobile")
                        .WithMany("pedido_Menus")
                        .HasForeignKey("id_pedido_mobile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("menu_mobile");

                    b.Navigation("pedido_mobile");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Pedido_Menu", b =>
                {
                    b.HasOne("minimallAPI_rest.Properties.modelos.Menu", "menu")
                        .WithMany("pedido_Menus")
                        .HasForeignKey("ID_MENU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.Properties.modelos.Pedido", "pedidoss")
                        .WithMany("pedido_MenuS_pedidos")
                        .HasForeignKey("pedido_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("menu");

                    b.Navigation("pedidoss");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Pedido_Mobile", b =>
                {
                    b.HasOne("minimallAPI_rest.modelos.Estado_Pedido", "Estado_Pedido")
                        .WithMany("pedido_mobile")
                        .HasForeignKey("id_estado_pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.modelos.Metodo_Busqueda", "Metodo_Busqueda")
                        .WithMany("pedido_mobile")
                        .HasForeignKey("id_metodo_busqueda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.Properties.modelos.Metodo_Pago", "metodo_pago")
                        .WithMany("pedido_mobile")
                        .HasForeignKey("id_metodo_pago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.Properties.modelos.Usuario", "usuario")
                        .WithMany("pedido_mobile")
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado_Pedido");

                    b.Navigation("Metodo_Busqueda");

                    b.Navigation("metodo_pago");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Factura", b =>
                {
                    b.HasOne("minimallAPI_rest.Properties.modelos.Pedido", "pedido")
                        .WithOne("factura")
                        .HasForeignKey("minimallAPI_rest.Properties.modelos.Factura", "pedidoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Menu", b =>
                {
                    b.HasOne("minimallAPI_rest.modelos.Categoria", "categoria")
                        .WithMany("menus_categoria")
                        .HasForeignKey("idcategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Pedido", b =>
                {
                    b.HasOne("minimallAPI_rest.modelos.Cliente", "cliente")
                        .WithMany("pedidos")
                        .HasForeignKey("id_dni_cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.Properties.modelos.Mesa", "mesa_pedido")
                        .WithMany("pedido_mesa")
                        .HasForeignKey("id_mesaa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("minimallAPI_rest.Properties.modelos.Metodo_Pago", "metodo")
                        .WithMany("pedidos_metodos_pago")
                        .HasForeignKey("metodo_pago_pedido");

                    b.Navigation("cliente");

                    b.Navigation("mesa_pedido");

                    b.Navigation("metodo");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Reserva", b =>
                {
                    b.HasOne("minimallAPI_rest.Properties.modelos.Usuario", "usuario")
                        .WithMany("reservas")
                        .HasForeignKey("ID_usuario");

                    b.HasOne("minimallAPI_rest.Properties.modelos.Mesa", "MESA")
                        .WithMany("reservas_mesas")
                        .HasForeignKey("id_MESA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MESA");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Categoria", b =>
                {
                    b.Navigation("menus_Mobile_categoria");

                    b.Navigation("menus_categoria");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Cliente", b =>
                {
                    b.Navigation("pedidos");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Estado_Pedido", b =>
                {
                    b.Navigation("pedido_mobile");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Menu_Mobile", b =>
                {
                    b.Navigation("pedido_Menus");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Metodo_Busqueda", b =>
                {
                    b.Navigation("pedido_mobile");
                });

            modelBuilder.Entity("minimallAPI_rest.modelos.Pedido_Mobile", b =>
                {
                    b.Navigation("pedido_Menus");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Menu", b =>
                {
                    b.Navigation("pedido_Menus");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Mesa", b =>
                {
                    b.Navigation("pedido_mesa");

                    b.Navigation("reservas_mesas");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Metodo_Pago", b =>
                {
                    b.Navigation("pedido_mobile");

                    b.Navigation("pedidos_metodos_pago");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Pedido", b =>
                {
                    b.Navigation("factura")
                        .IsRequired();

                    b.Navigation("pedido_MenuS_pedidos");
                });

            modelBuilder.Entity("minimallAPI_rest.Properties.modelos.Usuario", b =>
                {
                    b.Navigation("pedido_mobile");

                    b.Navigation("reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
