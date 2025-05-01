using Code.Common.Destruct;
using Code.Infrastructure.Systems;

namespace Code.Meta.Features.Simulation
{
    public class ActualizationFeature : Feature
    {
        public ActualizationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SimulationFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}