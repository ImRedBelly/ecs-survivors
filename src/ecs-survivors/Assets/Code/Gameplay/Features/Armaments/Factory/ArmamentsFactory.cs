using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private const int TargetBufferSize = 16;

        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public ArmamentFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            ProjectileSetup setup = abilityLevel.projectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                    .AddParentAbility(AbilityId.VegetableBolt)
                    .With(x => x.isRotationAlignedAlongDirection = true)
                ;
        }


        public GameEntity CreateOrbitingMushroom(int level, Vector3 at, float phase)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            ProjectileSetup setup = abilityLevel.projectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                    .AddParentAbility(AbilityId.OrbitingMushroom)
                    .AddOrbitPhase(phase)
                    .AddOrbitRadius(setup.orbitalRadius)
                ;
        }

        public GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
            AuraSetup auraSetup = abilityLevel.auraSetup;

            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddParentAbility(parentAbilityId)
                    .AddViewPrefab(abilityLevel.viewPrefab)
                    .With(x => x.AddEffectSetups(abilityLevel.effectSetups), when: !abilityLevel.effectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(abilityLevel.statusSetups), when: !abilityLevel.statusSetups.IsNullOrEmpty())
                    .AddProducerId(producerId)
                    .AddTargetsBuffer(new List<int>(TargetBufferSize))
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .AddRadius(auraSetup.radius)
                    .AddCollectTargetsInterval(auraSetup.interval)
                    .AddCollectTargetsTimer(0)
                    .AddWorldPosition(Vector3.zero)
                    .With(x => x.isFollowingProduces = true)
                ;
        }

        private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.viewPrefab)
                .AddWorldPosition(at)
                .AddSpeed(setup.speed)
                .With(x => x.AddEffectSetups(abilityLevel.effectSetups), when: !abilityLevel.effectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.statusSetups), when: !abilityLevel.statusSetups.IsNullOrEmpty())
                .AddRadius(setup.contactRadius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargets(new List<int>(TargetBufferSize))
                .With(x => x.AddTargetLimit(setup.pierce), when: setup.pierce > 0)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .AddSelfDestructTimer(setup.lifetime);
        }

        public GameEntity CreateExplosive(int producerId, Vector3 at)
        {
            EnchantConfig config = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);

            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .AddRadius(config.radius)
                    .AddTargetsBuffer(new List<int>(TargetBufferSize))
                    .With(x => x.AddEffectSetups(config.effectSetups), when: !config.effectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(config.statusSetups), when: !config.statusSetups.IsNullOrEmpty())
                    .AddViewPrefab(config.viewPrefab)
                    .AddWorldPosition(at)
                    .AddProducerId(producerId)
                    .With(x => x.isReadyToCollectTargets = true)
                    .AddSelfDestructTimer(1)
                ;
        }
    }
}