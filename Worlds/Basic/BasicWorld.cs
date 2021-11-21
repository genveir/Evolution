using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using Worlds.Basic.Entities;

namespace Worlds.Basic
{
    public class BasicWorld : IWorld<BasicWorld>
    {
        public int Age { get; private set; } = 0;
        public int GenerationSize => 50;

        private const int Y_SIZE = 100;
        private const int X_SIZE = 100;
        private const double INITIAL_GRASS_SPAWN_RATE = 0.3d;

        public Tile[][] Tiles { get; }

        public BasicWorld()
        {
            Tiles = WorldBuilder.GenerateTiles(() => new Tile(), Y_SIZE, X_SIZE);

            var random = Statics.Random;

            for (int y = 0; y < Tiles.Length; y++)
            {
                for (int x = 0; x < Tiles[y].Length; x++)
                {
                    if (random.NextDouble() < INITIAL_GRASS_SPAWN_RATE)
                    {
                        Tiles[y][x].AddSeedling(new Grass());
                        Tiles[y][x].ResolveSeedlings();
                    }
                }
            }
        }

        public async Task SimulateStep()
        {
            await EachTile(tile => tile.SimulateStep());

            await EachTile(Tile => Tile.ResolveSeedlings());

            Age++;
        }

        private async Task EachTile(Func<Tile, Task> action)
        {
            for (int y = 0; y < Tiles.Length; y++)
            {
                for (int x = 0; x < Tiles[y].Length; x++)
                {
                    await action(Tiles[y][x]);
                }
            }
        }

        public async Task Display(IDisplayer<BasicWorld> displayer)
        {
            await displayer.Display(this);
        }

        public Task<BasicWorld> CreateNextGeneration()
        {
            var nextGeneration = new BasicWorld();

            return Task.FromResult(nextGeneration);
        }
    }
}
