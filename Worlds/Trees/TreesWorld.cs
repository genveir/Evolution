using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Trees
{
    public class TreesWorld : IWorld<TreesWorld>
    {
        public async Task Display(IDisplayer<TreesWorld> displayer)
        {
            await displayer.Display(this);
        }

        public Task SimulateStep()
        {
            return Task.CompletedTask;
        }

        public Task<IWorld<TreesWorld>> CreateNextGeneration()
        {
            IWorld<TreesWorld> nextGeneration = new TreesWorld();

            return Task.FromResult(nextGeneration);
        }
    }
}
