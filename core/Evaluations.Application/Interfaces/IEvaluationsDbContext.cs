using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Evaluations.Domain;

namespace Evaluations.Application.Interfaces {
    public interface IEvaluationsDbContext
    {
        DbSet<Evaluation> Evaluations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}