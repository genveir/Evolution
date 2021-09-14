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
        private const int Y_SIZE = 100;
        private const int X_SIZE = 100;
        private const double INITIAL_GRASS_SPAWN_RATE = 0.3d;

        private readonly Tile[][] _tiles;

        public World()
        {
            _tiles = new Tile[Y_SIZE][];

            var random = Statics.Random;

            for (int y = 0; y < _tiles.Length; y++)
            {
                _tiles[y] = new Tile[X_SIZE];
                for (int x = 0; x < _tiles[y].Length; x++)
                {
                    _tiles[y][x] = new Tile();
                    if (y > 0) _tiles[y][x].LinkNeighbour(_tiles[y - 1][x]);
                    if (x > 0) _tiles[y][x].LinkNeighbour(_tiles[y][x - 1]);

                    if (random.NextDouble() < INITIAL_GRASS_SPAWN_RATE)
                    {
                        _tiles[y][x].AddSeedling(new Grass());
                        _tiles[y][x].ResolveSeedlings();
                    }
                }
            }
        }

        public async Task SimulateStep()
        {
            await EachTile(tile => tile.SimulateStep());

            await EachTile(Tile => Tile.ResolveSeedlings());
        }

        private async Task EachTile(Func<Tile, Task> action)
        {
            for (int y = 0; y < _tiles.Length; y++)
            {
                for (int x = 0; x < _tiles[y].Length; x++)
                {
                    await action(_tiles[y][x]);
                }
            }
        }
    }
}
