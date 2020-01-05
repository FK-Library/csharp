using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata1;

namespace StringCalculatorTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Add_Always_Return0ForEmptyString()
        {
            var stringCalc = new StringCalculator();
            var result = stringCalc.Add(string.Empty);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow("1",1)]
        public void Add_GivenOneNumber_ReturnsTheNumber(string values, int expected)
        {
            var stringCalc = new StringCalculator();
            var result = stringCalc.Add(values);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("1,2",3)]
        public void Add_Given2Numbers_ReturnSum(string values, int expected)
        {
            var stringCalc = new StringCalculator();
            var result = stringCalc.Add(values);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("1,2", 3)]
        [DataRow("1,2,3,4,5", 15)]
        public void Add_GivenmultipleNumbers_ReturnSum(string values, int expected)
        {
            var stringCalc = new StringCalculator();
            var result = stringCalc.Add(values);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("1\n2,3", 6)]
        public void Add_Always_AcceptNewLineAsDelimiter(string values, int expected)
        {
            var stringCalc = new StringCalculator();
            var result = stringCalc.Add(values);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("//;\n1;2", 3)]
        public void Add_Always_AcceptNewDelimiterInsideTheInput(string values, int expected)
        {
            var stringCalc = new StringCalculator();
            var result = stringCalc.Add(values);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("-1 ")]
        [DataRow("-1,1")]
        [DataRow("//;\n1;-2")]
        public void Add_Always_ThrowsExceptionForInputsLessThanZero(string values)
        {
            var stringCalc = new StringCalculator();

            Assert.ThrowsException<Exception>(()=> stringCalc.Add(values), "negatives not allowed ");
        }

        [TestMethod]
        [DataRow("-1", "negatives not allowed")]
        [DataRow("-1,-2" , "negatives not allowed -1 -2")]
        [DataRow("//;\n-1;-2", "negatives not allowed -1 -2")]
        public void Add_MultipleNegativeNumbersInInput_ThrowsExceptionWithMessageContainsNegatives(string values ,string expected)
        {
            var stringCalc = new StringCalculator();

            Assert.ThrowsException<Exception>(() => stringCalc.Add(values), expected);
        }


    }
}
