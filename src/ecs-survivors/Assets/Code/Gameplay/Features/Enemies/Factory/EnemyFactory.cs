using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
        {
            switch (typeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
            }

            throw new Exception($"");
        }

        private GameEntity CreateGoblin(Vector3 at)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddEnemyTypeId(EnemyTypeId.Goblin)
                    .AddWorldPosition(at)
                    .AddSpeed(1)
                    .AddDirection(Vector3.zero)
                    .AddCurrentHp(3)
                    .AddMaxHp(3)
                    .AddEffectSetups(new List<EffectSetup> { new() { effectTypeId = EffectTypeId.Damage, value = 1 } })
                    .AddTargetsBuffer(new List<int>(1))
                    .AddRadius(0.3f)
                    .AddCollectTargetsInterval(0.5f)
                    .AddCollectTargetsTimer(0)
                    .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .With(x => x.isEnemy = true)
                    .With(x => x.isTurnedAlongDirection = true)
                    .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}