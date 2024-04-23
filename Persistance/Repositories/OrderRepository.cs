namespace Webapi.Persistance.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    void Update(Order order);
    void Delete(Order order);
    Task<Order?> Get(int id);
    Task<IEnumerable<Order>> GetAll();

}
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task<Order?> Get(int id)
    {
        return await _context.Orders
        .AsQueryable()
        .Where(o => o.Id == id)
        .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _context.Orders.AsQueryable().ToListAsync();
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }
}
