using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Trees
{
    public class TreesWorldInitializer : IWorldInitializer<TreesWorld>
    {
        public TreesWorld CreateInitialWorld() => new TreesWorld();
    }
}
