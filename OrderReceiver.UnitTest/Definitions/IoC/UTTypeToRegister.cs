using NUnit.Framework;
using OrderReceiver.Definitions.IoC;
using System;

namespace OrderReceiver.UnitTest.Definitions.IoC
{
    public class UTTypeToRegister
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TypeToRegisterConstructor()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new TypeToRegister(null, null));
            Assert.IsTrue(ex != null);
            object model = null;

            model = new TypeToRegister(typeof(UTTypeToRegister), typeof(UTTypeToRegister));
            Assert.IsTrue(model != null);
        }
    }
}