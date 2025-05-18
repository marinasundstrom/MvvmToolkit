Feature: Search
 
As a User, I would like to search for something,
and get some results back.
 
Scenario: Cannot search when not having entered search term

Given that you have not entered a search term
Then you should not be able to search

Scenario: Search box is disabled when searching

Given that I have entered something in the Search box
When I click the Search button
Then the Search box should be disabled