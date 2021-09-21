using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public class WorldBuilder
    {
        public static TileType[][] GenerateTiles<TileType>(Func<TileType> CreateTile, int ySize, int xSize) where TileType : ITile
        {
            var tiles = new TileType[ySize][];

            for (int y = 0; y < tiles.Length; y++)
            {
                tiles[y] = new TileType[xSize];
                for (int x = 0; x < tiles[y].Length; x++)
                {
                    tiles[y][x] = CreateTile();

                    if (y > 0) tiles[y][x].LinkNeighbour(tiles[y - 1][x], true);
                    if (x > 0) tiles[y][x].LinkNeighbour(tiles[y][x - 1], true);
                }
            }

            return tiles;
        }
    }
}
