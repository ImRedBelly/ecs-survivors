using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class CollectEffectItemSystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _collected;

        public CollectEffectItemSystem(GameContext gameContext, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Id, GameMatcher.WorldPosition));
            _collected = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Collected, GameMatcher.EffectSetups));
        }

        public void Execute()
        {
            foreach (var collected in _collected)
            foreach (var hero in _heroes)
            foreach (var effectSetup in collected.EffectSetups)
            {
                _effectFactory.CreateEffect(effectSetup, hero.Id, hero.Id);
            }
        }
    }
}