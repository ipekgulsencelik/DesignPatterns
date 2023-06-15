using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.DAL;

namespace CQRS.CQRS.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDQueryResult Handle(GetProductByIDQuery query)
        {
            var values = _context.Products.Find(query.ID);

            return new GetProductByIDQueryResult
            {
                ProductBrand = values.ProductBrand,
                Name = values.ProductName,
                ProductID = values.ProductID
            };
        }
    }
}
