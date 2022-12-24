Feature: Buy A Product
	As a thristy vending machine customer
	I want to buy a product
	So that I can quench my thirst

Scenario: Buy a product from the vending machine with money
	Given I have inserted 2 quarter(s) 	
	When I purchase a product
	Then I should receive the product

Scenario: Buy a product from the vending machine without money
	Given I have inserted 0 quarter(s) 	
	When I purchase a product
	Then I should not receive a product
