# Ecommerce
Synchronous MicroServices

Contains a sample Microservice for Ecommerce with an In-Memory Database.
There are 4 services in the project namely, Customers, Orders, Product and Search Microservice.

## Customer Microservice
Information Related to a Customer like Name, Email , Address etc

## Product MicroService
Information related to Product like Name, Price and Inventory

## Order Microservice
Information related to a Order which contains Order Info, Customer Id, and Product Id.

## Search Microservice
Acts as an Aggregator Service which is exposed via API. Gets Order related complete detials for a given Customer ID.
Queries all other microservices and aggregates the result and provides a Restful Response.

