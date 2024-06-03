﻿// <auto-generated />
using System;
using GestLab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestLab.Migrations
{
    [DbContext(typeof(GestLabContext))]
    partial class GestLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestLab.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("GestLab.Models.PedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ArmacaoEntreguePeloCliente")
                        .HasColumnType("bit");

                    b.Property<int?>("ArmacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CorLentes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificacaoArmacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LenteDireitaId")
                        .HasColumnType("int");

                    b.Property<int?>("LenteEsquerdaId")
                        .HasColumnType("int");

                    b.Property<int?>("MontadorResponsavelId")
                        .HasColumnType("int");

                    b.Property<bool>("PossuiLentesEmEstoque")
                        .HasColumnType("bit");

                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorPedido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ArmacaoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LenteDireitaId");

                    b.HasIndex("LenteEsquerdaId");

                    b.HasIndex("MontadorResponsavelId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("GestLab.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Utilizado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("GestLab.Models.ReceitaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Eixo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrauOlhoDireito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrauOlhoEsquerdo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("GestLab.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GestLab.Models.ClienteModel", b =>
                {
                    b.HasOne("GestLab.Models.UsuarioModel", "IdUsuario")
                        .WithMany()
                        .HasForeignKey("IdUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUsuario");
                });

            modelBuilder.Entity("GestLab.Models.PedidoModel", b =>
                {
                    b.HasOne("GestLab.Models.ProdutoModel", "Armacao")
                        .WithMany()
                        .HasForeignKey("ArmacaoId");

                    b.HasOne("GestLab.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestLab.Models.ProdutoModel", "LenteDireita")
                        .WithMany()
                        .HasForeignKey("LenteDireitaId");

                    b.HasOne("GestLab.Models.ProdutoModel", "LenteEsquerda")
                        .WithMany()
                        .HasForeignKey("LenteEsquerdaId");

                    b.HasOne("GestLab.Models.UsuarioModel", "MontadorResponsavel")
                        .WithMany()
                        .HasForeignKey("MontadorResponsavelId");

                    b.HasOne("GestLab.Models.ReceitaModel", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armacao");

                    b.Navigation("Cliente");

                    b.Navigation("LenteDireita");

                    b.Navigation("LenteEsquerda");

                    b.Navigation("MontadorResponsavel");

                    b.Navigation("Receita");
                });
#pragma warning restore 612, 618
        }
    }
}
