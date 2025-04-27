using Code.Gameplay.Features.Enchants.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enchants
{
    public class EnchantFeature : Feature
    {
        public EnchantFeature(ISystemFactory factory)
        {
            Add(factory.Create<PoisonEnchantSystem>());
            Add(factory.Create<ExplosiveEnchantSystem>());
            
            Add(factory.Create<ApplyPoisonEnchantVisualSystem>());
            
            Add(factory.Create<AddEnchantsToHolderSystem>());
        }
    }
}