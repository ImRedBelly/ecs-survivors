using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.UIFactories
{
    public class EnchantUIFactory : IEnchantUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private const string EnchantPrefabPath = "UI/Enchants/Enchant";

        public EnchantUIFactory(
            IInstantiator instantiator,
            IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public Enchant CreateEnchant(EnchantTypeId enchantTypeId, Transform parent)
        {
            EnchantConfig config = _staticDataService.GetEnchantConfig(enchantTypeId);

            Enchant enchant = _instantiator.InstantiatePrefabForComponent<Enchant>
                (_assetProvider.LoadAsset<Enchant>(EnchantPrefabPath), parent);
            enchant.Set(config);

            return enchant;
        }
    }
}