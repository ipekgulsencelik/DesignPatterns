using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.DAL;

namespace CQRS.CQRS.Handlers
{
    public class GetProductUpdateByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductUpdateByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateQueryResult Handle(GetProductUpdateByIDQuery query)
        {
            var values = _context.Products.Find(query.ID);

            return new GetProductUpdateQueryResult
            {
                ProductBrand = values.ProductBrand,
                ProductID = values.ProductID,
                ProductName = values.ProductName, 
                ProductPrice = values.ProductPrice,
                ProductStatus = true,
                ProductStock = values.ProductStock
            };
        }
    }
}
