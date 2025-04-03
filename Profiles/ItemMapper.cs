#pragma warning disable RMG012 // Source member was not found for target member
#pragma warning disable RMG020 // Source member is not mapped to any target member

using RevendaApi.Dtos.Itens;
using RevendaApi.Models.Items;
using Riok.Mapperly.Abstractions;

namespace RevendaApi.Profiles
{
    [Mapper(UseDeepCloning = true)]
    public static partial class ItemMapper
    {
        public static partial ItemReadDto ToDto(this Item item);
        public static partial Item ToEntity(this ItemCreateDto itemCreateDto);
    }
}
