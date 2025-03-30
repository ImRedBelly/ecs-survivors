using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _damageDealers;

        public ApplyDamageOnTargetsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _damageDealers = _gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.Damage
            ));
        }

        public void Execute()
        {
            foreach (var damageDealer in _damageDealers)
            {
                foreach (var targetId in damageDealer.TargetsBuffer)
                {
                    GameEntity target = _gameContext.GetEntityWithId(targetId);

                    if (target.hasCurrentHp)
                    {
                        target.ReplaceCurrentHp(target.CurrentHp - damageDealer.Damage);
                        if (target.hasDamageTakenAnimator)
                        {
                            target.DamageTakenAnimator.PlayDamageTaken();
                        }
                    }
                }
            }
        }
    }
}