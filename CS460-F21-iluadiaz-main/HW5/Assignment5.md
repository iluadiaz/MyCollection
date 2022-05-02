## ID 
3
## Title
As a user I want to view all track meet data for any athlete so I can know the data has been recorded in the system, see what team the athlete is on, and easily view past results.
## Description
Build a page for viewing athlete data. The page should include the banner from the previous application pages and have a title named "Athlete Look Up" in the navbar.

1. There should be a search bar labaled "Look up an Athlete" that takes in Athlete data in the following order: Name, Team, and Coach.
2. Once that information provided is used to send a request, the athlete information should be presented to the user in chronological order based from performance dates.
3. The data presented should appear in the following order: Date, Team, Coach, Athlete, Event, and finally, Time.
4. If the requested athelete is not found, an error message should populate. The message should tell the user that the requested athlete is not found. This logic applies to invalid Team
entries and Coach entries.
5. If an improper request is made, as in the format is not followed, an error message telling the user that the request is invalid should appear. The error should be go as follows:
Error processing request, please use proper format. Name, Team, Coach, ex: Wallace Mcgee, North High School, Mr. Goku.
6. Functionality should be found on /AthleteLookUp.

## Acceptance Criteria

    Given I am on the AthleteLookUp page
    Then I will see a navbar
    And I will see a banner image
    And I will see a search bar labeled "Look up an Athlete"
    
    Given I am on the AthleteLookUp data page
    When I Submit a request with improper parameters
    Then I should see a failure message

    Given I am on the AthleteLookUp data page
    When I Submit a request with invalid data and proper parameters
    Then I should see a failure message

    Given I am on the AthleteLookUp data page
    When I Submit a valid request with valid data
    Then I should see a list of data in chronological order based on the date

    Given I am on the AthleteLookUp data page
    When I Submit a valid request with valid data, however there is no data for the athlete
    Then I should see the little available data for the athlete.

## Assumptions/Preconditions
The database has athlete information
## Dependencies
ID 1, ID 2
## Effort Points
N/A
## Owner
Ivan Lua-Diaz
## Git Feature Branch

## Modeling and Other Documents

Access to a database with athlete data.

## Tasks
1. Create a new CSHTML view page. Call it AthleteLookUp
2. Use the banner from previous pages.
3. Create a search box that accepts Name, Team, and Coach, in that format.
4. Present the requested athletes information in chronological order based from the date in a nice, organized manner. 
5. Mock the data in a mock testing project to make sure it represents the data as requested.