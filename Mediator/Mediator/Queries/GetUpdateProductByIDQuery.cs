using Mediator.Mediator.Results;
using MediatR;

namespace Mediator.Mediator.Queries
{
    public class GetUpdateProductByIDQuery : IRequest<GetUpdateProductByIDQueryResult>
    {
        public GetUpdateProductByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
