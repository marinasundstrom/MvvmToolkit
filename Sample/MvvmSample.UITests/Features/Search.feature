Feature: Search
 
As a User, I would like to search for something,
and get some results back.
 
Scenario: Cannot search when not having entered search term

Given that the Search box is empty
Then the Search button should be disabled

Scenario: Search box is disabled when searching

Given that i have entered something in the Search box
When I click the Search button
Then the Search box should be disabled 