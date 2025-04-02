using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Systems;

namespace Code.Infrastructure.View
{
    public class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory factory)
        {
            Add(factory.Create<BindEntityViewFromPathSystem>());
            Add(factory.Create<BindEntityViewFromPrefabSystem>());
        }
    }
}