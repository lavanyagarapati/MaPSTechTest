Feature: Calculator Input Validation
  As a user of the holiday calculator
  I want to be notified when I enter invalid information
  So that I can correct my inputs and get an accurate result

Background:
	Given I am on the "Calculate your holiday entitlement" start page
	And I click "Start now"
	And I select "No" for irregular hours or part-year
	And I click "Continue"
	And I select "days worked per week" as the entitlement basis
	And I click "Continue"

@negative
Scenario Outline: Validate error messages for invalid days per week
	When I select "for a full leave year"
	And I click "Continue"
	And I enter "<input_value>" as the number of days worked per week
	And I click "Continue"
	Then I should see the error message "<error_message>"
	And the page title should be "Error - Number of days worked per week? - Calculate holiday entitlement - GOV.UK"

Examples:
	| input_value | error_message                                                                  |
	|             | Error: There are only 7 days in a week. Please check and enter a correct value |
	|           0 | Error: There are only 7 days in a week. Please check and enter a correct value |
	|           8 | Error: There are only 7 days in a week. Please check and enter a correct value |
	| abc         | Error: There are only 7 days in a week. Please check and enter a correct value |

@negative
Scenario: Validate error for missing entitlement basis
	When I click "Continue"
	Then I should see an error summary with the message "Please answer this question"