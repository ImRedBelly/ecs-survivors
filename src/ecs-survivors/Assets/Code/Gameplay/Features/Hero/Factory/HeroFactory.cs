using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector2 at)
        {
            var baseStats = InitStats.EmptyStatsDictionary()
                    .With(x => x[Stats.Speed] = 2)
                    .With(x => x[Stats.MaxHp] = 100)
                ;
                
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddBaseStats(baseStats)
                    .AddStatsModifiers(InitStats.EmptyStatsDictionary())
                    .AddSpeed(baseStats[Stats.Speed])
                    .AddDirection(Vector2.zero)
                    .AddCurrentHp(baseStats[Stats.MaxHp])
                    .AddMaxHp(baseStats[Stats.MaxHp])
                    .AddExperience(0)
                    .AddPickupRadius(1)
                    .AddViewPath("Gameplay/Hero/hero")
                    .With(x => x.isHero = true)
                    .With(x => x.isTurnedAlongDirection = true)
                    .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}