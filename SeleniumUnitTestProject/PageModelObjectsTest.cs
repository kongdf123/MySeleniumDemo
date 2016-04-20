using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumUnitTestProject.Common;
using OpenQA.Selenium;
using SeleniumUnitTestProject.Mapper.Cnblogs;

namespace SeleniumUnitTestProject
{
	[TestClass]
	public class PageModelObjectsTest : TestBase
	{
		[TestMethod]
		public void CnblogsSearch() {

			WebPortal.Find()
				.FillSearchBox(expectedValue: "Selenium")
				.ClickToSearchInnerCnblogs()

				.AssertSearchBoxEquals(expectedValue: "Selenium")
				.AssertSearchResultsContain(expectedValue: "Selenium")
				;

			SaveScreenShot(WebDriver.Title);
		}
	}
}
