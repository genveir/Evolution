using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Genetics
{
    public class SingleStrandGenome
    {
        private readonly bool[] _genes;

        public SingleStrandGenome(bool[] genes)
        {
            _genes = genes;
        }

        public bool this[int index] => _genes[index];

        public static SingleStrandGenome Random(int length)
        {
            var genes = new bool[length];
            
            for (int n = 0; n < length; n++)
            {
                genes[n] = Statics.Random.Next(0, 1) == 1;
            }

            return new SingleStrandGenome(genes);
        }

        public SingleStrandGenome Mutate(double mutationRate)
        {
            var newGenes = new bool[_genes.Length];
            for (int n = 0; n < _genes.Length; n++)
            {
                var doMutation = Statics.Random.NextDouble() < mutationRate;

                if (doMutation) newGenes[n] = !_genes[n];
                else newGenes[n] = _genes[n];
            }

            return new SingleStrandGenome(newGenes);
        }
    }
}
