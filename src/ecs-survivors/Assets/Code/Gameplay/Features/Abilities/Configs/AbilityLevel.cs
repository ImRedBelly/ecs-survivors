using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class AbilityLevel
    {
        public float cooldown;
        
        public EntityBehaviour viewPrefab;

        public List<EffectSetup> effectSetups;
        
        public ProjectileSetup projectileSetup;
    }
}