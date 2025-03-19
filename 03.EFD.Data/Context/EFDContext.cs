using EFD.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFD.Data.Context; 

public class EFDContext : DbContext
{
    public EFDContext(DbContextOptions<EFDContext> options) : base(options)
    {

    }

    public DbSet<ArquivoReinf> Estudantes { get; set; }
}
