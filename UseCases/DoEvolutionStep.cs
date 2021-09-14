using Entities.Abstraction;
using System;

namespace UseCases
{
    public class DoEvolutionStep
    {
        public void Mutate(IEntity entity, double mutationRate)
        {
            entity.Genome.Mutate(mutationRate);
        }
    }
}
