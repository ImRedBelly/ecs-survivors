using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsNoLimitSystems : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;
        private readonly List<GameEntity> _buffer = new(64);

        public CastForTargetsNoLimitSystems(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = gameContext.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.TargetsBuffer,
                        GameMatcher.ReadyToCollectTargets,
                        GameMatcher.WorldPosition,
                        GameMatcher.Radius,
                        GameMatcher.LayerMask
                    )
                    .NoneOf(
                        GameMatcher.TargetLimit
                    ));
        }

        public void Execute()
        {
            foreach (var entity in _ready.GetEntities(_buffer))
            {
                entity.TargetsBuffer.AddRange(TargetsInRadius(entity));

                if (!entity.isCollectingTargetsContinuously)
                {
                    entity.isReadyToCollectTargets = false;
                }
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity entity)
        {
            return _physicsService
                .CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask)
                .Select(x => x.Id);
        }
    }
}