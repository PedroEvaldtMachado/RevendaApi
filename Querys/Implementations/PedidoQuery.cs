using RevendaApi.Dtos.Pedidos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RevendaApi.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using RevendaApi.Infraestructure;

namespace RevendaApi.Querys.Implementations;

public class PedidoQuery : BaseQuery, IPedidoQuery
{
    public PedidoQuery(BaseQueryParams baseParams) : base(baseParams)
    {
    }

    public async Task<List<PedidoReadDto>> GetAll()
    { 
        var query =
            from pedido in DbContext.Value.Pedidos
                .Include(p => p.Itens)
            select pedido.ToDto();

        return await query.ToListAsync();
    }

    public async Task<PedidoReadDto> GetById(Guid id)
    {
        var query =
            from pedido in DbContext.Value.Pedidos
                .Include(p => p.Itens)
            where pedido.Id == id
            select pedido.ToDto();

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<PedidoReadDto>> GetByClienteId(Guid clienteId)
    {
        var query =
            from pedido in DbContext.Value.Pedidos
                .Include(p => p.Itens)
            where pedido.ClienteId == clienteId
            select pedido.ToDto();

        return await query.ToListAsync();
    }

    public async Task<List<PedidoReadDto>> GetByRevendaId(Guid revendaId)
    {
        var query =
            from pedido in DbContext.Value.Pedidos
                .Include(p => p.Itens)
            where pedido.RevendaId == revendaId
            select pedido.ToDto();

        return await query.ToListAsync();
    }

    public async Task<List<PedidoReadDto>> GetByRevendaIdAndStatus(Guid revendaId, IEnumerable<StatusPedidoItem> statusPedidoItem)
    {
        var query =
            from pedido in DbContext.Value.Pedidos
            where pedido.RevendaId == revendaId
                && pedido.Itens.Any(i => statusPedidoItem.Contains(i.StatusPedidoItem))
            select new PedidoReadDto
            {
                Id = pedido.Id,
                RevendaId = pedido.RevendaId,
                ClienteId = pedido.ClienteId,
                Itens = (
                    from i in pedido.Itens
                    where statusPedidoItem.Contains(i.StatusPedidoItem)
                    select new PedidoItemReadDto
                    {
                        Id = i.Id,
                        PedidoId = i.PedidoId,
                        ItemEstoqueId = i.ItemEstoqueId,
                        Quantidade = i.Quantidade,
                        ValorUnitario = i.ValorUnitario,
                        ValorDesconto = i.ValorDesconto,
                        ValorTotal = i.ValorTotal,
                        StatusPedidoItem = i.StatusPedidoItem
                    }).ToList()
            };

        return await query.ToListAsync();
    }
}
