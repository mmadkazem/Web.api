using Webapi.Persistance.Repositories;

namespace Webapi.Persistance;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IWareHouseRepository WareHouses { get; }

    Task SaveChanges();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context,
        IProductRepository products,
        IOrderRepository orders,
        IWareHouseRepository wareHouses)
    {
        _context = context;
        _products = products;
        _orders = orders;
        _wareHouses = wareHouses;
    }

    private readonly IProductRepository _products;
    public IProductRepository Products
        => _products;

    private readonly IOrderRepository _orders;
    public IOrderRepository Orders
        => _orders;

    private readonly IWareHouseRepository _wareHouses;
    public IWareHouseRepository WareHouses
        => _wareHouses;

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}