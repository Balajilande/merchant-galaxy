using merchantgalaxy.Roman;
using System;
using Xunit;

namespace merchantgalaxyTest
{
        /// <summary>
        /// This class tests whether the Roman to Decimal conversion works as expected.
        /// </summary>
       
        public class RomanConverterTest
        {
                [Fact]
                public void TestConversion()
                {
                        RomanConverter converter = new RomanConverter();
                        Assert.Equal<double>(1944, converter.ToDecimal("MCMXLIV").Value);
                        Assert.Equal<double>(521, converter.ToDecimal("DXXI").Value);
                        Assert.Equal<double>(992, converter.ToDecimal("CMXCII").Value);
                        Assert.Equal<double>(4,converter.ToDecimal("IV").Value);
                }
        }
}
