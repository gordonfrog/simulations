Feature: ReleaseChange
	As a vending machine customer
	I want to release my change
	so that I do not over pay for the product

Scenario: No change back when no payment is made
	Given I have inserted 0 quarter(s)
	When I release the change
	Then I should receive 0 cents

Scenario: Get Change Back When not purchasing a product
	Given I have inserted 1 quarter(s)
	When I release the change
	Then I should receive 25 cents

Scenario: Get all my change back when not purchasing
	Given I have inserted 3 quarter(s)	
	When I release the change
	Then I should receive 75 cents

Scenario: Get Remaining Change Back when I buy a product
	Given I have inserted 3 quarter(s)
	And I purchase a product
	When I release the change
	Then I should receive 25 cents
