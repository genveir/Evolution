using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolution
{
    public interface ISimulationEngine
    {
        Task SimulateStep();
    }
}
