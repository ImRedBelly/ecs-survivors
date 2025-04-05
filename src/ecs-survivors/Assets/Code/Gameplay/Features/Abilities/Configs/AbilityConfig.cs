using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(menuName = "ECS Survivors/AbilityConfig/Create", fileName = "AbilityConfig")]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId abilityId;
        public List<AbilityLevel> levels;
    }
}