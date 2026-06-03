namespace Credit_Control.Server.Models
{
    public class ItemLine
    {
        public int Id { get; set; }
        public int LineIndex { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string LotNumber { get; set; } = string.Empty;
    }
}
