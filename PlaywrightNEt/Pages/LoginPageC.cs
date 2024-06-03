using System;
using System.ComponentModel;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightNEt.Driver;
using TechTalk.SpecFlow;


namespace PlaywrightNEt.Pages
{
	[Binding]
	public class LoginPageC
	{
		IBrowser Browser;
		IPage Page;
		
		ILocator SearchField;
		ILocator SearchButton;


        public LoginPageC(WebBrowser WebBrowser, IPage Page)
		{
			this.Page = Page;
			SearchField =  Page.Locator("//textarea[@name='q']");
			SearchButton = Page.Locator("//button");
		}

		public async Task Goto(string page)
		{
			await Page.GotoAsync(page);
		}
		public async Task Search(string searchString)
		{
			await SearchField.FillAsync(searchString);
        }
	}
}

