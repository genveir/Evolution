using Simulation;
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
        private readonly Tile[][] _tiles;

        public World()
        {
            _tiles = new Tile[100][];

            var random = Statics.Random;

            for (int y = 0; y < 100; y++)
            {
                _tiles[y] = new Tile[100];
                for (int x = 0; x < 100; x++)
                {
                    _tiles[y][x] = new Tile();
                    if (y > 0) _tiles[y][x].LinkNeighbour(_tiles[y - 1][x]);
                    if (x > 0) _tiles[y][x].LinkNeighbour(_tiles[y][x - 1]);

                    if (random.NextDouble() < 0.3d)
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
