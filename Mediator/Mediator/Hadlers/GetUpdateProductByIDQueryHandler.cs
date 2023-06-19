using Mediator.DAL;
using Mediator.Mediator.Queries;
using Mediator.Mediator.Results;
using MediatR;

namespace Mediator.Mediator.Hadlers
{
    public class GetUpdateProductByIDQueryHandler : IRequestHandler<GetUpdateProductByIDQuery, GetUpdateProductByIDQueryResult>
    {
        private readonly Context _context;

        public GetUpdateProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetUpdateProductByIDQueryResult> Handle(GetUpdateProductByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
        
            return new GetUpdateProductByIDQueryResult
            {
                ProductID = values.ProductID,
                ProductCategory = values.ProductCategory,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductStock = values.ProductStock
            };
        }
    }
}