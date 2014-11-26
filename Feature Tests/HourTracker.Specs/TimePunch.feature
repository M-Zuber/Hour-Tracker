Feature: TimePunch
	In order to keep track of my hours
	As a worker in the company
	I want to be able to enter the times when I come and Leave
	And get the total number of hours that I worked

Scenario: Clocking in today
	Given I have entered 9 0 0 as my login time
	When I checkin
	Then the time in should be 9:00:00 am today

Scenario: Clocking in for a day other than today
	Given I have chosen 07/09/2014 as the clock in date
	And I have entered 9 0 0 as my login time
	When I checkin
	Then the time in for the date 07/09/2014 should be 9:00:00 am