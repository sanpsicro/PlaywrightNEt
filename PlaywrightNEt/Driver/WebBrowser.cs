using System;
using BoDi;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace PlaywrightNEt.Driver
{
	[TestFixture]
	public class WebBrowser
	{
	    public IBrowser Browser;
		
		public WebBrowser(IObjectContainer objectContainer)
		{
			 var plwrght = Task.Run(()=>Playwright.CreateAsync()).Result;
			 this.Browser = Task.Run(()=>plwrght.Chromium.LaunchAsync(new() { Headless = false })).Result;
			 objectContainer.RegisterInstanceAs<IPage>(Task.Run(()=>Browser.NewPageAsync()).Result);
			
		}

		[SetUp]
		public async Task CreateBrowser(BrowserType browserType)
		{
			switch(browserType)
				{
				default:
                case BrowserType.Chrome:
                    var plwrght = await  Playwright.CreateAsync();
					var browser = await plwrght.Chromium.LaunchAsync(new() { Headless = false });
					
                    Browser =  browser;
					break;
				
			}


		}

		[TearDown]
		public async Task TearDown()
		{
			Browser.CloseAsync();
		}


		public enum BrowserType
		{
			Chrome,
			Firefox

		}
	}
}

