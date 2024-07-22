using Evaluations.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evaluations.Persistence.EntitytypeConfigurations{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder) {
            builder.HasKey(evaluation => evaluation.Id);
            builder.HasIndex(evaluation => evaluation.Id).IsUnique();
            builder.ToTable(evaluation => evaluation
                .HasCheckConstraint("ValidValue", "Value <= 5 AND Value > 0"));
        }
    }
}
