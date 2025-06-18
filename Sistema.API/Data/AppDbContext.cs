using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaModelos;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaModelos.Alerta> Alertas { get; set; } = default!;

public DbSet<SistemaModelos.Log> Logs { get; set; } = default!;

public DbSet<SistemaModelos.Sensor> Sensores { get; set; } = default!;
    }
