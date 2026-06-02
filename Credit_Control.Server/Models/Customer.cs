namespace Credit_Control.Server.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string CustomerCode { get; set; }
        public required string CustomerName { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string VatSchemeId { get; set; } = "NORMAL";
        public VatScheme VatScheme { get; set; } = null!;
        public string Doy { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AddressNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Prefecture { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PhoneNumberOne { get; set; } = string.Empty;
        public string PhoneNumberTwo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableCredit => CreditLimit - CurrentBalance;
        public bool IsCreditBlocked => CurrentBalance > CreditLimit;
        public List<Invoice> Invoices { get; set; } = [];

    }
}
