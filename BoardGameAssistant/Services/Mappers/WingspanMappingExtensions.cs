using Riok.Mapperly.Abstractions;

namespace BoardGameAssistant.Services.Mappers
{
    [Mapper]
    public static partial class WingspanMappingExtensions
    {
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.CreatedAt))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.CreatedBy))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.UpdatedAt))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.UpdatedBy))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.Game))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.GameId))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanPlayerState.Id))]
        public static partial ServiceContracts.Wingspan.Dto.WingspanPlayerScore ToContract(this Entities.Wingspan.WingspanPlayerState game);

        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanGame.CreatedAt))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanGame.CreatedBy))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanGame.UpdatedAt))]
        [MapperIgnoreSource(nameof(Entities.Wingspan.WingspanGame.UpdatedBy))]
        [MapProperty(nameof(Entities.Wingspan.WingspanGame.Players), nameof(ServiceContracts.Wingspan.Dto.WingspanGame.PlayerScores))]
        public static partial ServiceContracts.Wingspan.Dto.WingspanGame ToContract(this Entities.Wingspan.WingspanGame game);


        public static partial IQueryable<ServiceContracts.Wingspan.Dto.WingspanGame> SelectContract(this IQueryable<Entities.Wingspan.WingspanGame> gameQueryable);
    }
}
