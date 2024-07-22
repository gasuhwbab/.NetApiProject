using Microsoft.EntityFrameworkCore;
using Evaluations.Domain;
using Evaluations.Persistence.EntitytypeConfigurations;
using Evaluations.Application.Interfaces;

namespace Evaluations.Persistence;

public class EvaluationsDbContext : DbContext, IEvaluationsDbContext
{
    public DbSet<Evaluation> Evaluations{ get; set; }
    public EvaluationsDbContext(DbContextOptions<EvaluationsDbContext> option) 
        : base(option){}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EvaluationConfiguration());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
