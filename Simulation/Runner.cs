using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation
{
    public class Runner : BackgroundService
    {
        private readonly ISimulationEngine _engine;
        private static bool _isRunning;

        public int tickSizeInMS = 1000;

        public Runner(ISimulationEngine engine)
        {
            _engine = engine;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Loop(cancellationToken);
        }

        private async Task Loop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + ": " + DateTime.Now);

                    TimeSpan delay = TimeSpan.FromMilliseconds(tickSizeInMS);
                    if (_isRunning)
                    {
                        var next = DateTime.Now.Add(delay);

                        await _engine.SimulateStep();

                        delay = next - DateTime.Now;
                        if (delay < TimeSpan.Zero) delay = TimeSpan.Zero;
                    }

                    await Task.Delay(delay, cancellationToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void ToggleRunning()
        {
            _isRunning = !_isRunning;
        }
    }
}
