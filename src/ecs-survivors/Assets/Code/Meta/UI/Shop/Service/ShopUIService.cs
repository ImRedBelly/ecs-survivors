using System;
using System.Collections.Generic;
using Code.Gameplay.StaticData;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Service
{
    public class ShopUIService : IShopUIService
    {
        public event Action ShopChanged;

        private readonly IStaticDataService _staticDataService;
        private readonly List<ShopItemId> _purchasedItems = new();
        private readonly Dictionary<ShopItemId, ShopItemConfig> _availableItems = new();

        public ShopUIService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public List<ShopItemConfig> GetAvailableShopItems()
        {
            return new List<ShopItemConfig>(_availableItems.Values);
        }

        public void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems)
        {
            _purchasedItems.AddRange(purchasedItems);
            RefreshAvailableItems();
        }

        public void UpdatePurchasedItem(ShopItemId shopItemId)
        {
            _availableItems.Remove(shopItemId);
            _purchasedItems.Add(shopItemId);
            ShopChanged?.Invoke();
        }

        public void Cleanup()
        {
            _purchasedItems.Clear();
            _availableItems.Clear();
            ShopChanged = null;
        }

        public ShopItemConfig GetConfig(ShopItemId shopItemId)
        {
            return _availableItems.GetValueOrDefault(shopItemId);
        }

        private void RefreshAvailableItems()
        {
            foreach (var shopItemConfig in _staticDataService.GetShopItemConfigs())
            {
                if (!_purchasedItems.Contains(shopItemConfig.ShopItemId))
                {
                    _availableItems.Add(shopItemConfig.ShopItemId, shopItemConfig);
                }
            }

            ShopChanged?.Invoke();
        }
    }
}