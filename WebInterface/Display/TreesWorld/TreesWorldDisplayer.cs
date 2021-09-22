using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebInterface.Display.TreesWorld
{
    public class TreesWorldDisplayer : ICanvasDisplayer<Worlds.Trees.TreesWorld>
    {
        private Canvas2DContext _context;

        public Task InitializeContext(Canvas2DContext context)
        {
            _context = context;

            return Task.CompletedTask;
        }

        public async Task Display(Worlds.Trees.TreesWorld world)
        {
            await _context.BeginBatchAsync();

            await _context.SetFillStyleAsync("#112233");

            await _context.FillRectAsync(0, 0, 900, 900);

            await _context.EndBatchAsync();
        }
    }
}
