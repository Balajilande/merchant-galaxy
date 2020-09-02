using System;
using merchantgalaxy.Common;
using merchantgalaxy.Roman.Expressions;
using merchantgalaxy.Roman;
using Xunit;

namespace merchantgalaxyTest
{
        /// <summary>
        /// This class tests some of the expression classes that are used to identify and execute the expressions provided by the user.
        /// </summary>
      
        public class ExpressionsTest
        {
                [Fact]
                public void AliasExpressionTest()
                {
                        AliasMapper aliasMap = new AliasMapper();
                        AliasExpression expression = new AliasExpression(aliasMap);
                        Assert.True(expression.Match("glob is C"));
                        Assert.False(expression.Match("glob is N"));
                        expression.Execute("glob is C");
                        Assert.True(aliasMap.Exists("glob"));
                        Assert.Equal("C",aliasMap.GetValueForAlias("glob"));
                }

                [Fact]
                public void UnitExpressionTest()
                {
                        AliasMapper aliasMap = new AliasMapper();
                        RomanConverter converter = new RomanConverter();
                        CommodityIndex commodityIndex = new CommodityIndex();
                        aliasMap.AddAlias("glob", "C");
                        aliasMap.AddAlias("pish", "X");
                        ExpressionValidationHelper helper = new ExpressionValidationHelper(aliasMap, commodityIndex);
                        UnitExpression expression = new UnitExpression(commodityIndex, aliasMap, converter, helper);
                        expression.Execute("pish glob Iron is 7020 Credits");
                        Assert.True(commodityIndex.Exists("Iron"));
                        Assert.Equal<double>(78, commodityIndex.GetPriceByCommodity("Iron"));
                        expression.Execute("pish glob Iron is 6300 Credits");
                        Assert.Equal<double>(70, commodityIndex.GetPriceByCommodity("Iron"));
                }
        }
}
