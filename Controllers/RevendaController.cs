using Microsoft.AspNetCore.Mvc;
using RevendaApi.Dtos.Revendas;
using RevendaApi.Querys;
using RevendaApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Controllers;

public class RevendaController : BaseController
{
    private readonly Lazy<IRevendaQuery> _query;
    private readonly Lazy<IRevendaService> _service;

    public RevendaController(Lazy<IRevendaService> service, Lazy<IRevendaQuery> query)
    {
        _service = service;
        _query = query;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RevendaReadDto>>> GetAll()
    {
        var result = await _query.Value.GetAll();
        return result is null ? NoContent() : Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RevendaReadDto>> GetById(Guid id)
    {
        var result = await _query.Value.GetById(id);
        return result is null ? NoContent() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<RevendaReadDto>> Create(RevendaCreateDto dto)
    {
        var result = await _service.Value.Create(dto);
        return result is null ? NoContent() : CreatedAtAction(nameof(Create), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RevendaReadDto>> Update(Guid id, RevendaUpdateDto dto)
    {
        var result = await _service.Value.Update(id, dto);
        return result is null ? NoContent() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.Value.Delete(id);
        return result ? NoContent() : NotFound();
    }
}
