namespace LaundryAppWasm.Server.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public Customer? Customer { get; set; }

    }
    public enum Status
    {
        Pending,
        InProgress,
        Completed
    }
}
