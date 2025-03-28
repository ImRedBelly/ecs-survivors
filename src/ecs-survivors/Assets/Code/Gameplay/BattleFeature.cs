using Code.Common.Destruct;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory factory)
        {
            Add(factory.Create<InputFeature>());
            Add(factory.Create<HeroFeature>());
            Add(factory.Create<MovementFeature>());
            Add(factory.Create<ProcessDestructedFeature>());
        }
    }
}