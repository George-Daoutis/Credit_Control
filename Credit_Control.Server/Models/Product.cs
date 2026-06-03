namespace Credit_Control.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string ProductCode { get; set; }
        public required string Description { get; set; }
        public decimal NetPrice { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string VatSchemeId { get; set; } = "NORMAL";
        public VatScheme VatScheme { get; set; } = null!;
        public decimal Stock { get; set; }
        public string LotNumber { get; set; } = string.Empty;
        public ICollection<ItemLine> ItemLines { get; set; } = new List<ItemLine>();
    }
}
