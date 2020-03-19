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
            Assert.AreEqual(1, result);
        }

        [Test]
        public void H_ValueEquals4_Return1()
        {
            var result = _p692.H(4);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void H_ValueEquals17_Return1()
        {
            var result = _p692.H(17);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void H_ValueEquals8_Return8()
        {
            var result = _p692.H(8);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void H_ValueEquals18_Return5()
        {
            var result = _p692.H(18);
            Assert.AreEqual(5, result);
        }

        [TestCase(-2)]
        [TestCase(-1)]
        public void H_ValueLessThan0_Return0(int value)
        {
            var result = _p692.H(value);
            Assert.AreEqual(0, result);
        }

        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void HaveWin_ValueAtMost0_ReturnFalse(int v1, int v2)
        {
            var result = _p692.HaveWin(v1, v2);
            Assert.AreEqual(false, result);
        }
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void HaveWin_SecondValueAtLeastFirst_ReturnTrue(int v1, int v2)
        {
            var result = _p692.HaveWin(v1, v2);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void G_ValueIs13_Return43()
        {
            var result = _p692.G(13);
            Assert.AreEqual(43, result);
        }
    }
}