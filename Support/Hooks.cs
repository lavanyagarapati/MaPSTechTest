using Microsoft.Extensions.Configuration;

namespace MaPSTechTestBackUp.Support
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Driver _driver;

        public Hooks(ScenarioContext scenarioContext, Driver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var settings = new TestSettings(
                BaseUrl: config["BaseUrl"] ?? "https://www.gov.uk/calculate-your-holiday-entitlement",
                Browser: config["Browser"] ?? "chromium",
                Headless: bool.Parse(config["Headless"] ?? "true"),
                SlowMo: int.Parse(config["SlowMo"] ?? "0")
            );

            await _driver.InitAsync(settings);

            await _driver.Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            await _driver.Page.GotoAsync(settings.BaseUrl);
            await _driver.Page.WaitForLoadStateAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            Directory.CreateDirectory("artifacts");

            if (_scenarioContext.TestError is not null)
            {
                var safeName = SafeFileName(_scenarioContext.ScenarioInfo.Title);
                await _driver.Page.ScreenshotAsync(new()
                {
                    Path = $"artifacts/{safeName}.png",
                    FullPage = true
                });
            }

            var traceName = SafeFileName(_scenarioContext.ScenarioInfo.Title);
            await _driver.Context.Tracing.StopAsync(new()
            {
                Path = $"artifacts/{traceName}.zip"
            });

            await _driver.DisposeAsync();
        }

        private static string SafeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name.Replace(' ', '_');
        }
    }
}
