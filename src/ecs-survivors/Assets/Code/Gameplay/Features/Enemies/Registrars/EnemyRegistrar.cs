using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float maxHp = 3f;
        public float damage = 1f;
        public float speed = 1f;

        public override void RegisterComponent()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddSpeed(speed)
                .AddDirection(Vector2.zero)
                .AddCurrentHp(maxHp)
                .AddMaxHp(maxHp)
                .AddDamage(damage)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(0.3f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }

        public override void UnregisterComponent()
        {
        }
    }
}