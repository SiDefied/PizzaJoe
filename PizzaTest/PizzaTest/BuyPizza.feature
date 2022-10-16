Feature: BuyPizza

Open pizza portal select pizza and checkout
@Pizza
Scenario: Add Pizza and checkout
	Given that I am on pizza portal
	Then click on buy now to add pizza 
	Then increase the amount of pizza 
	Then click on checkout
	Then close browser
