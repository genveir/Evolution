using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Drones.Entities;

namespace Worlds.Drones.Mechanics
{
    public class SimulationResult : IComparable<SimulationResult>
    {
        public SimulationResult(DroneMother mother, int fitness, IEnumerable<SimulationState> steps)
        {
            Mother = mother;
            Fitness = fitness;
            Steps = steps;
        }

        public DroneMother Mother { get; }

        public int Fitness { get; }

        public IEnumerable<SimulationState> Steps { get; }

        public int CompareTo(SimulationResult other)
        {
            if (other == null) return -1;

            else return Fitness.CompareTo(other.Fitness);
        }
    }
}
