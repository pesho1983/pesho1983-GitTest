Feature: Amexis

@test
Scenario: Check “Versant Corporation” is present on the customer page.
	Given I am on Amexis page
	When I open customer page from main page
	Then “Versant Corporation” should be present on the customer page

@test
Scenario: Check contacts form validation messages
	Given I am on Amexis page
	When I open contacts menu from main page
	And I send the form without entering information
	Then I should see validation messages