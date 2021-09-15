using Blazor.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebInterface.Display
{
    public interface IWorldCanvasContext
    {
        public Task InitializeAsync(BECanvasComponent canvasReference);

        public Task RenderFrameAsync();
    }
}
