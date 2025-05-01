using Code.Infrastructure.Systems;
using Code.Meta.Features.Simulation.Systems;

namespace Code.Meta.Features.Simulation
{
    public class SimulationFeature : Feature
    {
        public SimulationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BoosterDurationSystem>());
            Add(systemFactory.Create<CalculateGoldGainSystem>());
            
            Add(systemFactory.Create<AfkGoldGainSystem>());
            Add(systemFactory.Create<UpdateSimulationTimeSystem>());
        }
    }
}