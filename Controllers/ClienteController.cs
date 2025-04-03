using Microsoft.AspNetCore.Mvc;
using RevendaApi.Dtos.Clientes;
using RevendaApi.Dtos.Pedidos;
using RevendaApi.Querys;
using RevendaApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Controllers;

public class ClienteController : BaseController
{
    private readonly Lazy<IClienteQuery> _query;
    private readonly Lazy<IClienteService> _service;
    private readonly Lazy<IPedidoService> _perdidoService;
    private readonly Lazy<IPedidoQuery> _pedidoQuery;

    public ClienteController(Lazy<IClienteService> service, Lazy<IClienteQuery> query, Lazy<IPedidoService> perdidoService, Lazy<IPedidoQuery> pedidoQuery)
    {
        _service = service;
        _query = query;
        _perdidoService = perdidoService;
        _pedidoQuery = pedidoQuery;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteReadDto>>> GetAll()
    {
        var result = await _query.Value.GetAll();
        return result is null ? NoContent() : Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ClienteReadDto>> GetById(Guid id)
    {
        var result = await _query.Value.GetById(id);
        return result is null ? NoContent() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteReadDto>> Create([FromBody] ClienteCreateDto dto)
    {
        var result = await _service.Value.Create(dto);
        return result is null ? NoContent() : Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ClienteReadDto>> Update(Guid id, [FromBody] ClienteUpdateDto dto)
    {
        var result = await _service.Value.Update(id, dto);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var result = await _service.Value.Delete(id);
        return result ? NoContent() : NotFound();
    }

    [HttpGet("{id:guid}/Pedido")]
    public async Task<ActionResult<IEnumerable<PedidoReadDto>>> GetPedidos(Guid clienteId)
    {
        var result = await _pedidoQuery.Value.GetByClienteId(clienteId);
        return result is null ? NoContent() : Ok(result);
    }

    [HttpPost("{id:guid}/Pedido")]
    public async Task<ActionResult<PedidoReadDto>> CreatePedido(Guid clienteId, PedidoCreateDto pedidoCreateDto)
    { 
        var result = await _perdidoService.Value.CreateForCliente(clienteId, pedidoCreateDto);
        return result is null ? NoContent() : Ok(result);
    }
}
