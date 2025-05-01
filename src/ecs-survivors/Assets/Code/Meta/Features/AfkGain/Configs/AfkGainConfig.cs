using UnityEngine;

namespace Code.Meta.Features.AfkGain.Configs
{
    [CreateAssetMenu(menuName = "ECS Survivors/AfkGainConfig/Create", fileName = "AfkGainConfig")]
    public class AfkGainConfig : ScriptableObject
    {
        public float goldPerSeconds = 1;
    }
}