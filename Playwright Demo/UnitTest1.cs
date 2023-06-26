using Microsoft.Playwright;

using NUnit.Framework;

using System.Threading.Tasks;

namespace Playwright_Demo
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task Test1()
		{
			using var playwright= await Playwright.CreateAsync();

			await using var browser=await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
			{
				Headless = false
			});

			var page=await browser.NewPageAsync();
			await page.GotoAsync("http://eaapp.somee.com/");
			await page.ClickAsync(selector: "text=Login");
			await page.ScreenshotAsync(new PageScreenshotOptions
			{
				Path = "Eapp.png"
			});

			await page.FillAsync(selector: "#UserName", value: "admin");
			await page.FillAsync(selector: "#Password", value: "password");
			await page.ClickAsync(selector: "text=Log in");
			var isExist=await page.Locator(selector: "text=Employee Details").IsVisibleAsync();

			Assert.IsTrue(isExist);


		}
	}
}