using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.LevelUp.Services;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class LevelUpWindow : BaseWindow
    {
        [SerializeField] private Transform abilityLayout;

        private IAbilityUIFactory _abilityUIFactory;
        private IAbilityUpgradeService _abilityUpgradeService;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IAbilityUIFactory abilityUIFactory,
            IAbilityUpgradeService abilityUpgradeService,
            IStaticDataService staticDataService,
            IWindowService windowService)
        {
            Id = WindowId.LevelUpWindow;

            _abilityUIFactory = abilityUIFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            base.Initialize();
            foreach (AbilityUpgradeOption upgradeOption in _abilityUpgradeService.GetUpgradeOptions())
            {
                var abilityLevel = _staticDataService.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);

                _abilityUIFactory.CreateAbilityCard(abilityLayout)
                    .Setup(upgradeOption.Id, abilityLevel, OnSelected);
            }
        }

        private void OnSelected(AbilityId abilityId)
        {
            CreateEntity.Empty()
                .AddAbilityId(abilityId)
                .isUpgradeRequest = true;
            
            _windowService.Close(Id);
        }
    }
}