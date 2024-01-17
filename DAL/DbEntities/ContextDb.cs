using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class ContextDb : DbContext
    {
        public ContextDb()
            : base("name=ContextDb")
        {
        }

        public virtual DbSet<EVENTO> EVENTO { get; set; }
        public virtual DbSet<EVENTO_PROVEEDOR_SERVICIO> EVENTO_PROVEEDOR_SERVICIO { get; set; }
        public virtual DbSet<FECHA_RESERVADA> FECHA_RESERVADA { get; set; }
        public virtual DbSet<INVITADO> INVITADO { get; set; }
        public virtual DbSet<ORGANIZADOR> ORGANIZADOR { get; set; }
        public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public virtual DbSet<PROVINCIA> PROVINCIA { get; set; }
        public virtual DbSet<SERVICIO> SERVICIO { get; set; }
        public virtual DbSet<SERVICIO_PUBLICADO> SERVICIO_PUBLICADO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EVENTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<EVENTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<EVENTO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<EVENTO>()
                .HasMany(e => e.EVENTO_PROVEEDOR_SERVICIO)
                .WithRequired(e => e.EVENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EVENTO>()
                .HasMany(e => e.INVITADO)
                .WithRequired(e => e.EVENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EVENTO_PROVEEDOR_SERVICIO>()
                .Property(e => e.PRECIO_UNITARIO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<EVENTO_PROVEEDOR_SERVICIO>()
                .Property(e => e.MONTO_TOTAL)
                .HasPrecision(8, 2);

            modelBuilder.Entity<INVITADO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<INVITADO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<INVITADO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZADOR>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZADOR>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZADOR>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZADOR>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZADOR>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZADOR>()
                .HasMany(e => e.EVENTO)
                .WithRequired(e => e.ORGANIZADOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.PUNTAJE)
                .HasPrecision(4, 2);

            modelBuilder.Entity<PROVEEDOR>()
                .HasMany(e => e.EVENTO_PROVEEDOR_SERVICIO)
                .WithRequired(e => e.PROVEEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVEEDOR>()
                .HasMany(e => e.SERVICIO_PUBLICADO)
                .WithRequired(e => e.PROVEEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVINCIA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCIA>()
                .HasMany(e => e.ORGANIZADOR)
                .WithRequired(e => e.PROVINCIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVINCIA>()
                .HasMany(e => e.PROVEEDOR)
                .WithRequired(e => e.PROVINCIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICIO>()
                .Property(e => e.CATEGORIA)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICIO>()
                .HasMany(e => e.EVENTO_PROVEEDOR_SERVICIO)
                .WithRequired(e => e.SERVICIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICIO>()
                .HasMany(e => e.SERVICIO_PUBLICADO)
                .WithRequired(e => e.SERVICIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICIO_PUBLICADO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICIO_PUBLICADO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICIO_PUBLICADO>()
                .Property(e => e.PRECIO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SERVICIO_PUBLICADO>()
                .HasMany(e => e.FECHA_RESERVADA)
                .WithRequired(e => e.SERVICIO_PUBLICADO)
                .WillCascadeOnDelete(false);
        }
    }
}
