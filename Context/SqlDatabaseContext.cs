using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Entities;

namespace Context
{
    public class SqlDatabaseContext : DbContext
    {
        public SqlDatabaseContext(DbContextOptions<SqlDatabaseContext> options) : base(options)
        {

        }

        #region DB Sets Ejemplos
        //public DbSet<Mensaje> Mensaje { get; set; }
        //public DbSet<Equivalencia> Equivalencia { get; set; }
        //public DbSet<MapeoMensaje> MapeoMensaje { get; set; }
        //public DbSet<TipoMensaje> TipoMensaje { get; set; }
        //public DbSet<Nodo> Nodo { get; set; }
        //public DbSet<NodoTransformacion> NodoTransformacion { get; set; }
        //public DbSet<TipoDato> TipoDato { get; set; }
        //public DbSet<Transformacion> Transformacion { get; set; }
        #endregion

        #region Context Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ModelBuilder Ejemplo
            //modelBuilder.Entity<MapeoMensaje>()
            //    .HasOne(m => m.MensajeDestino)
            //    .WithMany(m => m.MensajesDestino)
            //    .HasForeignKey(m => m.MensajeDestinoId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<MapeoMensaje>()
            //    .HasOne(m => m.MensajeOrigen)
            //    .WithMany(m => m.MensajesOrigen)
            //    .HasForeignKey(m => m.MensajeOrigenId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<MapeoNodo>()
            //    .HasOne(m => m.NodoOrigen)
            //    .WithMany(m => m.NodosOrigen)
            //    .HasForeignKey(m => m.NodoIdOrigen)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<MapeoNodo>()
            //    .HasOne(m => m.NodoDestino)
            //    .WithMany(m => m.NodosDestino)
            //    .HasForeignKey(m => m.NodoIdDestino)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<EncabezadoMensajeDestinatario>()
            //     .HasOne(m => m.Destinatario)
            //     .WithMany(m => m.EncabezadosMensaje)
            //     .HasForeignKey(m => m.DestinatarioId)
            //     .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<EncabezadoMensajeDestinatario>()
            //    .HasOne(m => m.EncabezadoMensaje)
            //    .WithMany(m => m.Destinatarios)
            //    .HasForeignKey(m => m.EncabezadoMensajeId)
            //   .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Nodo>()
            //    .HasOne(m => m.NodoPadre)
            //    .WithMany(m => m.NodosHijos)
            //    .HasForeignKey(m => m.NodoPadreId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Nodo>()
            //    .HasOne(m => m.Mensaje)
            //    .WithMany(m => m.Nodos)
            //    .HasForeignKey(m => m.MensajeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<MapeoNodoTransformacion>()
            //    .HasKey(x => new { x.MapeoNodoId, x.NodoTransformacionId });

            //modelBuilder.Entity<TipoMensaje>()
            //    .HasData(new TipoMensaje
            //    {
            //        TipoMensajeId = (int)Constants.MessageTypes.JSON,
            //        Descripcion = "Json",
            //        FechaCreacion = DateTime.Today
            //    }, new TipoMensaje
            //    {
            //        TipoMensajeId = (int)Constants.MessageTypes.XML,
            //        Descripcion = "Xml",
            //        FechaCreacion = DateTime.Today
            //    });

            //modelBuilder.Entity<TipoEnvio>()
            //    .HasData(new TipoEnvio
            //    {
            //        TipoEnvioId = (int)Constants.SendType.REQUEST,
            //        Descripcion = "Request",
            //        FechaCreacion = DateTime.Today
            //    }, new TipoEnvio
            //    {
            //        TipoEnvioId = (int)Constants.SendType.RESPONSE,
            //        Descripcion = "Response",
            //        FechaCreacion = DateTime.Today
            //    });

            //modelBuilder.Entity<Agente>()
            //   .HasData(new Agente
            //   {
            //       AgenteId = (int)Constants.AgentTypes.LAUNCHERDUO,
            //       Descripcion = "LauncherDuo",
            //       FechaCreacion = DateTime.Today
            //   }, new Agente
            //   {
            //       AgenteId = (int)Constants.AgentTypes.ZATO,
            //       Descripcion = "Zato",
            //       FechaCreacion = DateTime.Today
            //   });

            //modelBuilder.Entity<TipoServicioDestino>()
            //   .HasData(new TipoServicioDestino
            //   {
            //       TipoServicioDestinoId = (int)Constants.TypeServiceDestination.SOAP,
            //       Descripcion = "Soap",
            //       FechaCreacion = DateTime.Today
            //   }, new TipoServicioDestino
            //   {
            //       TipoServicioDestinoId = (int)Constants.TypeServiceDestination.REST,
            //       Descripcion = "Rest",
            //       FechaCreacion = DateTime.Today
            //   });
            #endregion
        }
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(true, cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).FechaCreacion = now;
                }
                ((BaseEntity)entity.Entity).FechaActualizacion = now;
            }
        }
        #endregion
    }
}
