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
            Age++;

            return Task.CompletedTask;
        }

        public int Age { get; private set; } = 0;
        public int GenerationSize => -1;
        public Task<TreesWorld> CreateNextGeneration()
        {
            var nextGeneration = new TreesWorld();

            return Task.FromResult(nextGeneration);
        }
    }
}
