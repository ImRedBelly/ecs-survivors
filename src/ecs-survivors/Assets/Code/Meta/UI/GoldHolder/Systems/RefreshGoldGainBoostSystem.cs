using System.Collections.Generic;
using System.Linq;
using Code.Meta.UI.GoldHolder.Service;
using Entitas;

namespace Code.Meta.UI.GoldHolder.Systems
{
    public sealed class RefreshGoldGainBoostSystem : ReactiveSystem<MetaEntity>, IInitializeSystem
    {
        private readonly IStorageUIService _storageUIService;
        private readonly IGroup<MetaEntity> _boosters;
        private readonly List<MetaEntity> _boostersBuffer = new(4);

        public RefreshGoldGainBoostSystem(MetaContext metaContext,
            IStorageUIService storageUIService) : base(metaContext)
        {
            _boosters = metaContext.GetGroup(MetaMatcher.GoldGainBoost);
            _storageUIService = storageUIService;
        }

        public void Initialize()
        {
            UpdateGoldGainBoost(_boosters.GetEntities(_boostersBuffer));
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return context.CreateCollector(MetaMatcher.GoldGainBoost.AddedOrRemoved());
        }

        protected override bool Filter(MetaEntity entity)
        {
            return true;
        }

        protected override void Execute(List<MetaEntity> boosters)
        {
            UpdateGoldGainBoost(boosters);
        }

        private void UpdateGoldGainBoost(List<MetaEntity> boosters)
        {
            float goldGainBoost = 0f;
            foreach (var booster in boosters)
            {
                if (booster.hasGoldGainBoost)
                {
                    goldGainBoost += booster.GoldGainBoost;
                }
            }

            _storageUIService.UpdateGoldGainBoost(goldGainBoost);
        }
    }
}