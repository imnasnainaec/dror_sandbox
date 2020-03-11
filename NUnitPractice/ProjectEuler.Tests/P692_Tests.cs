using NUnit.Framework;
using ProjectEuler;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class P692_Tests
    {
        private P692 _p692;

        [SetUp]
        public void Setup()
        {
            _p692 = new P692();
        }

        [Test]
        public void H_ValueEquals1_Return1()
        {
            var result = _p692.H(1);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void H_ValueEquals4_Return1()
        {
            var result = _p692.H(4);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void H_ValueEquals17_Return1()
        {
            var result = _p692.H(17);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void H_ValueEquals8_Return8()
        {
            var result = _p692.H(8);
            Assert.AreEqual(result, 8);
        }

        [Test]
        public void H_ValueEquals18_Return5()
        {
            var result = _p692.H(18);
            Assert.AreEqual(result, 5);
        }

        [TestCase(-2)]
        [TestCase(-1)]
        public void H_ValueLessThan0_Return0(int value)
        {
            var result = _p692.H(value);
            Assert.AreEqual(result, 0);
        }
    }
}