namespace MaPSTechTestBackUp.Pages
{
    public class HolidayCalculatorQuestionsPage : BasePage
    {
        public HolidayCalculatorQuestionsPage(IPage page) : base(page) { }

        private ILocator ContinueButton => Page.GetByRole(AriaRole.Button, new() { Name = "Continue" });
        private ILocator DaysWorkedOption => Page.GetByLabel("days worked per week");
        private ILocator FullYearOption => Page.GetByLabel("for a full leave year");
        private ILocator DaysInputField => Page.GetByLabel("Number of days worked per week");
        private ILocator HoursInputField => Page.GetByLabel("How many hours has the employee worked in the pay period?");
        private ILocator DayInput => Page.GetByLabel("Day");
        private ILocator MonthInput => Page.GetByLabel("Month");
        private ILocator YearInput => Page.GetByLabel("Year");
        private ILocator ErrorSummary => Page.Locator(".govuk-error-summary");
        private ILocator FieldErrorMessage => Page.Locator(".govuk-error-message");

        public async Task SelectRadioOption(string optionText)
        {
            var option = Page.GetByLabel(optionText, new() { Exact = true });
            await option.CheckAsync();

            await Assertions.Expect(option).ToBeCheckedAsync();
        }

        public async Task ClickContinue()
        {
            await ContinueButton.ClickAsync();
        }

        public async Task SelectFullYear()
        {
            await FullYearOption.CheckAsync();
        }

        public async Task EnterDaysPerWeek(string days)
        {
            await DaysInputField.FillAsync(days);
        }

        public async Task EnterHours(string days)
        {
            await HoursInputField.FillAsync(days);
        }

        public async Task EnterDate(string d, string m, string y)
        {
            await DayInput.FillAsync(d);
            await MonthInput.FillAsync(m);
            await YearInput.FillAsync(y);
        }

        public async Task AssertSpecificPageTitle(string expectedTitle)
        {
            await Assertions.Expect(Page).ToHaveTitleAsync(expectedTitle);
        }

        public async Task AssertErrorMessageDisplayed(string expectedMessage)
        {
            await Assertions.Expect(FieldErrorMessage).ToContainTextAsync(expectedMessage);
        }

        public async Task AssertErrorSummaryVisible(string expectedMessage)
        {
            await Assertions.Expect(ErrorSummary).ToBeVisibleAsync();
            await Assertions.Expect(ErrorSummary).ToContainTextAsync(expectedMessage);
        }
    }
}
