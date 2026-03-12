using Playwright.Axe;

namespace MaPSTechTestBackUp.StepDefinitions
{
    [Binding]
    public class AccessibilityAuditForRobotPageStepDefinitions : PageTest
    {
        private readonly Driver _driver;


        public AccessibilityAuditForRobotPageStepDefinitions(Driver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to the accessibility robot page")]
        public async Task GivenINavigateToTheRobotPage()
        {
            await _driver.Page.GotoAsync("http://localhost:8080/index.html");
        }

        [Then(@"the page should have no accessibility violations")]
        public async Task ThenThePageShouldHaveNoViolations()
        {
            AxeHtmlReportOptions reportOptions = new(reportDir: "../../../TestResults/AccessabilityTestReport");
            AxeResults axeResults = await _driver.Page.RunAxe(reportOptions: reportOptions);

            Assert.That(axeResults.Violations, Is.Empty,
                $"Found {axeResults.Violations.Count} accessibility violations. " +
                $"Top issue: {axeResults.Violations.FirstOrDefault()?.Help}");
        }
    }
}
