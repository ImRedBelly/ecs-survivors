using System;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class AbilityLevel
    {
        public float cooldown;
        
        public EntityBehaviour viewPrefab;
        
        public ProjectileSetup projectileSetup;
    }
}