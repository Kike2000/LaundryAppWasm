namespace LaundryAppWasm.Server.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Type Type { get; set; }

    }
    public enum Type
    {
        Shirt,
        Pants,
        Dress
    }
}
