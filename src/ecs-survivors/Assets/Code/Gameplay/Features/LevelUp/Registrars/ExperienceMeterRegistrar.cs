using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp.Registrars
{
    public class ExperienceMeterRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private ExperienceMeter experienceMeter;

        public override void RegisterComponent()
        {
            Entity.AddExperienceMeter(experienceMeter);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasExperienceMeter)
            {
                Entity.RemoveExperienceMeter();
            }
        }
    }
}