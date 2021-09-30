using System;
using System.Threading.Tasks;
using Worlds;

namespace Simulation
{
    public class Engine<WorldType> : ISimulationEngine where WorldType : IWorld<WorldType>
    {
        private readonly IWorld<WorldType> _world;

        private bool simulating = false;

        public Engine(IWorld<WorldType> world)
        {
            _world = world;
        }

        public async Task SimulateStep()
        {
            if (simulating) return;
            else simulating = true;

            await _world.SimulateStep();

            simulating = false;
        }
    }
}
