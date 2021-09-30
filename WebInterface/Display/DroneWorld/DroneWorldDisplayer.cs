using Blazor.Extensions.Canvas.Canvas2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worlds.Drones;
using Worlds.Drones.Entities;

namespace WebInterface.Display.DroneWorld
{
    public class DroneWorldDisplayer : ICanvasDisplayer<Worlds.Drones.DroneWorld>
    {
        private Canvas2DContext _context;

        public int GetWidth() => StaticConfig.WIDTH;
        public int GetHeight() => StaticConfig.HEIGHT;

        public Task InitializeContext(Canvas2DContext context)
        {
            _context = context;

            return Task.CompletedTask;
        }

        public async Task Display(Worlds.Drones.DroneWorld world)
        {
            await _context.BeginBatchAsync();

            await DrawBackground();

            await DrawAsteroids(world.StateToDisplay?.Asteroids);

            await DrawDroneMother(world.StateToDisplay?.DroneMother);

            await DrawDrones(world.StateToDisplay?.Drones);

            await _context.EndBatchAsync();
        }

        private async Task DrawBackground()
        {
            await _context.SetFillStyleAsync("#112233");

            await _context.FillRectAsync(0, 0, StaticConfig.WIDTH, StaticConfig.HEIGHT);
        }

        private async Task DrawAsteroids(IEnumerable<Asteroid> asteroids)
        {
            if (asteroids == null) return;

            foreach (var asteroid in asteroids) await DrawAsteroid(asteroid);
        }

        private async Task DrawAsteroid(Asteroid asteroid)
        {
            await _context.BeginPathAsync();
            await _context.ArcAsync(asteroid.Location.X, asteroid.Location.Y, 5, 0, 2 * Math.PI);
            await _context.SetFillStyleAsync("#8888ff");
            await _context.FillAsync();

            await _context.SetFontAsync("24px Roboto");
            await _context.FillTextAsync(asteroid.Ore.ToString(), asteroid.Location.X + 7, asteroid.Location.Y);
        }

        private async Task DrawDroneMother(DroneMother droneMother)
        {
            if (droneMother == null) return;

            await _context.BeginPathAsync();
            await _context.ArcAsync(droneMother.Location.X, droneMother.Location.Y, 10, 0, 2 * Math.PI);
            await _context.SetFillStyleAsync("#ffff44");
            await _context.FillAsync();
        }

        private async Task DrawDrones(IEnumerable<Drone> drones)
        {
            if (drones == null) return;

            foreach (var drone in drones) await DrawDrone(drone);
        }

        private async Task DrawDrone(Drone drone)
        {
            await _context.BeginPathAsync();
            await _context.MoveToAsync(drone.Location.X - 3, drone.Location.Y);
            await _context.LineToAsync(drone.Location.X + 3, drone.Location.Y);
            await _context.MoveToAsync(drone.Location.X, drone.Location.Y - 3);
            await _context.MoveToAsync(drone.Location.X, drone.Location.Y + 3);
            await _context.SetStrokeStyleAsync("#88ff88");
            await _context.StrokeAsync();
        }
    }
}
