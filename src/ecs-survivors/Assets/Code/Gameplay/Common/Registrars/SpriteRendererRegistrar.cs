using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;

        public override void RegisterComponent()
        {
            Entity.AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasSpriteRenderer)
            {
                Entity.RemoveSpriteRenderer();
            }
        }
    }
}