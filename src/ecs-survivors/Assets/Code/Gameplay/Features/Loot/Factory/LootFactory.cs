using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Factory
{
    public class LootFactory : ILootFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public LootFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateLootItem(LootTypeId lootTypeId, Vector3 at)
        {
            LootConfig config = _staticDataService.GetLootConfig(lootTypeId);

            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddLootTypeId(lootTypeId)
                    .AddViewPrefab(config.viewPrefab)
                    .With(x => x.AddExperience(config.experience), when: config.experience > 0)
                    .With(x => x.AddEffectSetups(config.effectSetups), when: !config.effectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(config.statusSetups), when: !config.statusSetups.IsNullOrEmpty())
                    .With(x => x.isPullable = true)
                ;
        }
    }
}