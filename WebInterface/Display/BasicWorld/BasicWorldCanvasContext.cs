using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Worlds;
using Worlds.Basic;

namespace WebInterface.Display
{
    public class BasicWorldCanvasContext : IWorldCanvasContext, World.IDisplayer
    {
        internal Canvas2DContext Context { get; private set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasicWorldCanvasContext(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public async Task InitializeAsync(BECanvasComponent canvasReference)
        {
            Context = await canvasReference.CreateCanvas2DAsync();
        }

        public async Task RenderFrameAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var world = (World)httpContext.RequestServices.GetService(typeof(World));

            await world.Display(this);
        }

        public async Task Display(World world)
        {
            await Context.BeginBatchAsync();

            await DrawBackGround();

            await DrawTiles(world.Tiles);

            await Context.EndBatchAsync();
        }

        private async Task DrawBackGround()
        {
            await Context.SetFillStyleAsync("#524019");

            await Context.FillRectAsync(0, 0, 900, 900);
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
        }

        private async Task DrawTile(Tile tile, int y, int x)
        {
            var color = GetGrassColor(tile);

            await Context.SetFillStyleAsync(color);

            await Context.FillRectAsync(x * 9, y * 9, 8, 8);
        }

        enum GrassType { None, Slow, Fast }
        private static string GetGrassColor(Tile tile)
        {
            (var grassType, var height) = ParseGrass(tile);

            var baseNone = ColorTranslator.FromHtml("#524019");
            var baseSlow = Color.FromArgb(0, 100, 0);
            var baseFast = Color.FromArgb(100, 0, 100);

            var drawingColor = grassType switch
            {
                GrassType.None => baseNone,
                GrassType.Slow => baseSlow,
                GrassType.Fast => baseFast,
                _ => Color.White,
            };

            var heightAdjustedColor = Color.FromArgb(drawingColor.R + 10 * height, drawingColor.G + 10 * height, drawingColor.B + 10 * height);

            byte max = 255;
            var safeAdjustedColor = Color.FromArgb(Math.Min(max, heightAdjustedColor.R), Math.Min(max, heightAdjustedColor.G), Math.Min(max, heightAdjustedColor.B));

            return ColorTranslator.ToHtml(safeAdjustedColor);
        }

        private static (GrassType grassType, int height) ParseGrass(Tile tile)
        {
            GrassType grassType;
            int height;
            if (tile.Grass == null)
            {
                grassType = GrassType.None;
                height = 0;
            }
            else
            {
                grassType = tile.Grass.Genome[0] ? GrassType.Slow : GrassType.Fast;
                height = tile.Grass.Height;
            }

            return (grassType, height);
        }
    }
}
