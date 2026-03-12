namespace MaPSTechTestBackUp.Pages
{
    public class HolidayCalculatorResultPage : BasePage
    {
        public HolidayCalculatorResultPage(IPage page) : base(page) { }

        private ILocator ResultHeading => Page.Locator(".summary");
        private ILocator StatutoryCapMessage => Page.Locator(".govuk-govspeak > p").First;

        public async Task<string> GetResultText()
        {
            return await ResultHeading.InnerTextAsync();
        }

        public async Task<string> GetInsetText()
        {
            return await StatutoryCapMessage.InnerTextAsync();
        }

        public ILocator GetResultLocator()
        {
            return ResultHeading;
        }
    }
}
