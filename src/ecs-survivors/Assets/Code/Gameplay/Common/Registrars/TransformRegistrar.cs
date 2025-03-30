using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public Transform Transform;

        public override void RegisterComponent()
        {
            Entity.AddTransform(Transform);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasTransform)
            {
                Entity.RemoveTransform();
            }
        }
    }
}