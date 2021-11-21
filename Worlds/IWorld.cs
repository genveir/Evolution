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

        /// <summary>
        /// Number of steps before the runner should create a new world and run that. Set to -1 to run infinite generations
        /// </summary>
        int GenerationSize { get; }
        /// <summary>
        /// Age of this world
        /// </summary>
        int Age { get; }
        /// <summary>
        /// Create a new generation, based on the current state of this world
        /// </summary>
        /// <returns>The newly created world</returns>
        Task<WorldType> CreateNextGeneration();
    }
}
