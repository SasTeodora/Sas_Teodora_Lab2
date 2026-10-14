using Microsoft.EntityFrameworkCore;

public class Sas_Teodora_Lab2Context(DbContextOptions<Sas_Teodora_Lab2Context> options) : DbContext(options)
{
    public DbSet<Sas_Teodora_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Sas_Teodora_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Sas_Teodora_Lab2.Models.Authors> Authors { get; set; } = default!;
}
