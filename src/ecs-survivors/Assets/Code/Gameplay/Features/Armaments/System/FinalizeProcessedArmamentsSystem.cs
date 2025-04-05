using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.System
{
    public sealed class FinalizeProcessedArmamentsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        public FinalizeProcessedArmamentsSystem(GameContext gameContext)
        {
            _armaments = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Armament, GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var armament in _armaments)
            {
                armament.RemoveTargetCollectionComponents();
                armament.isDestructed = true;
            }
        }
    }
}