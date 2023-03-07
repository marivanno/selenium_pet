Feature: SendEmail
	In order to send email
	As a user
	I have to go Sign in, write and send new email

Background: Sign In to email
	Given I am on the 'home' page
	When Login with 'valid user' from Pre-condition
	And I Accept privacy rule
	And I close window to make mail.ru default page
	And I write email with uniq email, subject and body
	And I click send email button
	And I close Pup up window
	Then Pop up window is closed
	
Scenario: Email is in sent folder
	Given I am in personal area page
	When I click to sent folder button
	Then Draft folder contains expected email