using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace DataBaseConnection;
public class ApplicationContext : DbContext
{
    public DbSet<Obss> weatherobservations { get; set; } = null!;

    public string connectionString;
    public ApplicationContext(string connectionString)
    {
        this.connectionString = connectionString;
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }   //"Host=localhost;Port=5432;Database=weatherobs;Username=postgres;Password=dkflfnjg"
    //"Host=localhost;Port=5432;Database=weatherobs;Username=postgres;Password=dkflfnjg"
}