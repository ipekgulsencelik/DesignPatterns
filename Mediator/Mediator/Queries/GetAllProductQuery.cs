using Mediator.Mediator.Results;
using MediatR;

namespace Mediator.Mediator.Queries
{
    public class GetAllProductQuery : IRequest<List<GetAllProductQueryResult>>
    {
    }
}
