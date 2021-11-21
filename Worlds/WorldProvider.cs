using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public class WorldProvider<WorldType> : IWorldProvider<WorldType> where WorldType : IWorld<WorldType>
    {
        public WorldProvider(IWorldInitializer<WorldType> initializer)
        {
            CurrentWorld = initializer.CreateInitialWorld();
        }

        public WorldType CurrentWorld { get; set; }
    }
}
