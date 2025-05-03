using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public sealed class CalculateGoldGainSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<MetaEntity> _storages;
        private readonly IGroup<MetaEntity> _boosters;

        public CalculateGoldGainSystem(MetaContext metaContext, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _storages = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.GoldPerSeconds));

            _boosters = metaContext.GetGroup(MetaMatcher.GoldGainBoost);
        }

        public void Execute()
        {
            foreach (var storage in _storages)
            {
                float gainBonus = 1;
                foreach (var booster in _boosters)
                {
                    gainBonus += booster.GoldGainBoost;
                }

                storage.ReplaceGoldPerSeconds(_staticDataService.AfkGainConfig.goldPerSeconds * gainBonus);
            }
        }
    }
}