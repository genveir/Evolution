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
            return Task.CompletedTask;
        }
    }
}
