using System.Collections.Generic;
using Code.Progress.SaveLoad;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public class ProcessBoughtItemsSystem : ReactiveSystem<MetaEntity>
    {
        private readonly IShopItemFactory _shopItemFactory;
        private readonly ISaveLoadService _saveLoadService;

        public ProcessBoughtItemsSystem(MetaContext metaContext,
            IShopItemFactory shopItemFactory, ISaveLoadService saveLoadService) :
            base(metaContext)
        {
            _shopItemFactory = shopItemFactory;
            _saveLoadService = saveLoadService;
        }


        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return context.CreateCollector(MetaMatcher.Purchased.Added());
        }

        protected override bool Filter(MetaEntity purchases)
        {
            return purchases.hasShopItemId;
        }

        protected override void Execute(List<MetaEntity> purchases)
        {
            foreach (var purchase in purchases)
            {
                _shopItemFactory.CreateShopItem(purchase.ShopItemId);
                _saveLoadService.SaveProgress();
            }
        }
    }
}