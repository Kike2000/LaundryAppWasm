namespace LaundryAppWasm.Server.Models
{
    public class OrderTotal
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
    }
}
