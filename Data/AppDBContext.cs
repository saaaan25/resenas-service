using Microsoft.EntityFrameworkCore;
using reseñas.Models;

namespace reseñas.Data;

public class AppDBContext : DbContext
{

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Resenas> Resenas { get; set; }
}