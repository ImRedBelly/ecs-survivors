using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanupTargetsBufferSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupTargetsBufferSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.TargetsBuffer);
        }

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities())
            {
                entity.TargetsBuffer.Clear();
            }
        }
    }
}