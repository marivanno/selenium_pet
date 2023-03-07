Feature: ChangeColorSchema
	In order to change color schema
	As a user
	I have to go to settings and choose color schema
	
Background: Sign In to email
	Given I am on the 'home' page
	When Login with 'valid user' from Pre-condition
	And I Accept privacy rule

Scenario Outline: Switch color schema
	Given I am on the settings page
	When I choose <color>
	Then Colors of my personal area has changed to the right <color>
	
	Examples: 
	| color |
	| Brown |
	| Green |
	| Blue  |
	| Red   |