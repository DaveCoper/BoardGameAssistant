using Riok.Mapperly.Abstractions;

namespace BoardGameAssistant.Services.Mappers
{
    [Mapper]
    public static partial class ScytheMappingExtensions
    {
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.CreatedAt))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.CreatedBy))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.UpdatedAt))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.UpdatedBy))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.Game))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.GameId))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScythePlayerState.Id))]
        public static partial ServiceContracts.Scythe.Dto.ScythePlayerScore ToContract(this Entities.Scythe.ScythePlayerState game);

        [MapperIgnoreSource(nameof(Entities.Scythe.ScytheGame.CreatedAt))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScytheGame.CreatedBy))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScytheGame.UpdatedAt))]
        [MapperIgnoreSource(nameof(Entities.Scythe.ScytheGame.UpdatedBy))]
        [MapProperty(nameof(Entities.Scythe.ScytheGame.Players), nameof(ServiceContracts.Scythe.Dto.ScytheGame.PlayerScores))]
        public static partial ServiceContracts.Scythe.Dto.ScytheGame ToContract(this Entities.Scythe.ScytheGame game);


        public static partial IQueryable<ServiceContracts.Scythe.Dto.ScytheGame> SelectContract(this IQueryable<Entities.Scythe.ScytheGame> gameQueryable);
    }
}
