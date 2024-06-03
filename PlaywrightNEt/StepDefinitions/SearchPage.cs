
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright;
using PlaywrightNEt.Pages;
using TechTalk.SpecFlow;
	
	namespace MyNamespace
	{
		[Binding]
		public class SearchPage
		{
			private readonly ScenarioContext _scenarioContext;
            LoginPageC LoginPageC;
            ResultsPage ResultsPage;
	
			public SearchPage(ScenarioContext scenarioContext, LoginPageC LoginPageC, ResultsPage ResultsPage)
			{
				_scenarioContext = scenarioContext;
                this.LoginPageC = LoginPageC;
                this.ResultsPage = ResultsPage;
			}

            [Given("I go to page (.*)")]
            public async Task GotoMainPage(string value)
            {
                await LoginPageC.Goto(value);
            }

             [Given("I do a search with value '(.*)'")]
            public async Task PerformASearch(string value)
            {
                await LoginPageC.Search(value);
            }

            [Then("I Validate results were retrieved")]
            public async Task ValidateResults()
            {
                ResultsPage.ValidateResults();

            }
			
		}
	}


