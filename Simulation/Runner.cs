using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation
{
    public class Runner
    {
        private readonly ISimulationEngine _engine;
        private bool _isRunning;

        public const int tickSizeInMS = 1000;

        public Runner(ISimulationEngine engine)
        {
            _engine = engine;
        }

        public async Task Run()
        {
            while (true)
            {
                try
                {
                    if (_isRunning)
                    {
                        var next = DateTime.Now.AddMilliseconds(tickSizeInMS);

                        await _engine.SimulateStep();

                        var delay = next - DateTime.Now;
                        if (delay < TimeSpan.Zero) delay = TimeSpan.Zero;

                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public Task ToggleRunning()
        {
            _isRunning = !_isRunning;

            return Task.CompletedTask;
        }
    }
}
