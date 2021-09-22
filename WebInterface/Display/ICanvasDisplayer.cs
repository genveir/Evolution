using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worlds;

namespace WebInterface.Display
{
    public interface ICanvasDisplayer<WorldType> : IDisplayer<WorldType> where WorldType : IWorld<WorldType>
    {
        Task InitializeContext(Canvas2DContext context);
    }
}
