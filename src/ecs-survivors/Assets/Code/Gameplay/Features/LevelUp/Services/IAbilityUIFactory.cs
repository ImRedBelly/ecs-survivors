using Code.Gameplay.Features.LevelUp.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public interface IAbilityUIFactory
    {
        AbilityCard CreateAbilityCard(Transform parent);
    }
}