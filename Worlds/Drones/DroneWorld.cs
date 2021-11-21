using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Drones
{
    public class DroneWorld : IWorld<DroneWorld>
    {
        public async Task Display(IDisplayer<DroneWorld> displayer)
        {
            await displayer.Display(this);
        }

        public Task SimulateStep()
        {
            Age++;

            return Task.CompletedTask;
        }

        public int Age { get; private set; } = 0;
        public int GenerationSize => -1;
        public Task<DroneWorld> CreateNextGeneration()
        {
            var nextGeneration = new DroneWorld();

            return Task.FromResult(nextGeneration);
        }
    }
}
