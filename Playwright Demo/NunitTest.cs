using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

using NUnit.Framework;

using System.Threading.Tasks;

namespace Playwright_Demo
{
	public class NunitTest:PageTest
	{
		[SetUp]
		public async Task Setup()
		{
			await Page.GotoAsync("http://eaapp.somee.com/");
		}

		[Test]
		public async Task Test()
		{
			
			
			await Page.ClickAsync(selector: "text=Login");
			await Page.FillAsync(selector: "#UserName", value: "admin");
			await Page.FillAsync(selector: "#Password", value: "password");
			await Page.ClickAsync(selector: "text=Log in");
			await Expect(Page.Locator(selector: "text=Employee Details")).ToBeVisibleAsync();
		
		}
	}
}