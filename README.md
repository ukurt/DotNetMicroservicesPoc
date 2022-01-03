# .NET Microservice Core PoC

An example microservice architecture using:

* .NET 5
* Entity Framework Core
* MediatR
* RestEase
* RawRabbit
* Polly

## Business Case

We are going to build very simplified system for online shopping

## Architecture overview

* **Order Service** - create order, view orders by start and end date. \
In this service we demonstrated usage of CQRS pattern for better read/write operation isolation. This service demonstrates two ways of communication between services: synchronous REST based calls to `ProductService` and `OrderService` through HTTP Client to get the product and customer info, and asynchronous event based using RabbitMQ to publish information about newly created order to descreas stock. In this service we also access In Memory Database

* **Customer Service** - provides customer info \
In this service we also access In Memory Database and get customer info

* **Product Service** - simple product catalog. \
It provides basic information about each product.

## Running with Docker

You must install Docker & Docker Compose before. \
Scripts have been divided into two parts:

*  infra.yml runs the necessary infrastructure.
* app.yml  is used to run the application.

You can use scripts to build/run/stop/down all containers.

When you open http://localhost:5050/swagger/index.html to get orders, you can enter 01.01.2021 to startDate, 12.31.2022 to end date and you can get aggregate result from customer and product apis.

