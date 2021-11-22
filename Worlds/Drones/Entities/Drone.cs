using Genetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Drones.Entities
{
    public class Drone
    {
        private Drone() { }

        public static Drone Random()
        {
            return new Drone()
            {
                Genome = SingleStrandGenome.Random(64)
            };
        }

        public Drone BuildChild()
        {
            return new Drone()
            {
                Genome = Genome.Mutate(0.01d)
            };
        }

        public SingleStrandGenome Genome { get; init; }

        public long Age { get; private set; }

        public long Ore { get; private set; }
    }
}
