using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats
{
    public class StatsComponents
    {
        [Game] public class BaseStats : IComponent { public Dictionary<Stats, float> Value; }
        [Game] public class StatsModifiers : IComponent { public Dictionary<Stats, float> Value; }
        [Game] public class StatChange : IComponent { public Stats Value; }
    }
}