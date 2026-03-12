namespace MaPSTechTestBackUp.StepDefinitions
{
    [Binding]
    public class ProRataHolidayEntitlementStepDefinitions : PageTest
    {
        private readonly Driver _driver;
        private readonly HolidayCalculatorQuestionsPage _holidayCalculatorQuestionsPage;


        public ProRataHolidayEntitlementStepDefinitions(Driver driver)
        {
            _driver = driver;
            _holidayCalculatorQuestionsPage = new HolidayCalculatorQuestionsPage(_driver.Page);
        }

        [When(@"I enter the employment start date ""(.*)"" ""(.*)"" ""(.*)""")]
        [When(@"I enter the leave year end date ""(.*)"" ""(.*)"" ""(.*)""")]
        public async Task WhenIEnterDate(string day, string month, string year)
        {
            await _holidayCalculatorQuestionsPage.EnterDate(day, month, year);
        }

    }
}
