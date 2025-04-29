using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public sealed class FinalizeProcessedLevelUps : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _levelUps;

        public FinalizeProcessedLevelUps(GameContext gameContext)
        {
            _levelUps = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.LevelUp,
                GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var levelUp in _levelUps)
            {
                levelUp.isDestructed = true;
            }
        }
    }
}