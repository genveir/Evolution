using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Drones.Entities;

namespace Worlds.Drones
{
    public class Tile : BasicTile
    {
        public Tile()
        {
            Drones = new List<Drone>();
        }

        public Asteroid Asteroid { get; set; }

        public ICollection<Drone> Drones { get; set; }
    }
}
