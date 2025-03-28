using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory factory)
        {
            Add(factory.Create<InitializeInputSystem>());
            Add(factory.Create<EmitInputSystem>());
        }
    }
}