using Code.Common.Entity;
using Code.Meta.UI.Shop.Service;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public sealed class BuyItemOnRequestSystem : IExecuteSystem
    {
        private readonly IShopUIService _shopUIService;
        private readonly IGroup<MetaEntity> _storages;
        private readonly IGroup<MetaEntity> _shopItemPurchaseRequests;

        public BuyItemOnRequestSystem(MetaContext metaContext, IShopUIService shopUIService)
        {
            _shopUIService = shopUIService;
            _storages = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold));

            _shopItemPurchaseRequests = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.BuyRequest,
                MetaMatcher.ShopItemId));
        }

        public void Execute()
        {
            foreach (var storage in _storages)
            foreach (var purchaseRequest in _shopItemPurchaseRequests)
            {
                var config = _shopUIService.GetConfig(purchaseRequest.ShopItemId);

                if (storage.Gold >= config.Price)
                {
                    storage.ReplaceGold(storage.Gold - config.Price);
                    CreateMetaEntity.Empty()
                        .AddShopItemId(purchaseRequest.ShopItemId)
                        .isPurchased = true;

                    _shopUIService.UpdatePurchasedItem(purchaseRequest.ShopItemId);
                }

                purchaseRequest.isDestructed = true;
            }
        }
    }
}