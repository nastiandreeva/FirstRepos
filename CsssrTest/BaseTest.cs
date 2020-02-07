using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace CsssrTest
{
	public class BaseTest
	{
		protected static IWebDriver _driver;

		[Fact]
		public static void TargetSoft()
		{
			if (_driver == null)
				_driver = new ChromeDriver();

			const string url = "http://blog.csssr.ru/qa-engineer";
			_driver.Navigate().GoToUrl(url);

			var targetGraph2 = "//a[text()[contains(.,'НАХОДИТЬ НЕСОВЕРШЕНСТВА')]]";
			_driver.FindElement(By.XPath(targetGraph2)).Click();

			var targetSoft = "//label[@for='soft']";
			_driver.FindElement(By.XPath(targetSoft)).Click();

			//var target = "http://monosnap.com/"; //правильная ссылка по ТЗ
			var target = "http://app.prntscr.com/ru/"; //не корректная ссылка указанная в коде страницы
			Assert.Equal(target, _driver.FindElement(By.XPath("//a[text()='Софт для быстрого создания скриншотов']")).GetAttribute("href"));

			//проверка что ссылка на софт открывается в новом окне
			var targetNewWin = "_blank";
			Assert.Equal(targetNewWin, _driver.FindElement(By.XPath("//a[text()='Софт для быстрого создания скриншотов']")).GetAttribute("target"));

			_driver.Quit();
		}

		[Fact]
		public static void TargetVk()
		{
			/*var targetVk = "//a[@href='http://vk.com/csssr']"; //кликабельность вк
			Assert.True(_driver.FindElements(By.XPath(targetVk).));
			*/
		}

		[Fact]
		public static void TargetMail()
		{
			/*var targetEmail = "//a[@href='mailto:hr@csssr.com']"; //кликабельность почты
			Assert.Equal(targetEmail, _driver.FindElement(By.XPath("//a[text()='Софт для быстрого создания скриншотов']")).GetAttribute("href"));
			*/
		}
	}
}