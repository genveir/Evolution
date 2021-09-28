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
    public class Drone_Mother : IBody
    {
        public Drone_Mother(ILocation location, SingleStrandGenome blueprint)
        {
            Location = location;

            Blueprint = blueprint;
        }

        public SingleStrandGenome Blueprint { get; }

        public ILocation Location { get; }
    }
}
