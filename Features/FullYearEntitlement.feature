Feature: Full Year Holiday Entitlement
  As a worker or employer
  I want to calculate the statutory holiday entitlement for a full leave year
  So that I can ensure the correct amount of leave is allocated

Background:
	Given I am on the "Calculate your holiday entitlement" start page
	And I click "Start now"
	And I select "No" for irregular hours or part-year
	And I click "Continue"
	And I select "days worked per week" as the entitlement basis
	And I click "Continue"

@regression @happy-path
Scenario Outline: Calculate entitlement for standard days worked per week
	When I select "for a full leave year"
	And I click "Continue"
	And I enter "<days_per_week>" as the number of days worked per week
	And I click "Continue"
	Then the result should be "<expected_result>"

Examples:
	| days_per_week | expected_result   |
	|             5 | 28 days holiday   |
	|             4 | 22.4 days holiday |
	|             1 | 5.6 days holiday  |

@regression @boundary
Scenario: Statutory holiday is capped at 28 days
	When I select "for a full leave year"
	And I click "Continue"
	And I enter "6" as the number of days worked per week
	And I click "Continue"
	Then the result should be "28 days holiday"
	And I should see the message "Even though more than 5 days a week are worked, the maximum statutory holiday entitlement is 28 days."