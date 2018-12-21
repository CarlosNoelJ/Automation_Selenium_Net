Feature: Register
	As I am a User
	I want to register into the WebSite
	So I can Sign In

Background: 
	Given The sign in webpage

@web
Scenario: Account created and Signin
	When I complete all the fields
	Then I can see the account name on the top
