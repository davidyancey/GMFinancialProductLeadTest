Fake Store API Products Skills Test:

The purpose of this project was to display the skills of a programmer and a tester. Within the project, you will find tests broken down into three categories:
Unit Tests: These tests will utilize a MOCK of the file system and a FAKE of the rest API.
Integration Tests: This test will test only the connectivity to the API, expecting an HTTP return status of 200.
Functional Tests: These tests will follow the BDD Gherkin format, testing the full end-to-end functionality of the application.

Code Structure:

The code structure for the product is as follows:
Core: Within the core project is where you will find the interfaces, the API Manager, FileService, and extension methods. 
While the Product entity could live within the ProductDomain project, it is located in the core for future extension, where the product entity may need to be accessed outside of the product domain itself. 

Product Domain: 

This is where the product service is implemented.

Console App:

For the purpose of this skills test, the console application is not used, and there is not any functionality located within.

Solution Structure:

The solution structure follows the Onion Architecture approach with the separation of concerns and responsibilities, providing an outward => inward reference flow.
