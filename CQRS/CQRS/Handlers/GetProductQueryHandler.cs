using CQRS.CQRS.Results;
using CQRS.DAL;

namespace CQRS.CQRS.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductQueryResult
            {
                ProductID = x.ProductID,
                ProductBrand = x.ProductBrand,
                Price = x.ProductPrice,
                Name = x.ProductName,
                ProductStock = x.ProductStock,
                ProductStatus = x.ProductStatus
            }).ToList();

            return values;
        }
    }
}
