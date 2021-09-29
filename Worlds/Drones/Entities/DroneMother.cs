using Geerten.Movement.Bodies;
using Geerten.Movement.Location;
using Genetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Drones.Entities
{
    public class DroneMother : IBody
    {
        internal const int BLUEPRINT_LENGTH = 12;

        public DroneMother(ILocation location, SingleStrandGenome blueprint)
        {
            Location = location;

            Blueprint = blueprint;
        }

        public SingleStrandGenome Blueprint { get; }

        public ILocation Location { get; }
    }
}
