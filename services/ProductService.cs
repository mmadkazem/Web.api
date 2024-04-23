using Webapi.Common;
using Webapi.Persistance;
using Webapi.Persistance.Repositories;
using Webapi.services.Dots;

namespace Webapi.services;

public interface IProductService
{
    Task<ResultDto> Add(ProductDto product);
    Task<ResultDto> Update(ProductDto product);
    Task<ResultDto> Delete(int id);
    Task<ResultDto<Product>> Get(int id);
    Task<ResultsDto<Product>> GetAll();

}
// Dto Return
public class ProductService : IProductService
{
    private readonly IUnitOfWork _uow;

    public ProductService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ResultDto> Add(ProductDto productDto)
    {
        if (productDto == null)
        {
            return new ResultDto { Message = "This Product not valid.", IsSuccessFull = false };
        }

        var warehouse = await _uow.WareHouses.Get(productDto.WarehouseId);
        if (warehouse == null)
        {
            return new ResultDto { Message = "This warehouse not Found.", IsSuccessFull = false };
        }

        var product = new Product()
        {
            Name = productDto.Name,
            Code = productDto.Code,
            Count = productDto.Inventory,
            Warehouse = warehouse,
            WarehouseId = productDto.WarehouseId,
        };
        _uow.Products.Add(product);
        await _uow.SaveChanges();

        return new ResultDto { Message = "This product added.", IsSuccessFull = true };
    }

    public async Task<ResultDto> Delete(int id)
    {
        var product = await _uow.Products.Find(id);
        if (product is null)
        {
            return new ResultDto { Message = "This product not Found.", IsSuccessFull = false };
        }
        _uow.Products.Delete(product);
        await _uow.SaveChanges();

        return new ResultDto { Message = "This product removed.", IsSuccessFull = true };
    }

    public async Task<ResultDto<Product>> Get(int id)
    {
        var product = await _uow.Products.Find(id);
        if (product is null)
        {
            return new ResultDto<Product> { Message = "This product not Found.", IsSuccessFull = false };
        }
        return new ResultDto<Product> { IsSuccessFull = true, Value = product };
    }

    public async Task<ResultsDto<Product>> GetAll()
    {
        var products = await _uow.Products.GetAll();
        if (products is null)
        {
            return new ResultsDto<Product> { Message = "This product not Found.", IsSuccessFull = false };
        }
        return new ResultsDto<Product> { IsSuccessFull = true, Value = products };
    }

    public async Task<ResultDto> Update(ProductDto productDto)
    {
        if (productDto == null)
        {
            return new ResultDto { Message = "This Product not valid.", IsSuccessFull = false };
        }

        var product = await _uow.Products.Find(productDto.Id);
        if (product == null)
        {
            return new ResultDto { Message = "This product not Found.", IsSuccessFull = false };
        }

        product.Name = productDto.Name;
        product.Code = productDto.Code;
        product.Count = productDto.Inventory;
        product.Expire = productDto.Expire;
        product.Price = productDto.Price;

        _uow.Products.Update(product);
        await _uow.SaveChanges();

        return new ResultDto { Message = "This product updated.", IsSuccessFull = true };
    }
}