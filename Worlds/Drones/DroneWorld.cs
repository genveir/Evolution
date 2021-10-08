using Geerten.Movement.Location;
using Genetics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Drones.Entities;
using Worlds.Drones.Mechanics;

namespace Worlds.Drones
{
    public class DroneWorld : IWorld<DroneWorld>
    {
        SingleStrandGenome[] genomePool;

        public DroneWorld()
        {
            genomePool = new SingleStrandGenome[100];

            for (int n = 0; n < 100; n++) genomePool[n] = SingleStrandGenome.Random(DroneMother.BLUEPRINT_LENGTH);
        }

        public async Task Display(IDisplayer<DroneWorld> displayer)
        {
            await displayer.Display(this);
        }

        public async Task SimulateStep()
        {
            var generation = await CreateGeneration();

            var results = await Simulate(generation);

            genomePool = await CreateNewBlueprints(results);
        }

        private Task<IEnumerable<DroneMother>> CreateGeneration()
        {
            var generation = genomePool.Select(g => new DroneMother(new FixedLocation(450, 450), g));

            return Task.FromResult(generation);
        }

        private static Task<IEnumerable<SimulationResult>> Simulate(IEnumerable<DroneMother> mothers)
        {
            var results = new ConcurrentBag<SimulationResult>();
            Parallel.ForEach(mothers, async m =>
            {
                var result = await Simulate(m);
                results.Add(result);
            });

            IEnumerable<SimulationResult> returnable = results;
            return Task.FromResult(returnable);
        }

        private static async Task<SimulationResult> Simulate(DroneMother mother)
        {
            return await Task.FromResult(new SimulationResult(mother, 0, new List<SimulationState>()));
        }

        private static Task<SingleStrandGenome[]> CreateNewBlueprints(IEnumerable<SimulationResult> results)
        {
            var orderedResult = results.OrderBy(r => r).ToArray();

            var newBlueprints = new SingleStrandGenome[100];
            for (int n = 0; n < 20; n++)
            {
                newBlueprints[n] = orderedResult[n].Mother.Blueprint;

                for (int i = 0; i < 4; i++)
                {
                    newBlueprints[20 + 4 * n + i] = newBlueprints[n].Mutate(0.5d);
                }
            }

            return Task.FromResult(newBlueprints);
        }
    }
}
