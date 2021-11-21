using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public interface IWorldInitializer<WorldType> where WorldType : IWorld<WorldType>
    {
        WorldType CreateInitialWorld();
    }
}
