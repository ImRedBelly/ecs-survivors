using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Systems
{
    public sealed class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessHealEffectSystem(GameContext gameContext)
        {
            _effects = gameContext.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.HealEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;

                if (target.isDead)
                {
                    continue;
                }

                if (target.hasMaxHp && target.hasCurrentHp)
                {
                    float newValue = Mathf.Min(target.CurrentHp + effect.EffectValue, target.MaxHp);
                    target.ReplaceCurrentHp(newValue);
                }
            }
        }
    }
}