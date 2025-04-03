#pragma warning disable RMG012 // Source member was not found for target member
#pragma warning disable RMG020 // Source member is not mapped to any target member

using RevendaApi.Dtos.Pedidos;
using RevendaApi.Models.Pedidos;
using Riok.Mapperly.Abstractions;

namespace RevendaApi.Profiles
{
    [Mapper(UseDeepCloning = true)]
    public static partial class PedidoMapper
    {
        public static partial PedidoReadDto ToDto(this Pedido ent);
        public static partial Pedido ToEntity(this PedidoCreateDto dto);
        public static partial Pedido ToEntity(this PedidoUpdateDto dto);
        public static partial void CopyTo(this PedidoUpdateDto dto, Pedido revenda);
    }
}
