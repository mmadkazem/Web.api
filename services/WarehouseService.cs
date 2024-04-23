using Webapi.Common;
using Webapi.Persistance;
using WebApi.services.Dots;

namespace WebApi.services;

public interface IWarehouseService
{
    Task<ResultDto> Add(WarehouseDto warehouse);
    Task<ResultDto> Update(WarehouseDto warehouse);
    Task<ResultDto> Delete(WarehouseDto warehouse);
    Task<ResultDto<Warehouse>> Get(int id);
    Task<ResultsDto<Warehouse>> GetAll();
}

public class WarehouseService : IWarehouseService
{
    private readonly IUnitOfWork _uow;

    public WarehouseService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ResultDto> Add(WarehouseDto model)
    {
        if (model is null)
        {
            return new ResultDto(){Message = "",IsSuccessFull = false};
        }

        Warehouse warehouse = new Warehouse()
        {
            Name = model.Name,
            Address = model.Address
        };

        _uow.WareHouses.Add(warehouse);
        await _uow.SaveChanges();

        return new ResultDto(){IsSuccessFull = true, Message = "Is warehouse added"};
    }

    public Task<ResultDto> Delete(WarehouseDto warehouse)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto<Warehouse>> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultsDto<Warehouse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto> Update(WarehouseDto warehouse)
    {
        throw new NotImplementedException();
    }
}