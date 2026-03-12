
namespace MaPSTechTestBackUp.StepDefinitions
{
    [Binding]
    public class IrregularHoursAndShiftPatternEntitlementStepDefinitions : PageTest
    {
        private readonly Driver _driver;
        private readonly HolidayCalculatorQuestionsPage _holidayCalculatorQuestionsPage;


        public IrregularHoursAndShiftPatternEntitlementStepDefinitions(Driver driver)
        {
            _driver = driver;
            _holidayCalculatorQuestionsPage = new HolidayCalculatorQuestionsPage(_driver.Page);
        }

        [When(@"I enter the ""(.*)"" by the employee")]
        public async Task WhenIEnterTheHoursWorkedByTheEmployeeAsync(string hours)
        {
            await _holidayCalculatorQuestionsPage.EnterHours(hours);
        }
    }
}
