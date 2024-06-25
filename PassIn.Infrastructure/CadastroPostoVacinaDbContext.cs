using CadastroPostoVacina.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

public class CadastroPostoVacinaDbContext : DbContext
{
    public CadastroPostoVacinaDbContext()
    {
    }

    public CadastroPostoVacinaDbContext(DbContextOptions<CadastroPostoVacinaDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring
          (DbContextOptionsBuilder OptionsBuilder)
    {
        OptionsBuilder.UseSqlServer("Server=JUNIORS;DataBase=CadastroPostosVacinaDB;User Id=sa;Password=9878; TrustServerCertificate=True");
        base.OnConfiguring(OptionsBuilder);
    }

    public DbSet<PostoVacina> PostosVacina { get; set; }
    public DbSet<Vacina> Vacinas { get; set; }
    public DbSet<Lote> Lote { get; set; }
}

