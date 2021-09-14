
using Evolution;
using System;
using System.Threading.Tasks;

namespace Simulation
{
    public class Engine : ISimulationEngine
    {
        private readonly IWorld _world;

        public Engine(IWorld world)
        {
            _world = world;
        }

        public async Task SimulateStep()
        {
            await _world.SimulateStep();
        }
    }
}
