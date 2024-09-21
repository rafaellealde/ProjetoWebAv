using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext 
{
    public DbSet<Printer> Printers { get; set; }
    public DbSet<Tonner> Tonners { get; set; }
    public DbSet<Selb> Selbs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        string conn = "server=localhost;port=3306;database=projeto;" +
                      "user=root;password=";

        builder.UseMySQL(conn);
    }
}