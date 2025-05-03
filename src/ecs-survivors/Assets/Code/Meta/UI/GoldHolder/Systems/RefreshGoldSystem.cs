using Code.Meta.UI.GoldHolder.Service;
using Entitas;

namespace Code.Meta.UI.GoldHolder.Systems
{
    public sealed class RefreshGoldSystem : IExecuteSystem
    {
        private readonly IStorageUIService _storageUIService;
        private readonly IGroup<MetaEntity> _storages;

        public RefreshGoldSystem(MetaContext metaContext, IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
            _storages = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold));
        }

        public void Execute()
        {
            foreach (var storage in _storages)
            {
                _storageUIService.UpdateCurrentGold(storage.Gold);
            }
        }
    }
}