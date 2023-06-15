namespace CQRS.CQRS.Results
{
    public class GetProductUpdateQueryResult
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
    }
}
