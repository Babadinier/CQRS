# Command and Query Responsability Segregation 
Greg young, 2010

## CQS 
Command returns void<br/>
Query returns non-void

## CQRS vs CQS
CQRS extends CQS with models and classes. Split models for read and write (one for read, one for write) and only use datas that they needs. 

## Benefits 
- Better scalability, better performance and simpler code.

## CRUD 
- The most operation use in CRUD is Read 

## Disadvantages of CRUD interfaces
- Too many features in a single method => increase number of bugs
- Experts' view is different than implementation (Experts don't speak in CRUD terms, ubiquitous language) 
- User interface that do multiple actions with one interface

## Task-based interface
- Each window does one thing (SRP, code base simplification, improve user experience)
- Avoid CRUD-based language like Create, Delete... Use Register for add new user for example, unregister for delete.

## Task-based interface not always the solution 
- If you just have to do CRUD operation with no complexity domain, not use Task-based interface. Task-based interface is not always the solution of all.

## How to detect if its a queries or a command ? 
- For an API, command it's PUT, POST, DELETE. GET it's a query.

## CQRS
- Client wants to do something from application -> Commands 
- Client wants to get datas from application -> Queries
- Application with external applications -> Events

- Naming guidelines : Commands -> Present like RegisterProduct, Queries -> Get like GetList, Events -> Past like RegisteredProduct (not mandatory to use suffix like RegisterProductCommand, ...)

## Commands vs DTOs
- Commands are serializable method calls and DTOs are data contracts, backward compatibility 

## Simplifying read model 
- Use Dapper rather than ORM for resolve N+1 problem query when you filter after get all lines in database
- Queries are only thin wrapper on the top of the DB (you can use Complex SQL queries, Vendor-specific features or stored procedures)

## Seperate database for queries 
- 2 databases or more with one is a Master database -> Commands database 
- If you use just one database, you can seperate database with index views
- Use ElasticSearch

## Designing database for queries 
- Regroup all tables in just one with properties needed (denormalized)

## Be carefull when you use CQRS pattern 
- If you use one database, easy to maintain. If you use two databases, you add complexity with synchronization between master and slave and users can be confuse when they write datas and not see it directly.

## Synchronizing commands and queries database 
- State-driven projection (driven by state) : Database triggers or explicit flags in the domain model (default if you control source code)
- Event-driven projection (driven by domain events) : scales really well, can use a message bus but... cannot rebuild the read database

## How to choose it ? 
- Without event sourcing => State-driven projection 
- With event sourcing => Event-driven projection