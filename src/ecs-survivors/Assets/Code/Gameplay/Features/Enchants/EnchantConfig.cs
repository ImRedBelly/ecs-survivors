using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants
{
 
    [CreateAssetMenu(menuName = "ECS Survivors/EnchantConfig/Create", fileName = "EnchantConfig")]
    public class EnchantConfig : ScriptableObject
    {
        public EnchantTypeId typeId;
        
        public float radius;
        public EntityBehaviour viewPrefab;
 
        public List<EffectSetup> effectSetups;
        public List<StatusSetup> statusSetups;
    }
}