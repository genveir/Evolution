using System;
using System.Threading.Tasks;
using Worlds;

namespace Simulation
{
    public class Engine<WorldType> : ISimulationEngine where WorldType : IWorld<WorldType>
    {
        private readonly IWorld<WorldType> _world;

        public Engine(IWorld<WorldType> world)
        {
            _world = world;
        }

        public async Task SimulateStep()
        {
            await _world.SimulateStep();
        }
    }
}
