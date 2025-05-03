using Code.Infrastructure.AssetManagement;
using Code.Meta.UI.Shop.Items;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Shop.UIFactory
{
    public class ShopUIFactory : IShopUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public const string ShotItemPrefabPath = "UI/Home/Shop/ShopItem";

        public ShopUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public ShopItem CreateShopItem(ShopItemConfig config, Transform parent)
        {
            ShopItem shopItemPrefab = _assetProvider.LoadAsset<ShopItem>(ShotItemPrefabPath);
            var shopItem = _instantiator.InstantiatePrefabForComponent<ShopItem>(shopItemPrefab, parent);

            shopItem.Setup(config);

            return shopItem;
        }
    }
}