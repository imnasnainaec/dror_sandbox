using NUnit.Framework;
using ProjectEuler;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class P694_Tests
    {
        private P694 _p694;

        [SetUp]
        public void Setup()
        {
            _p694 = new P694();
        }

        [TestCase(1)]
        [TestCase(8)]
        [TestCase(16)]
        public void cubeFull_ValueKnownCubeFull_ReturnTrue(long n)
        {
            var result = _p694.cubeFull(n);
            Assert.AreEqual(true, result);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(9)]
        [TestCase(12)]
        public void cubeFull_ValueKnownNotCubeFull_ReturnFalse(long n)
        {
            var result = _p694.cubeFull(n);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void s_ValueEquals16_Return3()
        {
            var result = _p694.s(16);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void S_ValueEquals16_Return19()
        {
            var result = _p694.S(16);
            Assert.AreEqual(19, result);
        }

        [Test]
        public void S_ValueEquals100_Return126()
        {
            var result = _p694.S(100);
            Assert.AreEqual(126, result);
        }

        [Test]
        public void S_ValueEquals10000_Return13344()
        {
            var result = _p694.S(10000);
            Assert.AreEqual(13344, result);
        }

    }
}