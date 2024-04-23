namespace Webapi.Entites;

public class Product
{
    public int Id { get; set; }
    public required string  Name { get; set; }
    public decimal Price { get; set; }
    public DateTime Expire { get; set; }
    public required string Code { get; set; }
    public int Count { get; set; }
    // Rel
    public required Warehouse Warehouse{ get; set; }
    public int WarehouseId { get; set; }
}