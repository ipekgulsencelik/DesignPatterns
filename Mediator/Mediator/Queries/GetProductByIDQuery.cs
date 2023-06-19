using Mediator.Mediator.Results;
using MediatR;

namespace Mediator.Mediator.Queries
{
    public class GetProductByIDQuery : IRequest<GetProductByIDQueryResult>
    {
        public GetProductByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
