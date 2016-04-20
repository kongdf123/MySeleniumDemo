using OpenQA.Selenium;
using SeleniumUnitTestProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUnitTestProject.Mapper.Cnblogs
{
	public class WebPortal : BasePage
	{
		public WebPortal() {
			WebDriver.Navigate().GoToUrl(SiteAddress);
		}

		public static WebPortal Find() {
			return new WebPortal();
		}

		string SiteAddress = "http://www.cnblogs.com/";

		By LoginButton { get; } = By.LinkText("登录");
		By RegisterButton { get; } = By.LinkText("注册");

		By SearchBox { get; } = By.Id("zzk_q");
		By SearchButton { get; } = By.XPath("//input[text()='找找看']");

		By GoogleSearchBox { get; } = By.Id("google_search_q");
		By GoogleSearchButton { get; } = By.XPath("//input[value='Google']");

		public LoginPage ClickToLogin() {
			return LoginPage.Find();
		}

		public SearchResultsPage ClickToSearchInnerCnblogs() {
			return SearchResultsPage.Find();
		}

		public WebPortal GoToUrl() {
			WebDriver.Navigate().GoToUrl(SiteAddress);
			return this;
		}

		public WebPortal FillSearchBox(string expectedValue) {
			WebDriver.FindElement(SearchBox).SendKeys(expectedValue);
			return this;
		}
	}
}
