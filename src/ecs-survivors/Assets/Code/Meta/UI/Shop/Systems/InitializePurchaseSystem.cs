using System.Linq;
using Code.Meta.UI.Shop.Service;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public sealed class InitializePurchaseSystem : IInitializeSystem
    {
        private readonly IShopUIService _shopUIService;
        private readonly IGroup<MetaEntity> _purchaseItems;

        public InitializePurchaseSystem(MetaContext metaContext, IShopUIService shopUIService)
        {
            _shopUIService = shopUIService;
            _purchaseItems = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Purchased,
                MetaMatcher.ShopItemId));
        }

        public void Initialize()
        {
            _shopUIService.UpdatePurchasedItems(
                _purchaseItems.GetEntities()
                    .Select(x => x.ShopItemId));
        }
    }
}