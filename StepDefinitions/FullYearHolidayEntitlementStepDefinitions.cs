namespace MaPSTechTestBackUp.StepDefinitions
{
    [Binding]
    public class FullYearHolidayEntitlementStepDefinitions : PageTest
    {
        private readonly Driver _driver;
        private readonly CookieBanner _cookieBanner;
        private readonly HolidayCalculatorStartPage _holidayCalculatorStartPage;
        private readonly HolidayCalculatorQuestionsPage _holidayCalculatorQuestionsPage;
        private readonly HolidayCalculatorResultPage _holidayCalculatorResultPage;


        public FullYearHolidayEntitlementStepDefinitions(Driver driver)
        {
            _driver = driver;
            _cookieBanner = new CookieBanner(_driver.Page);
            _holidayCalculatorStartPage = new HolidayCalculatorStartPage(_driver.Page);
            _holidayCalculatorQuestionsPage = new HolidayCalculatorQuestionsPage(_driver.Page);
            _holidayCalculatorResultPage = new HolidayCalculatorResultPage(_driver.Page);
        }

        [Given(@"I am on the ""Calculate your holiday entitlement"" start page")]
        public async Task GivenIAmOnTheStartPage()
        {
            await _holidayCalculatorStartPage.AssertStartButtonIsVisibleAsync();
            await _cookieBanner.RejectCookiesIfPresentAsync();
        }

        [Given(@"I click ""Start now""")]
        [When(@"I click ""Start now""")]
        public async Task IClickStartNow()
        {
            await _holidayCalculatorStartPage.ClickStart();
        }

        [Given(@"I select ""(.*)"" for irregular hours or part-year")]
        [When(@"I select ""(.*)"" for irregular hours or part-year")]
        [When(@"I select ""(.*)""")]
        [Given(@"I select ""(.*)""")]
        [Given(@"I select ""(.*)"" as the entitlement basis")]
        public async Task ISelectRadioOption(string option)
        {
            await _holidayCalculatorQuestionsPage.SelectRadioOption(option);
        }

        [Given(@"I click ""Continue""")]
        [When(@"I click ""Continue""")]
        public async Task IClickContinue()
        {
            await _holidayCalculatorQuestionsPage.ClickContinue();
        }

        [When(@"I enter ""(.*)"" as the number of days worked per week")]
        public async Task WhenIEnterAsTheNumberOfDaysWorkedPerWeek(string days)
        {
            await _holidayCalculatorQuestionsPage.EnterDaysPerWeek(days);
        }

        [Then(@"the result should be ""(.*)""")]
        public async Task ThenTheResultShouldBe(string expectedResult)
        {
            var locator = _holidayCalculatorResultPage.GetResultLocator();
            await Assertions.Expect(locator).ToContainTextAsync(expectedResult);
        }

        [Then(@"I should see the message ""(.*)""")]
        public async Task ThenIShouldSeeTheMessage(string expectedMessage)
        {
            var actualMessage = await _holidayCalculatorResultPage.GetInsetText();
            Assert.That(actualMessage, Does.Contain(expectedMessage));
        }
    }
}
