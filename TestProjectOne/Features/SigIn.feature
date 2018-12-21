Feature: SigIn
	In order to sign in
	As a user already registered
	I want to see my profile site

Background: 
	Given The sign in webpage

@web
Scenario: Should see my profile after sign in
	When I complete pass and user fields
	Then I can see the account section on the top

#@web
#Scenario: I can logged out and see Sign In site
#	When I click Sign Out Button 
#	Then I can see the Sign In WebPage
#
#@web
#Scenario: I can see the alert message when is failed  sign in
#	When I complete the fields with a no registered email
#	Then I see the alert message