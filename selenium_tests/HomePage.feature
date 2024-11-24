Feature: Innovition test

@footerBtM
Scenario: Innovition testing : footer, contact information, header menus
    Given I validate the footer
    Then I verify the Innovition logo is displayed
    Then I verify the top header menus is displayed
    Then I verify the secondary header menus is displayed
    Then I verify the secondary header is sticky
    Then I verify the contact information is displayed