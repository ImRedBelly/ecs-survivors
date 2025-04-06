using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
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

            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isArmament = true)
                    .AddViewPrefab(abilityLevel.viewPrefab)
                    .AddWorldPosition(at)
                    .AddSpeed(setup.speed)
                    .AddEffectSetups(abilityLevel.effectSetups)
                    .AddRadius(setup.contactRadius)
                    .AddTargetsBuffer(new List<int>(TargetBufferSize))
                    .AddProcessedTargets(new List<int>(TargetBufferSize))
                    .AddTargetLimit(setup.pierce)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .With(x => x.isMovementAvailable = true)
                    .With(x => x.isReadyToCollectTargets = true)
                    .With(x => x.isCollectingTargetsContinuously = true)
                     .With(x => x.isRotationAlignedAlongDirection = true)
                    .AddSelfDestructTimer(setup.lifetime)
                ;
        }
    }
}