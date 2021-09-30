using Geerten.Movement.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using Worlds.Drones.Entities;

namespace Worlds.Drones.Mechanics
{
    public class SimulationState
    {
        public SimulationState(DroneMother mother, IEnumerable<Drone> drones, IEnumerable<Asteroid> asteroids)
        {
            DroneMother = mother;
            Drones = drones;
            Asteroids = asteroids;
        }

        public static SimulationState CreateNew(DroneMother mother)
        {
            var asteroids = CreateAsteroids();

            return new SimulationState(mother, new List<Drone>(), asteroids);
        }

        private static IEnumerable<Asteroid> CreateAsteroids()
        {
            int maxWidth = StaticConfig.WIDTH - 200;
            int maxHeight = StaticConfig.HEIGHT - 200;

            var random = Statics.Random;

            var volume = maxWidth * maxHeight;

            var numAsteroids = volume / 10000;

            var asteroids = new List<Asteroid>();
            for (int n = 0; n < numAsteroids; n++)
            {
                var xPos = random.Next(maxWidth - 200) + 200;
                var yPos = random.Next(maxHeight - 200) + 200;

                var location = new FixedLocation(xPos, yPos);

                asteroids.Add(new Asteroid(location, 100));
            }

            return asteroids;
        }

        public DroneMother DroneMother { get; }

        public IEnumerable<Drone> Drones { get; }

        public IEnumerable<Asteroid> Asteroids { get; }
    }
}
