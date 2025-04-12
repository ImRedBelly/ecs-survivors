using System;

namespace Code.Gameplay.Features.Statuses
{
    [Serializable]
    public class StatusSetup
    {
        public StatusTypeId statusTypeId;
        public float value;
        public float duration;
        public float period;
    }
}