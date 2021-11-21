using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using Worlds.Drones.Entities;

namespace Worlds.Drones
{
    public class DroneWorld : IWorld<DroneWorld>
    {
        private readonly ICollection<Asteroid> Asteroids;
        private readonly ICollection<Drone> Drones;

        public Tile[][] tiles;

        public DroneWorld()
        {
            tiles = WorldBuilder.GenerateTiles<Tile>(() => new Tile(), 100, 100);

            this.Asteroids = new List<Asteroid>();
            this.Drones = new List<Drone>();

            ScatterAsteroids();
            BuildDrones();
        }

        private void BuildDrones()
        {
            for (int n = 0; n < 100; n++)
            {
                var x = Statics.Random.Next(100);
                var y = Statics.Random.Next(100);

                var drone = new Drone();

                tiles[y][x].Drones.Add(drone);
                this.Drones.Add(drone);
            }
        }

        private void ScatterAsteroids()
        {
            for (int n = 0; n < 100; n++)
            {
                var x = Statics.Random.Next(100);
                var y = Statics.Random.Next(100);

                var asteroid = new Asteroid();

                tiles[y][x].Asteroid = asteroid;
                this.Asteroids.Add(asteroid);
            }
        }

        public async Task Display(IDisplayer<DroneWorld> displayer)
        {
            await displayer.Display(this);
        }

        public Task SimulateStep()
        {
            Age++;

            return Task.CompletedTask;
        }

        public int Age { get; private set; } = 0;
        public int GenerationSize => -1;
        public Task<DroneWorld> CreateNextGeneration()
        {
            var nextGeneration = new DroneWorld();

            return Task.FromResult(nextGeneration);
        }
    }
}
