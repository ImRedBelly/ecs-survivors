using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory factory)
        {
            Add(factory.Create<InitializeHeroSystem>());
            
            Add(factory.Create<SetHeroDirectionByInputSystem>());
            Add(factory.Create<CameraFollowHeroSystem>());
            Add(factory.Create<AnimateHeroMovementSystem>());
            Add(factory.Create<HeroDeathSystem>());
            
            Add(factory.Create<FinalizeHeroDeathProcessingSystem>());
        }
    }
}   