using NUnit.Framework;
using ProjectEuler;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class P650_Tests
    {
        private P650 _p650;

        [SetUp]
        public void Setup()
        {
            _p650 = new P650();
        }

        [TestCase(5,2500)]
        public void B_ValueEqualsA_ReturnB(int A, long B)
        {
            var result = _p650.B(A);
            Assert.AreEqual(B, result);
        }

        [TestCase(5,5467)]
        public void D_ValueEqualsA_ReturnB(int A, long B)
        {
            var result = _p650.D(A);
            Assert.AreEqual(B, result);
        }

        [TestCase(5,5736)]
        [TestCase(10,141740594713218418 )]
        public void S_ValueEqualsA_ReturnB(int A, long B)
        {
            var result = _p650.S(A);
            Assert.AreEqual(B, result);
        }

        [TestCase(100,1000000007,332792866)]
        public void SmodM_ValueEqualsA_ReturnB(int A, long M, long B)
        {
            var result = _p650.SmodM(A, M);
            Assert.AreEqual(B, result);
        }

    }
}