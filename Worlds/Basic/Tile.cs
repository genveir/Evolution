using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using Worlds.Basic.Entities;

namespace Worlds.Basic
{
    public class Tile : BasicTile
    {
        private readonly List<Grass> _seedlings;
        public Grass Grass { get; private set; }

        public Tile() : base()
        {
            _seedlings = new List<Grass>();
        }

        public async Task SimulateStep()
        {
            if (Grass != null) await Grass.SimulateStep(this);
        }

        public void AddSeedling(Grass seedling)
        {
            _seedlings.Add(seedling);
        }

        public Task ResolveSeedlings()
        {
            if (Grass == null || Grass.IsDead)
            {
                GrowSeedling();
            }

            _seedlings.Clear();

            return Task.CompletedTask;
        }

        private void GrowSeedling()
        {
            if (_seedlings != null && _seedlings.Count > 0)
            {
                var random = Statics.Random.Next(0, _seedlings.Count);

                this.Grass = _seedlings[random];
            }
        }

        public override string ToString()
        {
            if (Grass == null) return ".";
            else return Grass.Genome[0] ? "s" : "f";
        }
    }
}
