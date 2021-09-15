using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using Worlds.Basic.Entities;

namespace Worlds.Basic
{
    public class World : IWorld
    {
        public Guid Id = Guid.NewGuid();

        public interface IDisplayer
        {
            Task Display(World world);
        }

        private const int Y_SIZE = 100;
        private const int X_SIZE = 100;
        private const double INITIAL_GRASS_SPAWN_RATE = 0.3d;

        public Tile[][] Tiles { get; }

        public World()
        {
            Tiles = new Tile[Y_SIZE][];

            var random = Statics.Random;

            for (int y = 0; y < Tiles.Length; y++)
            {
                Tiles[y] = new Tile[X_SIZE];
                for (int x = 0; x < Tiles[y].Length; x++)
                {
                    Tiles[y][x] = new Tile();
                    if (y > 0) Tiles[y][x].LinkNeighbour(Tiles[y - 1][x]);
                    if (x > 0) Tiles[y][x].LinkNeighbour(Tiles[y][x - 1]);

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

            Tick++;
        }

        public int Tick { get; private set; }

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

        public async Task Display(IDisplayer displayer)
        {
            await displayer.Display(this);
        }
    }
}
