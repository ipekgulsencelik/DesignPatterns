using CQRS.CQRS.Commands;
using CQRS.DAL;

namespace CQRS.CQRS.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                ProductBrand = command.ProductBrand,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductStatus = true,
                ProductStock = command.ProductStock
            });

            _context.SaveChanges();
        }
    }
}
