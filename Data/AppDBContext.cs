using Microsoft.EntityFrameworkCore;
using reseñas.Models;

namespace reseñas.Data;

public class AppDBContext : DbContext
{

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Resena> Resenas { get; set; }
}