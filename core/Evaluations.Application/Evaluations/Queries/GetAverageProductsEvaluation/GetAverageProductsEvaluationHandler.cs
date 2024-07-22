using AutoMapper;
using Evaluations.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evaluations.Application.Evaluations.Queries.GetAverageProductsEvaluation;

public class GetAverageProductsEvaluationHandler : 
    IRequestHandler<GetAverageProductsEvaluationQuery, ICollection<AverageProductEvaluationVm>>
{
    private readonly IEvaluationsDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAverageProductsEvaluationHandler(IEvaluationsDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ICollection<AverageProductEvaluationVm>> Handle(
        GetAverageProductsEvaluationQuery request, CancellationToken cancellationToken) 
    {
        return await _dbContext.Evaluations
            .GroupBy(evaluation => evaluation.ProductId, evaluation => evaluation.Value)
            .Select(group => new AverageProductEvaluationVm
            {
                ProductId = group.Key,
                AverageValue = group.Average(),
            })
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .OrderBy(prodEval => prodEval.AverageValue)
            .ToArrayAsync(cancellationToken);
    }
}
