using Geerten.Movement.Bodies;
using Geerten.Movement.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Drones.Entities
{
    public class Asteroid : IBody
    {
        public Asteroid(ILocation location, long ore)
        {
            Location = location;
            Ore = ore;
        }

        public ILocation Location { get; }

        public long Ore { get; }
    }
}
