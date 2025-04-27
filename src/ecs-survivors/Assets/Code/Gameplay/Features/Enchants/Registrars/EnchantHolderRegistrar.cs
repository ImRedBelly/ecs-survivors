using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants.Registrars
{
    public class EnchantHolderRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EnchantHolder enchantHolder;

        public override void RegisterComponent()
        {
            Entity.AddEnchantHolder(enchantHolder);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasEnchantHolder)
            {
                Entity.RemoveEnchantHolder();
            }
        }
    }
}