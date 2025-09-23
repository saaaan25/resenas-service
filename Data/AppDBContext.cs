using Microsoft.EntityFrameworkCore;

namespace catalogo.Data;

public class AppDBContext : DbContext
{

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }


    //Create DbSet for each model
    //Ex: public DbSet<Product> Products { get; set; }
}