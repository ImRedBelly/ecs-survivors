using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(menuName = "ECS Survivors/LevelUpConfig/Create", fileName = "LevelUpConfig")]
    public class LevelUpConfig : ScriptableObject
    {
        public int maxLevel;
        public List<float> experienceForLevel;
        
    }
}