Feature: Irregular Hours and Shift Pattern Entitlement
  As a worker with non-standard hours
  I want to calculate my holiday in hours or shift increments
  So that my leave reflects my actual working pattern

Background:
	Given I am on the "Calculate your holiday entitlement" start page
	And I click "Start now"
	And I select "Yes" for irregular hours or part-year
	And I click "Continue"

@regression @shifts
Scenario Outline: Calculate entitlement for irregular hours
	When I enter the leave year end date "<leave_year_start_day>" "<leave_year_start_month>" "<leave_year_start_year>"
	And I click "Continue"
	And I enter the "<hours_worked>" by the employee
	And I click "Continue"
	Then I should see the message "<message>"

Examples:
	| leave_year_start_day | leave_year_start_month | leave_year_start_year | hours_worked | message                                                   |
	|                   01 |                     04 |                  2025 |            6 | The statutory entitlement for this pay period is 1 hour   |
	|                   01 |                     04 |                  2025 |           20 | The statutory entitlement for this pay period is 2 hours  |
	|                   01 |                     04 |                  2025 |          165 | The statutory entitlement for this pay period is 20 hours |