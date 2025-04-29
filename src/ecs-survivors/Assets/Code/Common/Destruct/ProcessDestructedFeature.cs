using Code.Common.Destruct.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.Destruct
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory factory)
        {
            Add(factory.Create<SelfDestructTimerSystem>());
            
            Add(factory.Create<CleanupMetaDestructedSystem>());
            
            Add(factory.Create<CleanupGameDestructedViewSystem>());
            Add(factory.Create<CleanupGameDestructedSystem>());
        }
    }
}