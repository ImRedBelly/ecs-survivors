using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsWithLimitSystems : IExecuteSystem, ITearDownSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;
        private readonly List<GameEntity> _buffer = new(64);
        private GameEntity[] _targetCastBuffer = new GameEntity[128];

        public CastForTargetsWithLimitSystems(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = gameContext.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.ReadyToCollectTargets,
                        GameMatcher.Radius,
                        GameMatcher.TargetsBuffer,
                        GameMatcher.ProcessedTargets,
                        GameMatcher.TargetLimit,
                        GameMatcher.WorldPosition,
                        GameMatcher.LayerMask
                    ));
        }

        public void Execute()
        {
            foreach (var entity in _ready.GetEntities(_buffer))
            {
                for (int i = 0; i < Math.Min(TargetCountInRadius(entity), entity.TargetLimit); i++)
                {
                    int targetId = _targetCastBuffer[i].Id;
                    if (!AllReadyProcessed(entity, targetId))
                    {
                        entity.TargetsBuffer.Add(targetId);
                        entity.ProcessedTargets.Add(targetId);
                    }
                }

                if (!entity.isCollectingTargetsContinuously)
                {
                    entity.isReadyToCollectTargets = false;
                }
            }
        }

        public void TearDown()
        {
            _targetCastBuffer = null;
        }

        private int TargetCountInRadius(GameEntity entity)
        {
            return _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.Radius, entity.LayerMask, _targetCastBuffer);
        }

        private bool AllReadyProcessed(GameEntity entity, int targetId)
        {
            return entity.ProcessedTargets.Contains(targetId);
        }
    }
}