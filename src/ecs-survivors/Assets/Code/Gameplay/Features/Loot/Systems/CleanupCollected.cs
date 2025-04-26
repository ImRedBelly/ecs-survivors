using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class CleanupCollected : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _collected;

        public CleanupCollected(GameContext gameContext)
        {
            _collected = gameContext.GetGroup(GameMatcher.Collected);
        }

        public void Cleanup()
        {
            foreach (var collected in _collected)
            {
                collected.isDestructed = true;
            }
        }
    }
}