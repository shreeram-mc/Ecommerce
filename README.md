# Ecommerce
Synchronous MicroServices

Contains a set of sample Microservices for Ecommerce with an In-Memory Database.
There are 4 services in the project namely, Customers, Orders, Product and Search Microservice.
Use the Docker Repos mentioned below to get started.

## Customer Microservice
Information Related to a Customer like Name, Email , Address etc

Docker: `docker pull urshree/ecommerceapicustomers`

## Product MicroService
Information related to Product like Name, Price and Inventory

Docker: `docker pull urshree/ecommerceapiproducts`

## Order Microservice
Information related to a Order which contains Order Info, Customer Id, and Product Id.

Docker: `docker pull urshree/ecommerceapiorders`

## Search Microservice
Acts as an Aggregator Service which is exposed via API. Gets Order related complete details for a given Customer ID.
Queries all other microservices and aggregates the result and provides a Restful Response.

Docker: `docker pull urshree/ecommerceapisearch`

> To Setup the code for debugging, use VS Code or Visual Studio 2019

Clone - `git clone https://github.com/urshree/Ecommerce.git`

From the project root directory run `docker-compose up -d`

