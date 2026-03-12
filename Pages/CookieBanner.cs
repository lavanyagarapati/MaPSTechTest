namespace MaPSTechTestBackUp.Pages
{
    public class CookieBanner : BasePage
    {
        public CookieBanner(IPage page) : base(page) { }

        private ILocator Banner => Page.Locator(".gem-c-cookie-banner");
        private ILocator RejectCookiesButton => Page.GetByRole(AriaRole.Button, new() { Name = "Reject additional cookies" });
        private ILocator HideCookieMessageButton => Page.GetByRole(AriaRole.Button, new() { Name = "Hide cookie message" });


        public async Task RejectCookiesIfPresentAsync()
        {
            if (await Banner.IsVisibleAsync())
            {
                await RejectCookiesButton.ClickAsync();
                if (await HideCookieMessageButton.IsVisibleAsync())
                {
                    await HideCookieMessageButton.ClickAsync();
                }
            }
        }
    }
}
