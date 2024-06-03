Feature: Search tests

Scenario: Perform a search 
    Given I go to page https://www.google.com
    And I do a search with value 'search value'
    Then I Validate results were retrieved
    