This is the implementation of the famous Rock Paper Scissors Lizard Spock game. The game was actually invented by Sam Kass and Karen Bryla in 1995. It became popular in 2013 with The Big Bang Theory show.

The implementation is done using Clean  Architecture Concepts 

Features implemented:

- Health
- Swagger
- CQRS pattern, using MediatR
- NPGSQL postgres db
- Dockerized
- Global exception handling
- Result pattern (Error.cs, Result.cs) to implement proper error handling
- Serilog logging
- Using Typed HttpClient        
- Validation done with FluentValidation and MediatR

- Architecture tests
- Unit tests
- Integration Tests using Testcontainers library


Installation instructions
- Get the repo
- Run the repo

  ports:
    - http 5000
    - https :5001

