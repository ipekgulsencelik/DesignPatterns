namespace CQRS.CQRS.Results
{
    public class GetProductQueryResult
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductBrand { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public bool ProductStatus { get; set; }
    }
}
