using Evaluations.Application.Interfaces;
using Evaluations.Domain;
using Microsoft.EntityFrameworkCore;

namespace Evaluations.Persistence;

public class DbInitializer
{
    public static void Initialize(IEvaluationsDbContext context) 
    {
        var dbContext = context as EvaluationsDbContext;
        dbContext.Database.Migrate();
        if (!dbContext.Evaluations.Any())
        {
            dbContext.Evaluations.Add(new Evaluation 
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Value = 5
            });
            dbContext.Evaluations.Add(new Evaluation 
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Value = 4
            });
            dbContext.Evaluations.Add(new Evaluation 
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Value = 1
            });
            dbContext.SaveChangesAsync();
        }
    }
}
