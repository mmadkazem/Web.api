namespace Webapi.Entites;

public class Warehouse
{
    public int Id { get; set; }
    public required string Address { get; set; }
    public required string Name { get; set; }

    // Rel
    public ICollection<Product>? products{ get; set; }
}
