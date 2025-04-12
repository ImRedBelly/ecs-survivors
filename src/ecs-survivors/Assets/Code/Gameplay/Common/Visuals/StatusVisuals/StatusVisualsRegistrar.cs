using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Visuals.StatusVisuals
{
    public class StatusVisualsRegistrar : EntityComponentRegistrar
    {
        public StatusVisuals StatusVisuals;

        public override void RegisterComponent()
        {
            Entity.AddStatusVisuals(StatusVisuals);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasStatusVisuals)
                Entity.RemoveStatusVisuals();
        }
    }
}