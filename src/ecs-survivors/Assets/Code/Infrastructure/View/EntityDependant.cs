using UnityEngine;

namespace Code.Infrastructure.View
{
    [RequireComponent(typeof(EntityBehaviour))]
    public abstract class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour entityView;
        public GameEntity Entity => entityView != null ? entityView.Entity : null;

        private void Awake()
        {
            if (!entityView)
            {
                entityView = GetComponent<EntityBehaviour>();
            }
        }
    }
}