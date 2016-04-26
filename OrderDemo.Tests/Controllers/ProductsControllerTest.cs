using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderDemo.Controllers;
using OrderDemo.Models;
using OrderDemo.Tests;
using OrderDemo.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OrderDemo.Controllers.Tests
{
	[TestClass()]
	public class ProductsControllerTests
	{
		//[TestMethod()]
		//public void ProductsControllerTest() {
		//	Assert.Fail();
		//}

		//[TestMethod()]
		//public void ProductsControllerTest1() {
		//	Assert.Fail();
		//}

		#region Via Fake

		[TestMethod()]
		[TestCategory("Fake")]
		public void Index() {
			//Arrange
			var db = new FakeOrderBaseDb();
			db.AddSet(TestData.Products);
			ProductsController controller = new ProductsController(db);
			controller.ControllerContext = new FakeControllerContext();

			//Act
			ViewResult result = controller.Index() as ViewResult;
			IEnumerable<Product> model = result.Model as IEnumerable<Product>;

			//Assert
			Assert.AreEqual(5, model.Count());
		}


		[TestMethod()]
		public void Create_Saves_Products_When_Valid() {
			var db = new FakeOrderBaseDb();
			var controller = new ProductsController(db);

			controller.Create(new Product());

			Assert.AreEqual(1, db.Added.Count);
			Assert.AreEqual(true, db.Saved);
		}

		[TestMethod]
		public void Create_Saves_Products_When_Invalid() {
			var db = new FakeOrderBaseDb();
			var controller = new ProductsController(db);
			controller.ModelState.AddModelError("", "Invalid");

			controller.Create(new Product());

			Assert.AreEqual(1, db.Added.Count);
		}

		#endregion

		#region Via Moq
		[TestMethod()]
		[TestCategory("Moq")]
		public void Index_Moq() {
			//Arrange
			var db = new Mock<IOrderBaseDb>();
			db.Setup(r => r.Query<Product>()).Returns(TestData.Products.Take(5));
			ProductsController controller = new ProductsController(db.Object);
			controller.SetFakeAuthenticatedControllerContext();

			//Act
			ViewResult result = controller.Index() as ViewResult;
			IEnumerable<Product> model = result.Model as IEnumerable<Product>;

			//Assert
			Assert.AreEqual(5, model.Count());
		}

		[TestMethod]
		public void Test_Interface_IFake() {

			//create a mock object by Moq
			var mo = new Mock<IFake>();

			mo.Setup(foo => foo.DoSomething("Ping")).Returns(true);

			Assert.AreEqual(true, mo.Object.DoSomething("Ping"));
		}

		#endregion

		[TestMethod()]
		public void DetailsTest() {
			Assert.Fail();
		}

		[TestMethod()]
		public void Create() {
			Assert.Fail();
		}

		[TestMethod()]
		public void EditTest() {
			Assert.Fail();
		}

		[TestMethod()]
		public void EditTest1() {
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest() {
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteConfirmedTest() {
			Assert.Fail();
		}
	}
}