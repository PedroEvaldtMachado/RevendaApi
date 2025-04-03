#pragma warning disable RMG012 // Source member was not found for target member
#pragma warning disable RMG020 // Source member is not mapped to any target member

using RevendaApi.Dtos.Clientes;
using RevendaApi.Models.Clientes;
using Riok.Mapperly.Abstractions;

namespace RevendaApi.Profiles
{
    [Mapper(UseDeepCloning = true)]
    public static partial class ClienteMapper
    {
        public static partial ClienteReadDto ToDto(this Cliente dto);
        public static partial Cliente ToEntity(this ClienteCreateDto dto);
        public static partial Cliente ToEntity(this ClienteUpdateDto dto);
        public static partial void CopyTo(this ClienteUpdateDto dto, Cliente revenda);
    }
}
