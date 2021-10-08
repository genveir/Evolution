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
        private readonly string _geneString;

        public SingleStrandGenome(bool[] genes)
        {
            _genes = genes;
            _geneString = new string(genes.Select(g => g ? '1' : '0').ToArray());
        }

        public bool this[int index]
        {
            get { return _genes[index]; }
            set { _genes[index] = value; }
        }

        public long Number(int startIndex, int length)
        {
            var binary = _geneString.Substring(startIndex, length);

            return Convert.ToInt64(binary, 2);
        }

        public static SingleStrandGenome Random(int length)
        {
            var genes = new bool[length];
            
            for (int n = 0; n < length; n++)
            {
                genes[n] = Statics.Random.Next(0, 2) == 1;
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
