namespace Webapi.Persistance.Repositories;

public interface IWareHouseRepository
{
    void Add(Warehouse house);
    void Remove(Warehouse house);

    void Update(Warehouse house);

    Task<Warehouse?> Get(int id);

    Task<IEnumerable<Warehouse>> Getall();
}

public class WarehouseRepository : IWareHouseRepository
{
    private readonly AppDbContext _context;

    public WarehouseRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(Warehouse house)
    {
        _context.Warehouses.Add(house);
    }

    public async Task<Warehouse?> Get(int id)
    {
        return await _context.Warehouses
        .AsQueryable()
        .Where(w => w.Id == id)
        .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Warehouse>> Getall()
    {
        return await _context.Warehouses.AsQueryable().ToListAsync();
    }

    public void Remove(Warehouse house)
    {
        _context.Warehouses.Remove(house);
    }

    public void Update(Warehouse house)
    {
        _context.Warehouses.Update(house);
    }
}

