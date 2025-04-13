using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Behaviours
{
    public class AuraSizeListener : EntityDependant
    {
        public Transform container;
        private float _radiusPrev;

        private void Update()
        {
            if (Mathf.Abs(Entity.Radius - _radiusPrev) < Mathf.Epsilon)
            {
                return;
            }

            SetAurraScale();
        }

        private void SetAurraScale()
        {
            float scale = Entity.Radius * 2;
            container.localScale = new Vector3(scale, scale, scale);

            _radiusPrev = Entity.Radius;
        }
    }
}