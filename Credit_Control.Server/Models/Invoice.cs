namespace Credit_Control.Server.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public required int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string VatSchemeId { get; set; } = "NORMAL";
        public VatScheme VatScheme { get; set; } = null!;
        public InvoiceStatus InvoiceStatus { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalAmount => NetAmount + VatAmount;
        public decimal PaidAmount { get; set; }
        public ICollection<ItemLine> ItemLines { get; set; } = new List<ItemLine>();
    }

    public enum InvoiceStatus
    {
        Draft,
        NeedToAudit,
        Posted
    }
}
