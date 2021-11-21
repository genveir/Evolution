using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public interface IWorldProvider<WorldType> where WorldType : IWorld<WorldType>
    {
        public WorldType CurrentWorld { get; set; }
    }
}
