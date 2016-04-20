using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUnitTestProject.Common
{
	public class BasePage
	{
		IUnityContainer container = new UnityContainer();
		protected IWebDriver WebDriver {
			get { return container.Resolve<IWebDriver>(); }
		}
	}
}
