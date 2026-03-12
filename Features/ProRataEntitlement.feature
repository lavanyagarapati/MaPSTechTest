Feature: Pro-Rata Holiday Entitlement
  As a worker starting or leaving a job mid-year
  I want to calculate my pro-rata holiday entitlement
  So that I receive the correct leave for the portion of the year worked

Background:
	Given I am on the "Calculate your holiday entitlement" start page
	And I click "Start now"
	And I select "No" for irregular hours or part-year
	And I click "Continue"
	And I select "days worked per week" as the entitlement basis
	And I click "Continue"

@complex-logic @regression
Scenario Outline: Calculate pro-rata leave for starting part-way through a year
	When I select "for someone starting part way through a leave year"
	And I click "Continue"
	And I enter the employment start date "<employment_start_day>" "<employment_start_month>" "<employment_start_year>"
	And I click "Continue"
	And I enter the leave year end date "<leave_year_start_day>" "<leave_year_start_month>" "<leave_year_start_year>"
	And I click "Continue"
	And I enter "<days_per_week>" as the number of days worked per week
	And I click "Continue"
	Then the result should be "<expected_result>"

Examples:
	| employment_start_day | employment_start_month | employment_start_year | leave_year_start_day | leave_year_start_month | leave_year_start_year | days_per_week | expected_result   |
	|                   01 |                     06 |                  2025 |                   01 |                     04 |                  2025 |             5 | 23.5 days holiday |
	|                   01 |                     01 |                  2026 |                   01 |                     04 |                  2025 |             5 | 7 days holiday    |
	|                   15 |                     08 |                  2025 |                   01 |                     04 |                  2025 |             3 | 11.5 days holiday |