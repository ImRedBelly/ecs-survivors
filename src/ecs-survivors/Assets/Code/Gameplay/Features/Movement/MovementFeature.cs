using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory factory)
        {
            Add(factory.Create<DirectionalDeltaMoveSystem>());
            Add(factory.Create<OrbitalDeltaMoveSystem>());
            Add(factory.Create<OrbitCenterFollowSystem>());

            Add(factory.Create<TurnAlongDirectionSystem>());
            
            Add(factory.Create<UpdateTransformPositionSystem>());
            Add(factory.Create<RotateAlongDirectionSystem>());
        }
    }
}