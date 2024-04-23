namespace Webapi.Persistance.Repositories;


public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    Task<Product?> Find(int id);
    Task<IEnumerable<Product>> GetAll();
}
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
    }

    public async Task<Product?> Find(int id)
    {
        // return _context.Products.Find(id);

        return await _context.Products
                .AsQueryable()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products
                .AsQueryable()
                .ToListAsync();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }
}