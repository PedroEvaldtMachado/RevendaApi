#pragma warning disable RMG012 // Source member was not found for target member
#pragma warning disable RMG020 // Source member is not mapped to any target member

using RevendaApi.Dtos.Revendas;
using RevendaApi.Models.Revendas;
using Riok.Mapperly.Abstractions;

namespace RevendaApi.Profiles
{
    [Mapper(UseDeepCloning = true)]
    public static partial class RevendaMapper
    {
        public static partial RevendaReadDto ToDto(this Revenda dto);
        public static partial Revenda ToEntity(this RevendaCreateDto dto);
        public static partial Revenda ToEntity(this RevendaUpdateDto dto);
        public static partial void CopyTo(this RevendaUpdateDto dto, Revenda revenda);
    }
}
