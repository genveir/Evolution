using NUnit.Framework;
using System;

namespace Genetics
{
    public class SingleStrandGenomeTests
    {
        [Test]
        public void SingleStrandGenomeMutateAt0FlipsNoBool()
        {
            var genome = new SingleStrandGenome(new bool[100]);

            var mutated = genome.Mutate(0.0d);

            for (int n = 0; n < 100; n++) Assert.That(!mutated[n]);
        }

        [TestCase(0.5d, 4000, 6000)]
        [TestCase(0.1d, 0, 2000)]
        [TestCase(0.9d, 8000, 10000)]
        public void SingleStrandGenomeMutatesAtAboutTheRightRate(double rate, int min, int max)
        {
            var genome = new SingleStrandGenome(new bool[10000]);

            var mutated = genome.Mutate(rate);

            int numFlipped = 0;
            for (int n = 0; n < 10000; n++) if (mutated[n]) numFlipped++;

            Assert.Greater(numFlipped, min);
            Assert.Less(numFlipped, max);
        }

        [Test]
        public void SingleStrandGenomeMutateAt1FlipsEveryBool()
        {
            var genome = new SingleStrandGenome(new bool[100]);

            var mutated = genome.Mutate(1.0d);

            for (int n = 0; n < 100; n++) Assert.That(mutated[n]);
        }

        [Test]
        public void RandomSingleStrandGenomeIsAboutRandom()
        {
            var genome = SingleStrandGenome.Random(10000);

            int numTrue = 0;
            for (int n = 0; n < 10000; n++) if (genome[n]) numTrue++;

            Assert.Greater(numTrue, 4000);
            Assert.Less(numTrue, 6000);
        }
    }
}
