using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumUnitTestProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUnitTestProject.Mapper.Cnblogs
{
	public class SearchResultsPage : BasePage
	{
		public static SearchResultsPage Find() {
			return new SearchResultsPage();
		}

		By SearchBox { get; } = By.Id("txtSeach");
		By SearchButton { get; } = By.CssSelector(".btnSearch");

		By SearchResultsList { get; } = By.Id("searchResult");
		By SearchResultsItem { get; } = By.CssSelector(".forflow.searchItem");

		public SearchResultsPage AssertSearchBoxEquals(string expectedValue) {
			Assert.AreEqual(WebDriver.FindElement(SearchBox).GetAttribute("value"), expectedValue);
			return this;
		}

		public SearchResultsPage AssertSearchResultsContain(string expectedValue) {
			Assert.IsTrue(WebDriver.FindElements(By.XPath("//strong[text()='" + expectedValue + "']")).Count > 0);
			return this;
		}
	}
}
