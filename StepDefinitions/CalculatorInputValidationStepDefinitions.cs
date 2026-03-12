namespace MaPSTechTestBackUp.StepDefinitions
{
    [Binding]
    public class CalculatorInputValidationStepDefinitions : PageTest
    {
        private readonly Driver _driver;
        private readonly HolidayCalculatorQuestionsPage _holidayCalculatorQuestionsPage;


        public CalculatorInputValidationStepDefinitions(Driver driver)
        {
            _driver = driver;
            _holidayCalculatorQuestionsPage = new HolidayCalculatorQuestionsPage(_driver.Page);
        }

        [Then(@"I should see the error message ""(.*)""")]
        public async Task ThenIShouldSeeTheErrorMessage(string expectedMessage)
        {
            await _holidayCalculatorQuestionsPage.AssertErrorMessageDisplayed(expectedMessage);
        }

        [Then(@"the page title should be ""(.*)""")]
        public async Task ThenThePageTitleShouldBe(string expectedTitle)
        {
            await _holidayCalculatorQuestionsPage.AssertSpecificPageTitle(expectedTitle);
        }

        [Then(@"I should see an error summary with the message ""(.*)""")]
        public async Task ThenIShouldSeeAnErrorSummary(string expectedMessage)
        {
            await _holidayCalculatorQuestionsPage.AssertErrorSummaryVisible(expectedMessage);
        }
    }
}
