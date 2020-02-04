Feature: ClientPost
	In order to ensure a valid request body is posted
	As consumer of this api
	I want to be told the result of my post request

@bodyvalidation
Scenario: Missing First Name
	Given I have the following request body:
	"""
	{
		"lastName": "Smith"
	}
	"""
	When I post this request to the "Client" operation
	Then the result should be a 400 ("Bad Request") response
	And the response body description should include the following text: "The FirstNames field is required"

@bodyvalidation
Scenario: Missing Last Name
	Given I have the following request body:
	"""
	{
		"firstNames": "John"
	}
	"""
	When I post this request to the "Client" operation
	Then the result should be a 400 ("Bad Request") response
	And the response body description should include the following text: "The LastName field is required"
