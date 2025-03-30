using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;

        public override void RegisterComponent()
        {
            Entity
                .AddEnemyAnimator(EnemyAnimator)
                .AddDamageTakenAnimator(EnemyAnimator);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasHeroAnimator)
            {
                Entity.RemoveEnemyAnimator();
            }

            if (Entity.hasDamageTakenAnimator)
            {
                Entity.RemoveDamageTakenAnimator();
            }
        }
    }
}