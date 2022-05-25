Feature: Search
 
As a User, I would like to search for something,
and get some results back.
 
Scenario: Cannot search when not having entered search term

Given that you have not entered a search term
Then you should not be able to search

Scenario: Should not be able to search while search is being performed

Given that you have entered a search term
When you initiate a new search
Then you cannot start another search