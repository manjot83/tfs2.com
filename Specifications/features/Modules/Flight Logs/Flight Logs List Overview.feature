Feature: A list of flight logs that a user can see.
	So that a user can edit existing, or create new flight logs.
	
Scenario: View the list of flight logs with specific columns
	Given I have logged on
	When I click the "Flight Logs" navigation button
	Then I should be on the "Flight Logs" page
	And I should see a list with the following columns:
	| name     | sortable |
	| Date     | yes      |
	| Aircraft | yes      |
	| Program  | yes      |
	| Location | yes      |
	| Reports  | no       |
	
Scenario: A button should exist to create new flight logs
	Given I have logged on
	When I click the "Flight Logs" navigation button
	Then I should be on the "Flight Logs" page
	And I should see a "Create a flight log" button
