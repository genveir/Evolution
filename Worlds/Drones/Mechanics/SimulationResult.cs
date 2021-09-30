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
        public SimulationResult(DroneMother mother, long fitness, IEnumerable<SimulationState> steps)
        {
            Mother = mother;
            Fitness = fitness;
            _steps = steps.ToArray();
        }

        public DroneMother Mother { get; }

        public long Fitness { get; }

        private readonly SimulationState[] _steps;
        public IEnumerable<SimulationState> Steps => _steps;

        private int enumerationIndex = 0;
        public bool HasNext() => enumerationIndex < _steps.Length;

        public SimulationState GetNext()
        {
            return _steps[enumerationIndex++];
        }

        public int CompareTo(SimulationResult other)
        {
            if (other == null) return -1;

            else return Fitness.CompareTo(other.Fitness);
        }
    }
}
