@accessibility
Feature: Accessibility Audit for Chat Robot Page

@accessibility
Scenario: Automated WCAG 2.1 AA Audit
	Given I navigate to the accessibility robot page
	Then the page should have no accessibility violations