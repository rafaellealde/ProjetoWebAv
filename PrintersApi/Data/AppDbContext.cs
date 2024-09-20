using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext 
{
    public DbSet<Printer> Printers { get; set; }
    public DbSet<Tonner> Tonners { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        string conn = "server=localhost;port=3306;database=projeto;" +
                      "user=root;password=positivo";

        builder.UseMySQL(conn);
    }
}