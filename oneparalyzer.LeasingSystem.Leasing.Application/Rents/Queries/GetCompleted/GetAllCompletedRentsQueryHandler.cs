using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

namespace oneparalyzer.LeasingSystem.Leasing.Application.Rents.Queries.GetCompleted;

public sealed class GetAllCompletedRentsQueryHandler : IRequestHandler<GetAllCompletedRentsQuery, ResultWithData<IEnumerable<GetAllCompletedRentsDto>>>
{
    public GetAllCompletedRentsQueryHandler()
    {
        
    }

    public Task<ResultWithData<IEnumerable<GetAllCompletedRentsDto>>> Handle(GetAllCompletedRentsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
