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

        public bool IsDead { get; private set; }

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

        private void Die()
        {
            IsDead = true;
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

            if (Height > 10) Die();
            else if (Height > 2) Spread(tile);

            return Task.CompletedTask;
        }
    }
}
