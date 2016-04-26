using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
	[TestClass]
	public class CalculatorTests
	{
		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the 
		///current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		[TestMethod]
		[TestCategory("SimpleMatch")]
		//[Ignore]
		public void AddSimple() {
			var calculator = new Calculator();
			int sum = calculator.Add(1, 2);
			Assert.AreEqual(3, sum);
		}

		[TestMethod]
		[TestCategory("SimpleMatch")]
		[Priority(0)]
		public void DivideSimple() {
			var calculator = new Calculator();
			int quotient = calculator.Divide(10, 5);
			Assert.AreEqual(0, quotient);
		}

		[TestMethod]
		[TestCategory("Exceptions")]
		[ExpectedException(typeof(DivideByZeroException))]
		[Priority(1)]
		public void DivideByZero() {
			var calculator = new Calculator();
			calculator.Divide(10, 0);
		}

		/// <summary>
		///Initialize() is called once during test execution before
		///test methods in this test class are executed.
		///</summary>
		[TestInitialize()]
		public void Initialize() {
			//  TODO: Add test initialization code
		}

		/// <summary>
		///Cleanup() is called once during test execution after
		///test methods in this class have executed unless
		///this test class' Initialize() method throws an exception.
		///</summary>
		[TestCleanup()]
		public void Cleanup() {

			//  TODO: Add test cleanup code
		}
	}
}
