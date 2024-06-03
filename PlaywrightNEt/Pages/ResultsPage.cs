
using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightNEt.Driver;
using TechTalk.SpecFlow;


[Binding]
public class ResultsPage
{

IPage Page;
ILocator ResultsList;

public ResultsPage(WebBrowser WebBrowser, IPage Page)
{
    ResultsList = Page.Locator("//div[@data-snc]");
}

public async Task ValidateResults()
{
   await Task.Delay(TimeSpan.FromSeconds(5));
   Assert.That(await ResultsList.IsEnabledAsync());

}

}