using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        public float maxHp = 100f;
        public float speed = 2f;
       
        public override void RegisterComponent()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddSpeed(speed)
                .AddDirection(Vector2.zero)
                .AddCurrentHp(maxHp)
                .AddMaxHp(maxHp)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                ;
        }
    
        public override void UnregisterComponent()
        {
        }
    }
}