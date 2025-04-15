using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Visuals.Enchants
{
    public class EnchantVisualsRegistrar : EntityComponentRegistrar
    {
        public EnchantVisuals enchantVisuals;

        public override void RegisterComponent()
        {
            Entity.AddEnchantVisuals(enchantVisuals);
        }

        public override void UnregisterComponent()
        {
            if (Entity.hasEnchantVisuals)
                Entity.RemoveEnchantVisuals();
        }
    }
}