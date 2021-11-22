using Blazor.Extensions.Canvas.Canvas2D;
using Worlds.Drones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace WebInterface.Display.Drones
{
    public class DroneWorldDisplayer : ICanvasDisplayer<DroneWorld>
    {
        private Canvas2DContext _context;

        public Task InitializeContext(Canvas2DContext context)
        {
            _context = context;

            return Task.CompletedTask;
        }

        public async Task Display(DroneWorld world)
        {
            await _context.BeginBatchAsync();

            await DrawBackground();

            await DrawTiles(world.tiles);

            await _context.EndBatchAsync();
        }

        private async Task DrawBackground()
        {
            await _context.SetFillStyleAsync("#112233");

            await _context.FillRectAsync(0, 0, 900, 900);
        }

        private async Task DrawTiles(Tile[][] tiles)
        {
            for (int y = 0; y < tiles.Length; y++)
            {
                for (int x = 0; x < tiles[y].Length; x++)
                {
                    await DrawTile(tiles[y][x], y, x);
                }
            }

            for (int y = 0; y < tiles.Length; y++)
            {
                for (int x = 0; x < tiles[y].Length; x++)
                {
                    await DrawText(tiles[y][x], y, x);
                }
            }
        }

        private async Task DrawTile(Tile tile, int y, int x)
        {
            var asteroid = tile.Asteroid;
            var drones = tile.Drones.Count;

            var drawingColor = Color.Black;
            if (asteroid != null) drawingColor = Color.White;
            else if (drones > 0) drawingColor = Color.Red;

            var color = ColorTranslator.ToHtml(drawingColor);
            await _context.SetFillStyleAsync(color);

            await _context.FillRectAsync(x * 9, y * 9, 8, 8);
        }

        private async Task DrawText(Tile tile, int y, int x)
        {
            var asteroid = tile.Asteroid;
            var drones = tile.Drones.Count;

            if (asteroid != null)
            {
                var textColor = ColorTranslator.ToHtml(Color.Yellow);

                await _context.SetStrokeStyleAsync(textColor);
                await _context.StrokeTextAsync(asteroid.Ore.ToString(), x * 9 - 8, y * 9 + 10);
            }

            if (drones > 0)
            {
                var textColor = ColorTranslator.ToHtml(Color.Cyan);

                await _context.SetStrokeStyleAsync(textColor);
                await _context.StrokeTextAsync(drones.ToString(), x * 9 + 8, y * 9 + 10);
            }

            
        }
    }
}
