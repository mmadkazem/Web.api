using Webapi.Common;
using Webapi.Persistance;
using WebApi.services.Dots;

namespace WebApi.services;

public interface IOrderService
{
    Task<ResultDto> Add(OrderDto orderDto);
    Task<ResultDto> Update(OrderDto orderDto);
    Task<ResultDto> Delete(OrderDto orderDto);
    Task<ResultDto<Order>> Get(int id);
    Task<ResultsDto<Order>> GetAll();
}

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _uow;

    public OrderService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ResultDto> Add(OrderDto orderDto)
    {

        var warehouse = await _uow.WareHouses.Get(orderDto.WarehouseId);
        if (warehouse == null)
        {
            return new ResultDto { Message = "This warehouse not Found.", IsSuccessFull = false };
        }

        var product = await _uow.Products.Find(orderDto.ProductId);
        if (product is null)
        {
            return new ResultDto { Message = "This product not Found.", IsSuccessFull = false };
        }

        if (product.Count - orderDto.Count <= 0)
        {
            return new ResultDto { Message = "This amount is not in stock", IsSuccessFull = false };
        }
        product.Count = product.Count - orderDto.Count;

        var order = new Order()
        {
            Warehouse = warehouse,
            Count = orderDto.Count
        };
        _uow.Orders.Add(order);
        _uow.Products.Update(product);
        await _uow.SaveChanges();

        return new ResultDto { Message = "This order added.", IsSuccessFull = true };
    }

    public Task<ResultDto> Delete(OrderDto orderDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto<Order>> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultsDto<Order>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto> Update(OrderDto orderDto)
    {
        throw new NotImplementedException();
    }
}