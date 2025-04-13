using System;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class ProjectileSetup
    {
        public int projectileCount = 1;
        
        public float speed;
        public float contactRadius;
        public int pierce = 1;
        public int lifetime;
        
        public float orbitalRadius;
    }
}