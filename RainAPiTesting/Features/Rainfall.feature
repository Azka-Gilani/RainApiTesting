Feature: Tests for Rainfall measurements for individual station

A short summary of the feature

@tag1
Scenario: Request for rainfall measurements of individual station
	Given The user want to have rainfall measurement of station 3680
	When The user sets parameter as rainfall
	And The user includes limit parameter with limit set as 2
	And The user sends request for individaual station
	Then Api result is returned
