using Code.Common.Extensions;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class CastForPullablesSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _looters;

        private readonly GameEntity[] _hitBuffer = new GameEntity[128];
        private readonly int _layerMask = CollisionLayer.Collectable.AsMask();

        public CastForPullablesSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _looters = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PickupRadius));
        }

        public void Execute()
        {
            foreach (var looter in _looters)
            {
                for (int i = 0; i < LootInRadius(looter); i++)
                {
                    if (_hitBuffer[i].isPullable)
                    {
                        _hitBuffer[i].isPullable = false;
                        _hitBuffer[i].isPulling = true;
                    }
                }

                ClearBuffer();
            }
        }

        private int LootInRadius(GameEntity looter)
        {
            return _physicsService.CircleCastNonAlloc(looter.WorldPosition, radius: looter.PickupRadius, _layerMask, _hitBuffer);
        }

        private void ClearBuffer()
        {
            for (int i = 0; i < _hitBuffer.Length; i++)
            {
                _hitBuffer[i] = null;
            }
        }
    }
}