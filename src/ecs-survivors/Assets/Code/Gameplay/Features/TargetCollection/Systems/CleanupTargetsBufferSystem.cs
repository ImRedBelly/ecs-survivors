using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanupTargetsBufferSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupTargetsBufferSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.TargetsBuffer);
        }
    
        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.TargetsBuffer.Clear();
            }  
        }

    }
}