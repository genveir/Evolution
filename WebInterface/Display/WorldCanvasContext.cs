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
        protected readonly IWorldProvider<WorldType> _worldProvider;
        protected readonly ICanvasDisplayer<WorldType> _displayer;

        public WorldCanvasContext(IWorldProvider<WorldType> worldProvider, ICanvasDisplayer<WorldType> displayer)
        {
            _worldProvider = worldProvider;
            _displayer = displayer;
        }

        public async Task InitializeAsync(BECanvasComponent canvasReference)
        {
            var context = await canvasReference.CreateCanvas2DAsync();

            await _displayer.InitializeContext(context);
        }

        public async Task RenderFrameAsync()
        {
            var world = _worldProvider.CurrentWorld;

            await world.Display(_displayer);
        }
    }
}
