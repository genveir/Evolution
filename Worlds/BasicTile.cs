using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds
{
    public abstract class BasicTile : ITile
    {
        protected readonly List<ITile> _neighbours;

        public IEnumerable<ITile> Neighbours => _neighbours;

        public BasicTile()
        {
            _neighbours = new List<ITile>();
        }

        public virtual void LinkNeighbour(ITile newNeighbour, bool linkBack = true)
        {
            _neighbours.Add(newNeighbour);
            if (linkBack) newNeighbour.LinkNeighbour(this, false);
        }
    }
}
