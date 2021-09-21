using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public interface ITile
    {
        IEnumerable<ITile> Neighbours { get; }

        void LinkNeighbour(ITile newNeighbour, bool linkBack);
    }
}
