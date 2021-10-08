using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worlds.Drones;

namespace WebInterface.Display.DroneWorld
{
    public class DroneWorldDisplayer : ICanvasDisplayer<Worlds.Drones.DroneWorld>
    {
        private Canvas2DContext _context;

        private const int WIDTH = 1200;
        private const int HEIGHT = 900;

        public int GetWidth() => WIDTH;
        public int GetHeight() => HEIGHT;

        public Task InitializeContext(Canvas2DContext context)
        {
            _context = context;

            return Task.CompletedTask;
        }

        public async Task Display(Worlds.Drones.DroneWorld world)
        {
            await _context.BeginBatchAsync();

            await _context.SetFillStyleAsync("#112233");

            await _context.FillRectAsync(0, 0, WIDTH, HEIGHT);

            await _context.EndBatchAsync();
        }
    }
}
