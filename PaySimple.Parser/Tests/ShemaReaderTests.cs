using System;

using NUnit.Framework;

namespace PaySimple.Parser
{
    [TestFixture]
    public class ShemaReaderTests
    {
        [Test]
        public void Run()
        {
            SchemaReader.Current.Read();
        }
    }
}
