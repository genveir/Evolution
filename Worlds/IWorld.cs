using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public interface IWorld<WorldType> where WorldType : IWorld<WorldType>
    {
        Task SimulateStep();

        Task Display(IDisplayer<WorldType> displayer);

        Task<IWorld<WorldType>> CreateNextGeneration();
    }
}
