using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Drones.Entities;

namespace Worlds.Drones.Mechanics
{
    public class SimulationState
    {
        public SimulationState(DroneMother mother, IEnumerable<Drone> drones, IEnumerable<Asteroid> asteroids)
        {
            DroneMother = mother;
            Drones = drones;
            Asteroids = asteroids;
        }

        public DroneMother DroneMother { get; }

        public IEnumerable<Drone> Drones { get; }

        public IEnumerable<Asteroid> Asteroids { get; }
    }
}
