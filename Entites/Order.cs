namespace Webapi.Entites;

public class Order
{
    public int Id { get; set; }
    public int Count { get; set; }

    // Rel
    public required Warehouse Warehouse{ get; set; }
    public int WarehouseId { get; set; }
}