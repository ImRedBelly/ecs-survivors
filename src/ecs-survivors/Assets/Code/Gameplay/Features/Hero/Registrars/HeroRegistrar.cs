using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        public float speed = 2f;
        public Vector2 direction = Vector2.zero;
        public HeroAnimator heroAnimator;
        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity.Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddSpeed(speed)
                .AddHeroAnimator(heroAnimator)
                .AddSpriteRenderer(heroAnimator.SpriteRenderer)
                .AddDirection(direction)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                ;
        }
    }
}