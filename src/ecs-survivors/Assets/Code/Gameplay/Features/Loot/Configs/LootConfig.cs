using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Configs
{
    [CreateAssetMenu(menuName = "ECS Survivors/LootConfig/Create", fileName = "LootConfig")]
    public class LootConfig : ScriptableObject
    {
        public LootTypeId lootTypeId;
        public float experience;
        
        public EntityBehaviour viewPrefab;

        public List<EffectSetup> effectSetups;
        public List<StatusSetup> statusSetups;
    }
}