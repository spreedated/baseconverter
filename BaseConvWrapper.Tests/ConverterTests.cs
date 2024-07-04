namespace BaseConvWrapper.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        [TestCase(23, "17", "27", "10111")]
        [TestCase(4096, "1000", "10000", "1000000000000")]
        [TestCase(0, "0", "0", "0")]
        [TestCase(255, "ff", "377", "11111111")]
        [TestCase(1024, "400", "2000", "10000000000")]
        public void FromDecimalTests(long input, string hexValue, string octValue, string binValue)
        {
            BaseConverter bc = BaseConverter.FromDecimal(input);

            Assert.Multiple(() =>
            {
                Assert.That(bc.Decimal, Is.EqualTo(input));
                Assert.That(bc.Hexadecimal, Is.EqualTo(hexValue));
                Assert.That(bc.Octal, Is.EqualTo(octValue));
                Assert.That(bc.Binary, Is.EqualTo(binValue));
            });
        }

        [Test]
        [TestCase("17", 23, "27", "10111")]
        [TestCase("1000", 4096, "10000", "1000000000000")]
        [TestCase("0", 0, "0", "0")]
        [TestCase("ff", 255, "377", "11111111")]
        [TestCase("400", 1024, "2000", "10000000000")]
        public void FromHexadecimalTests(string input, long decValue, string octValue, string binValue)
        {
            BaseConverter bc = BaseConverter.FromHexadecimal(input);

            Assert.Multiple(() =>
            {
                Assert.That(bc.Decimal, Is.EqualTo(decValue));
                Assert.That(bc.Hexadecimal, Is.EqualTo(input));
                Assert.That(bc.Octal, Is.EqualTo(octValue));
                Assert.That(bc.Binary, Is.EqualTo(binValue));
            });
        }

        [Test]
        [TestCase(27, 23, "17", "10111")]
        [TestCase(10000, 4096, "1000", "1000000000000")]
        [TestCase(0, 0, "0", "0")]
        [TestCase(377, 255, "ff", "11111111")]
        [TestCase(2000, 1024, "400", "10000000000")]
        public void FromOctalTests(long input, long decValue, string hexValue, string binValue)
        {
            BaseConverter bc = BaseConverter.FromOctal(input);

            Assert.Multiple(() =>
            {
                Assert.That(bc.Decimal, Is.EqualTo(decValue));
                Assert.That(bc.Hexadecimal, Is.EqualTo(hexValue));
                Assert.That(bc.Octal, Is.EqualTo(input.ToString()));
                Assert.That(bc.Binary, Is.EqualTo(binValue));
            });
        }

        [Test]
        [TestCase(10111, 23, "17", "27")]
        [TestCase(1000000000000, 4096, "1000", "10000")]
        [TestCase(0, 0, "0", "0")]
        [TestCase(11111111, 255, "ff", "377")]
        [TestCase(10000000000, 1024, "400", "2000")]
        public void FromBinaryTests(long input, long decValue, string hexValue, string octValue)
        {
            BaseConverter bc = BaseConverter.FromBinary(input);

            Assert.Multiple(() =>
            {
                Assert.That(bc.Decimal, Is.EqualTo(decValue));
                Assert.That(bc.Hexadecimal, Is.EqualTo(hexValue));
                Assert.That(bc.Octal, Is.EqualTo(octValue));
                Assert.That(bc.Binary, Is.EqualTo(input.ToString()));
            });
        }


        [TearDown]
        public void TearDown()
        {

        }
    }
}
