using AutoMapper;
using Evaluations.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evaluations.Application.Evaluations.Queries.GetUserEvaluations;

public class GetUserEvaluationsHandler 
    : IRequestHandler<GetUserEvaluationsQuery, ICollection<UserEvaluationsVm>>
{
    private readonly IEvaluationsDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetUserEvaluationsHandler(IEvaluationsDbContext dbContext, 
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ICollection<UserEvaluationsVm>> 
        Handle(GetUserEvaluationsQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Evaluations
            .Where(evaluation => evaluation.UserId == request.UserId);
        return await _mapper.ProjectTo<UserEvaluationsVm>(query).ToArrayAsync(cancellationToken);
    }
}
