using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public sealed class RemoveEffectsWithoutTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveEffectsWithoutTargetsSystem(GameContext gameContext)
        {
            _effects = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Effect, GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                GameEntity target = effect.Target();

                if (target == null)
                {
                    effect.Destroy();
                }
            }
        }
    }
}