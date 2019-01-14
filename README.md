##Command and Query Responsability Segregation 
Greg young, 2010

##CQS 
Command returns void
Query returns non-void

##CQRS vs CQS
CQRS extends CQS with models and classes. Split models for read and write (one for read, one for write) and only use datas that they needs. 

##Benefits 
- Better scalability, better performance and simpler code.

##Disadvantages of CRUD interfaces
- Too many features in a single method => increase number of bugs
- Experts' view is different than implementation (Experts don't speak in CRUD terms, ubiquitous language) 
- User interface that do multiple actions with one interface

##Task-based interface
- Each window does one thing (SRP, code base simplification, improve user experience)
- Avoid CRUD-based language like Create, Delete... Use Register for add new user for example, unregister for delete.

##Task-based interface not always the solution 
- If you just have to do CRUD operation with no complexity domain, not use Task-based interface. Task-based interface is not always the solution of all.

##How to detect if its a queries or a command ? 
- For an API, command it's PUT, POST, DELETE. GET it's a query.