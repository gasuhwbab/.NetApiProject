using Evaluations.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Evaluations.Application.Evaluations.Queries.GetProductEvaluation;

public class GetProductEvaluationQueryHandler 
    : IRequestHandler<GetProductEvaluationQuery, ICollection<ProductEvaluationVm>>
{
    private readonly IEvaluationsDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetProductEvaluationQueryHandler(IEvaluationsDbContext dbContext, 
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ICollection<ProductEvaluationVm>> Handle(GetProductEvaluationQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _dbContext.Evaluations
            .Where(evaluation => evaluation.ProductId == request.ProductId)
            .OrderBy(evaluation => evaluation.Value)
            .Skip((request.Page - 1)*request.PageSize)
            .Take(request.PageSize);
        return await _mapper.ProjectTo<ProductEvaluationVm>(query).ToArrayAsync(cancellationToken);
    }
}

