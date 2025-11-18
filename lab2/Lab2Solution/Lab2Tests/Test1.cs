using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2Console.Part1;

namespace Lab2Tests
{
    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void SubtractionOperator_WhenUsed_ReplacesLastCharacter()
        {

            var password = new Password("password123");
            string expected = "password12X";

            var resultPassword = password - 'X';

            Assert.AreEqual(expected, resultPassword.Value);
        }

        [TestMethod]
        public void IncrementOperator_WhenUsed_ResetsToDefaultPassword()
        {

            var password = new Password("someValue");
            string expected = "defaultPassword";

            password++;

            Assert.AreEqual(expected, password.Value);
        }

        [TestMethod]
        public void ComparisonOperators_WhenComparingLength_ReturnCorrectBoolean()
        {

            var longPassword = new Password("longpassword");
            var shortPassword = new Password("short");

            Assert.IsTrue(longPassword > shortPassword);
            Assert.IsTrue(shortPassword < longPassword);
            Assert.IsFalse(shortPassword > longPassword);
        }

        [TestMethod]
        public void EqualityOperators_WhenComparingValues_ReturnCorrectBoolean()
        {

            var p1 = new Password("test");
            var p2 = new Password("test");
            var p3 = new Password("another");

            Assert.IsTrue(p1 == p2);
            Assert.IsTrue(p1 != p3);
            Assert.IsFalse(p1 == p3);
        }

        [TestMethod]
        public void TrueOperator_ForStrongPassword_EvaluatesAsTrue()
        {

            var strongPassword = new Password("StrongP@ss1");

            bool isConsideredTrue = strongPassword ? true : false;

            Assert.IsTrue(isConsideredTrue, "Стойкий пароль должен оцениваться как true.");
        }

        [TestMethod]
        public void FalseOperator_ForWeakPassword_EvaluatesAsFalse()
        {

            var weakPassword = new Password("weak");

            bool isConsideredTrue = weakPassword ? true : false;

            Assert.IsFalse(isConsideredTrue, "Слабый пароль должен оцениваться как false.");
        }
    }
}
