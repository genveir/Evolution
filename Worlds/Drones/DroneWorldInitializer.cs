using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Drones
{
    public class DroneWorldInitializer : IWorldInitializer<DroneWorld>
    {
        public DroneWorld CreateInitialWorld() => new();
    }
}
