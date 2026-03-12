namespace MaPSTechTestBackUp.Drivers
{
    public class Driver
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;
        public IBrowserContext Context { get; private set; } = null!;
        public IPage Page { get; private set; } = null!;

        public async Task InitAsync(TestSettings settings)
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            var browserType = settings.Browser.ToLower() switch
            {
                "firefox" => Playwright.Firefox,
                "webkit" => Playwright.Webkit,
                _ => Playwright.Chromium
            };

            Browser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = settings.Headless,
                SlowMo = settings.SlowMo
            });

            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1280, Height = 720 }
            });

            Page = await Context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            if (Context is not null) await Context.CloseAsync();

            if (Browser is not null) await Browser.CloseAsync();

            Playwright?.Dispose();
        }
    }
}
