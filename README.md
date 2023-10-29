# Customers-Web-API
Simple Web API for customers management using .NET Core

## Description
A Web API to support the management of Customers.

## How to run
    Note: the default port is 5033

    >cd CustomerManagement
    >dotnet run
    >import postman collection "CustomersManagement.postman_collection.json"
#### If port is used
    >sudo lsof -i -P | grep LISTEN | grep :5033
    >sudo kill -9 <PID>

### With dockerfile
    >cd CustomerManagement
    >docker build . -t ybichel/customerapi
    >docker run ybichel/customerapi


## Entities
- Customer
    - title NOT NULL max varchar 20
    - forename NOT NULL max varchar 50
    - surname NOT NULL max varchar 50
    - emailAddress NOT NULL max varchar 75
    - mobileNo NOT NULL max varchar 15
- Address
    - addressLine1 NOT NULL max varchar 80
    - addressLine2 NULL max varchar 80
    - town NOT NULL max varchar 50
    - country NULL max varchar 50 //If not provided default to UK
    - postcode NOT NULL max varchar 10

## Constraints
• Cannot delete the last address as a customer MUST have at least one address.
• A secondary address can become the main address, but a customer can have ONLY ONE main address.
• A customer can only exist once within the database
• A customer can have multiple addresses.

## API Functionality
• A customer can be marked as in-active if requested by the customer.
• A customer can be deleted, and all associated addresses should also be deleted
• A list of ALL customers can be returned.
• A list of INACTIVE customers can be returned.

## API
### Please use a postman collection

- Create a customer
- GET all customers
- GET all active customers
- DELETE a customer and all associated addresses
- PATCH a customer as in-active
    request body
    ```
    [     
        {       
           "op": "replace",       
           "path": "/InActive",       
           "value": true
        }
    ]
    ```
- PATCH an address as main
    request body
    ```
    [     
        {       
           "op": "replace",       
           "path": "/IsMain",       
           "value": true
        } 
    ]
    ```

## Database
- I use in-memory database
    - Constraints are not supported by database in-memory
    https://learn.microsoft.com/en-us/ef/core/testing/#inmemory-is-not-a-relational-database 


## Postman collection
- pre-request script generates random string values

## References
- https://code.visualstudio.com/docs/containers/quickstart-aspnet-core 