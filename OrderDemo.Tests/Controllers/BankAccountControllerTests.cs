using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderDemo.Models;
using System;

namespace OrderDemo.Controllers.Tests
{
	[TestClass()]
	public class BankAccountControllerTests
	{
		[TestMethod()]
		public void Index() {
			
			Assert.Fail();
		}
		
		// unit test code
		[TestMethod]
		public void Debit_WithValidAmount_UpdatesBalance() {
			// arrange
			double beginningBalance = 11.99;
			double debitAmount = 4.55;
			double expected = 7.44;
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// act
			account.Debit(debitAmount);

			// assert
			double actual = account.Balance;
			Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
		}

		//unit test method
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() {
			// arrange
			double beginningBalance = 11.99;
			double debitAmount = -100.00;
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// act
			account.Debit(debitAmount);

			// assert is handled by ExpectedException
			// act
			try {
				account.Debit(debitAmount);
			}
			catch (ArgumentOutOfRangeException e) {
				// assert
				StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
			}
		}

		[TestMethod]
		public void Index_AjaxRequest_Returns_Partial_With_Expense_List() {
			//// Arrange  
			//Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
			//Mock<HttpResponseBase> response = new Mock<HttpResponseBase>();
			//Mock<HttpContextBase> context = new Mock<HttpContextBase>();

			//context.Setup(c => c.Request).Returns(request.Object);
			//context.Setup(c => c.Response).Returns(response.Object);
			////Add XMLHttpRequest request header
			//request.Setup(req => req["X-Requested-With"]).
			//	Returns("XMLHttpRequest");

			//IEnumerable<BankAccount> fakeExpenses = GetMockExpenses();
			//expenseRepository.Setup(x => x.GetMany(It.
			//	IsAny<Expression<Func<Expense, bool>>>())).
			//	Returns(fakeExpenses);
			//ExpenseController controller = new ExpenseController(
			//	commandBus.Object, categoryRepository.Object,
			//	expenseRepository.Object);
			//controller.ControllerContext = new ControllerContext(
			//	context.Object, new RouteData(), controller);
			//// Act
			//var result = controller.Index(null, null) as PartialViewResult;
			//// Assert
			//Assert.AreEqual("_ExpenseList", result.ViewName);
			//Assert.IsNotNull(result, "View Result is null");
			//Assert.IsInstanceOf(typeof(IEnumerable<BankAccount>),
			//		result.ViewData.Model, "Wrong View Model");
			//var expenses = result.ViewData.Model as IEnumerable<BankAccount>;
			//Assert.AreEqual(3, expenses.Count(),
			//	"Got wrong number of Categories");
		}
	}
}