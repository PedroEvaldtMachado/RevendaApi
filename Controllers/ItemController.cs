using Microsoft.AspNetCore.Mvc;
using RevendaApi.Dtos.Itens;
using RevendaApi.Querys;
using RevendaApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Controllers;

public class ItemController : BaseController
{
    private readonly Lazy<IItemQuery> _query;
    private readonly Lazy<IItemService> _service;
         
    public ItemController(Lazy<IItemQuery> query, Lazy<IItemService> service)
    {
        _query = query;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemReadDto>>> GetAll()
    {
        var itens = await _query.Value.GetAll();
        return itens is null ? NoContent() : Ok(itens);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ItemReadDto>> GetById(Guid id)
    {
        var item = await _query.Value.GetById(id);
        return item is null ? NoContent() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ItemReadDto>> Create([FromBody] ItemCreateDto dto)
    {
        var item = await _service.Value.Create(dto);
        return item is null ? NoContent() : Ok(item);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var result = await _service.Value.Delete(id);
        return result ? NoContent() : NotFound();
    }
}
