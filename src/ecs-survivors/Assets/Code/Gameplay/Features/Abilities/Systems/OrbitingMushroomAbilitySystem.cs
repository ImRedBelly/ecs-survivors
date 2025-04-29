using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public sealed class OrbitingMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;

        private readonly List<GameEntity> _buffer = new(1);

        public OrbitingMushroomAbilitySystem(GameContext gameContext, IStaticDataService staticDataService,
            IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _abilities = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.OrbitingMushroomAbility, GameMatcher.CooldownUp));
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                foreach (var hero in _heroes)
                {
                    int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.OrbitingMushroom);

                    AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);

                    var projectileCount = abilityLevel.projectileSetup.projectileCount;

                    for (int i = 0; i < projectileCount; i++)
                    {
                        float phase = (2 * Mathf.PI * i) / projectileCount;

                        CreateProjectile(hero, phase, level: level);
                    }

                    ability.PutOnCooldown(abilityLevel.cooldown);
                }
            }
        }

        private void CreateProjectile(GameEntity hero, float phase, int level)
        {
            _armamentFactory.CreateOrbitingMushroom(level, hero.WorldPosition + Vector3.up, phase)
                    .AddProducerId(hero.Id)
                    .AddOrbitCenterPosition(hero.WorldPosition)
                    .AddOrbitCenterFollowTarget(hero.Id)
                    .isMoving = true
                ;
        }
    }
}