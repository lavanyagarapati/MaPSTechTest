namespace MaPSTechTestBackUp.Pages
{
    public class HolidayCalculatorStartPage : BasePage
    {
        public HolidayCalculatorStartPage(IPage page) : base(page) { }

        private ILocator StartButton => Page.GetByRole(AriaRole.Button, new() { Name = "Start now" });


        public async Task AssertStartButtonIsVisibleAsync()
        {
            await Assertions.Expect(StartButton).ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        public async Task ClickStart()
        {
            await StartButton.ClickAsync();
        }
    }
}
