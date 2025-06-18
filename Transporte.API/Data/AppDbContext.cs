using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransporteModelos;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    public DbSet<TransporteModelos.Camion> Camiones { get; set; } = default!;

public DbSet<TransporteModelos.Conductor> Conductores { get; set; } = default!;

public DbSet<TransporteModelos.Mantenimiento> Mantenimientos { get; set; } = default!;

public DbSet<TransporteModelos.Taller> Talleres { get; set; } = default!;
    }
