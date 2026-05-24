using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades;

    public class SmartBikeAPIContext : DbContext
    {
        public SmartBikeAPIContext (DbContextOptions<SmartBikeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SmartBike.Entidades.Usuario> Usuarios { get; set; } = default!;

public DbSet<SmartBike.Entidades.TipoUsuario> TipoUsuarios { get; set; } = default!;

public DbSet<SmartBike.Entidades.TipoTransporte> TipoTransportes { get; set; } = default!;

public DbSet<SmartBike.Entidades.RegistroDiario> RegistroDiarios { get; set; } = default!;

public DbSet<SmartBike.Entidades.Reporte> Reportes { get; set; } = default!;

public DbSet<SmartBike.Entidades.Historial> Historiales { get; set; } = default!;

public DbSet<SmartBike.Entidades.Camara> Camaras { get; set; } = default!;

public DbSet<SmartBike.Entidades.ConteoCamara> ConteoCamaras { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Evitar ciclo en la tabla Camaras con Usuario
        modelBuilder.Entity<Camara>(entity =>
        {
            entity.HasOne(d => d.Usuario)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // 2. Evitar ciclos de cascada en la tabla RegistroDiario con Camara y TipoTransporte
        modelBuilder.Entity<RegistroDiario>(entity =>
        {
            entity.Property(e => e.Co2Generado)
                .HasPrecision(18, 4);

            entity.HasOne(d => d.Camara)
                .WithMany()
                .HasForeignKey(d => d.IdCamara)
                .OnDelete(DeleteBehavior.NoAction);

            // CORREGIDO: Rompe el segundo camino de cascada en RegistroDiario que causaba el error de la consola
            entity.HasOne(d => d.TipoTransporte)
                .WithMany()
                .HasForeignKey(d => d.IdTipoTransporte)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // 3. Configurar precisión decimal para Historial
        modelBuilder.Entity<Historial>(entity =>
        {
            entity.Property(e => e.Co2Acumulado)
                .HasPrecision(18, 4);
        });

        // 4. Configurar precisión decimal para Reporte
        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.Property(e => e.TotalCo2)
                .HasPrecision(18, 4);
        });
    }
}
