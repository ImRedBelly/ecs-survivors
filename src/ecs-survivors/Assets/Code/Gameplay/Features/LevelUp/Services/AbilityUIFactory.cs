using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public class AbilityUIFactory : IAbilityUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private const string AbilityCardPrefabPath = "UI/Abilities/AbilityCard";

        public AbilityUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public AbilityCard CreateAbilityCard(Transform parent)
        {
            return _instantiator.InstantiatePrefabForComponent<AbilityCard>(_assetProvider.LoadAsset<AbilityCard>(AbilityCardPrefabPath), parent);
        }
    }
}