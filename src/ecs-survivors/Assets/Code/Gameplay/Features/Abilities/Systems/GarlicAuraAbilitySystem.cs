using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public sealed class GarlicAuraAbilitySystem : IExecuteSystem
    {
        private readonly IArmamentFactory _armamentFactory;

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;

        private readonly List<GameEntity> _buffer = new(1);

        public GarlicAuraAbilitySystem(GameContext gameContext, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.GarlicAuraAbility)
                .NoneOf(GameMatcher.Active));

            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero, 
                    GameMatcher.Id
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var hero in _heroes)
            {
                _armamentFactory.CreateEffectAura(AbilityId.GarlicAura, hero.Id, 1);
                ability.isActive = true;
            }
        }
    }
}