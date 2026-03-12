# MaPSTechTest (C# + Playwright + Reqnroll + NUnit)

## Tools & Frameworks used for Automation
| Tool | Purpose | Rationale |
| --- | --- | --- |
| C# (.NET 8) | Language | I have been using c# for more than 6 years now and is an obvious choice for me to prove my programming knowledge and concepts. C# is also a strongly typed language with enterprise-level support. |
| Playwright .NET | Automation Driver | Chosen over Selenium for its auto-waiting, built-in tracing, and superior speed. It handles modern web components (shadow DOM, alerts) natively. |
| Reqnroll | BDD Framework | The modern, open-source successor to SpecFlow. It allows us to write human-readable tests while staying within the .NET ecosystem. |
| NUnit | Test Runner | An industry-standard runner for .NET. It offers powerful attributes (e.g., [Parallelizable]) and integrates perfectly with Playwright's base classes for thread-safe execution. |
| GitHub Actions | CI/CD | Facilitates Continuous Integration by running the suite on every push, ensuring the framework is "CI-ready" and not just local-only. |
| Playwright Trace Viewer | Debugging | Provides a "Forensic" playback of failures (screenshots, network logs, and DOM snapshots), which is essential for diagnosing flakiness in CI environments. |

This framework is designed not just to 'pass a test,' but to function as a production-ready regression suite. By integrating Playwright’s tracing with Reqnroll’s BDD reporting, we achieve 100% observability into the test lifecycle—satisfying both technical debugging needs and business reporting requirements.

For this to become a production-ready framework, I would integrate more comprehensie reporting tools like Allure Reporting or Extent Reporting

## Accessibility Tests
I also wrote an automated accessibility test using PlayWright to findout the accessability issues in the Chat Robot page. 

Please note that the test currenty fails as there are issues identified with the page.

An html report of this test with all the findings can be found in the below location.

```
MaPSTechTest\TestResults\AccessibilityTestReport\index.html
```

## How to run the tests locally
### Install Playwright browsers

Run the below command to install playwright browsers
```
pwsh .\bin\Debug\net8.0\playwright.ps1 install
```

### In Microsoft Visual Studio
1. Clone this repository
2. Open the solution in visual studio
3. Build
4. Run the tets using the Text Explorer Window.

### Run tests in CLI
Run the below commands to build the project and run the tests.
```
dotnet restore
dotnet build
dotnet test
```

## Artifacts
### ReqnRoll Living Documentation HTML Report
A basic html report is generated and saved to the below location at the root of the project
```
TestResults/index.html
```
### Playwright Trace Files
On failure, screenshots and Playwright traces are saved under:
```
./artifacts
```

## CI Integration
I have integrated the tests with Github Actions and created a pipeline.

The project is built, the tests are run and html report is deployed to Github pages on every push.

### Manually run tests in Github Actions
1. Click the Actions tab.
2. On the left-hand sidebar, select the "Playwright Tests" workflow.
3. You will see a blue bar with a "Run workflow" dropdown button on the right.
4. Select main branch and click "Run workflow".

## Accessibility Issue in a Bug Report Format
**Bug Title:** Missing Alternative Text for Robot Illustration

**Status:** Open

**Severity:** Critical

**Component:** Contact Page / Form Section

**Requirement:** WCAG 2.1 Success Criterion 1.1.1 (Non-text Content)

**Summary:**

The robot illustration on the chat page lacks alternative text (the alt attribute). This prevents screen reader users from understanding the purpose or visual content of the image, which results in a "Critical" impact for accessibility compliance.

**Technical Details:**

1. **Affected Code:**
```
<img class="contact-image" src="images/robot-3114245_1280.png" />
```

2. **Issue:** The \<img> element does not have an alt attribute, nor does it have a role of none or presentation.

3. **Rule Violated:** image-alt — Ensures \<img> elements have alternate text or a role of none or presentation.

**Steps to Reproduce:**

1. Navigate to the "Chat Robot" page "http://localhost:8080/index.html".

2. Inspect the robot image located within the contact-form-section div.

3. Observe the absence of an alt attribute in the HTML source code.

4. Run an automated accessibility audit (e.g., Axe) to confirm the Critical violation.

**Expected Result:**

The \<img> element should contain a meaningful alt attribute (e.g., alt="Illustration of a friendly chat robot") so that assistive technologies can communicate the image's content to users with visual impairments. Alternatively, if the image is purely decorative, it should have a null alt attribute (alt="") or role="presentation".

**Actual Result:**

The \<img> element has no alt attribute or alternative role defined. Consequently, screen readers may announce the raw file path ("robot-3114245_1280.png") or skip the element entirely, failing to provide the necessary context.