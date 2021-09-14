using Genetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Worlds.Basic.Entities
{
    public class Grass
    {
        private readonly SingleStrandGenome _genome;

        public int Height { get; private set; }

        public SingleStrandGenome Genome => _genome;

        public Grass()
        {
            _genome = SingleStrandGenome.Random(1);
        }

        public Grass(Grass parent)
        {
            _genome = parent.Genome.Mutate(0.05d);
        }

        private void Grow()
        {
            Height++;
        }

        private static void Die(Tile tile)
        {
            tile.Grass = null;
        }

        private void Spread(Tile tile)
        {
            foreach (var neighbour in tile.Neighbours)
            {
                neighbour.AddSeedling(new Grass(this));
            }
        }

        public Task SimulateStep(Tile tile)
        {
            if (_genome[0]) Grow();
            else
            {
                Grow(); Grow();
            }

            if (Height > 10) Die(tile);
            else if (Height > 2) Spread(tile);

            return Task.CompletedTask;
        }
    }
}
