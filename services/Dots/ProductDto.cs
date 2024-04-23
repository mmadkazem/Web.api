using System.ComponentModel.DataAnnotations;

namespace Webapi.services.Dots;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public DateTime Expire { get; set; }
    public required string Code { get; set; }
    [Required]
    public int Inventory { get; set; }

    [Required]
    public int WarehouseId { get; set; }
}