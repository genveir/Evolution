using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worlds;

namespace WebInterface.Display
{
    public class WorldCanvasContext<WorldType> : IWorldCanvasContext where WorldType : IWorld<WorldType>
    {
        protected readonly IWorld<WorldType> _world;
        protected readonly ICanvasDisplayer<WorldType> _displayer;

        public WorldCanvasContext(IWorld<WorldType> world, ICanvasDisplayer<WorldType> displayer)
        {
            _world = world;
            _displayer = displayer;
        }

        public async Task InitializeAsync(BECanvasComponent canvasReference)
        {
            var context = await canvasReference.CreateCanvas2DAsync();

            await _displayer.InitializeContext(context);
        }

        public async Task RenderFrameAsync()
        {
            await _world.Display(_displayer);
        }

        public int GetWidth() => _displayer.GetWidth();
        public int GetHeight() => _displayer.GetHeight();
    }
}
