using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Text;
using Microsoft.Practices.Unity;

namespace SeleniumUnitTestProject.Common
{
	[TestClass]
	public abstract class TestBase
	{
		protected static IWebDriver WebDriver;

		[TestInitialize]
		public virtual void Initialize() {
			WebDriver = new ChromeDriver();
			IUnityContainer container = new UnityContainer();
			container.RegisterInstance(typeof(IWebDriver), WebDriver);
		}

		[TestCleanup]
		public virtual void Cleanup() {
			WebDriver.Quit();
		}

		/// <summary>
		/// This will Take the screen shot of the webpage and will save it at particular location
		/// </summary>
		/// <param name = "screenshotFirstName" ></ param >
		protected static void SaveScreenShot(string screenshotFirstName) {
			var folderLocation = Environment.CurrentDirectory.Replace("Out", "\\ScreenShot\\");
			if (!Directory.Exists(folderLocation)) {
				Directory.CreateDirectory(folderLocation);
			}
			var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
			var filename = new StringBuilder(folderLocation);
			filename.Append(screenshotFirstName);
			filename.Append(DateTime.Now.ToString("dd-mm-yyyy HH_mm_ss"));
			filename.Append(".png");
			screenshot.SaveAsFile(filename.ToString(), System.Drawing.Imaging.ImageFormat.Png);
		}

	}
}
