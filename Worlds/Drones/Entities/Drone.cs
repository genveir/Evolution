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
    public class Drone : IBody
    {
        public Drone(ILocation location, SingleStrandGenome blueprint)
        {
            Location = location;

            Speed = blueprint.Number(0, 4); // 0-15

            var baseCargoSpace = blueprint.Number(4, 4);
            CargoSpace = baseCargoSpace * 30; // 0-450
            MiningSpeed = blueprint.Number(8, 4); // 0-15

            Cost = Speed + baseCargoSpace + MiningSpeed;
        }

        public ILocation Location { get; }

        public long Speed { get; }

        public long CargoSpace { get; }

        public long MiningSpeed { get; }

        public long Cost { get; }
    }
}
