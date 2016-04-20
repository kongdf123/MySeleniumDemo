using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using System.Text;
using SeleniumUnitTestProject.Common;

namespace SeleniumUnitTestProject
{
	[TestClass]
	public class SimpleSeleniumTest : TestBase
	{
		[TestMethod]
		public void FindResultsByUsingCnblogsSearch() {
			WebDriver.Navigate().GoToUrl("http://www.baidu.com");

			Assert.AreEqual("百度一下，你就知道", WebDriver.Title);

			WebDriver.FindElement(By.Id("kw")).SendKeys("Selenium");
			var listSearchResults = WebDriver.FindElements(By.CssSelector(".result.c-container"));
			Assert.IsTrue(listSearchResults.Count > 0);
			Assert.IsTrue(WebDriver.FindElements(By.XPath("//em[text()='Selenium']")).Count > 0);

			SaveScreenShot(WebDriver.Title);
		}

		/* 
		[TestMethod]
		public void TestCurrencyConvertorWithoutDDT() {
			//Read your first country currency name
			var convertVal = "American Dollar";
			//Read your second contry currency
			var inToVal = "Chinese Yuan Renminbi";
			//Read Expected value from data source
			var expectedValue = "6.480720 CNY";
			//Goto the Target website
			WebDriver.Navigate().GoToUrl("http://www.x-rates.com/calculator.html");
			Thread.Sleep(3000);

			var setValueConvert = WebDriver.FindElement(By.Name("from"));
			var setValueInto = WebDriver.FindElement(By.Name("to"));
			var calculateButton = WebDriver.FindElement(By.Name("Calculate"));
			var outPutvalue = WebDriver.FindElement(By.Name("outV"));
			var selectConvertItem = new SelectElement(setValueConvert);
			var selectIntoItem = new SelectElement(setValueInto);
			selectConvertItem.SelectByText(convertVal);
			selectIntoItem.SelectByText(inToVal);
			calculateButton.Click();
			var currencyValue = outPutvalue.GetAttribute("value");
			Thread.Sleep(900);//Not a good practise to use Sleep
							  //Get the screen shot of the web page and save it on local disk 
			SaveScreenShot(WebDriver.Title);
			Assert.AreEqual(expectedValue, currencyValue.Trim());
		}
		*/

	}
}
