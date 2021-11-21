using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Worlds;

namespace Simulation
{
    public class Engine<WorldType> : ISimulationEngine where WorldType : IWorld<WorldType>
    {
        private IWorldProvider<WorldType> _worldProvider;

        public Engine(IWorldProvider<WorldType> worldprovider)
        {
            _worldProvider = worldprovider;
        }

        public async Task SimulateStep()
        {
            var world = _worldProvider.CurrentWorld;

            if (world.Age == world.GenerationSize)
            {
                world = await world.CreateNextGeneration();
                _worldProvider.CurrentWorld = world;
            }

            await world.SimulateStep();
        }
    }
}
