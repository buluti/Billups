# Billups RPSLS Game 
This is the implementation of the famous Rock Paper Scissors Lizard Spock game. The game was actually invented by Sam Kass and Karen Bryla in 1995. It became popular in 2013 with The Big Bang Theory show.

The implementation is done using Clean  Architecture Concepts 

## Features implemented:

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


## Installation instructions
- Get the repo
- Check if docker-compose is set as Startup project. Set it if not.
- Run the repo

- Ports:
    - http 5000
    - https :5001

## There are 3 Endpoints:
### HealthEndpoint
#### Health
Get Api health status.

```GET: /health```

```json
  Result: application/json
    {
    	"status": "Healthy",
    	"totalDuration": "00:00:00.3625436",
    	"entries": {
    		"npgsql": {
    			"data": {},
    			"duration": "00:00:00.3083686",
    			"status": "Healthy",
    			"tags": []
    		}
    	}
    }
```    

### GameEndpoint
#### Choices
Get all the choices that are usable for the UI.

```GET: /choices```
```json
  Result: application/json
    [
    {
    “id": integer [1-5],
    "name": string [12] (rock, paper, scissors, lizard, spock)
    }
    ]
```    
#### Choice
Get a randomly generated choice.

```GET: /choice```
  ```json
Result: application/json
    {
    "id": integer [1-5],
    "name" : string [12] (rock, paper, scissors, lizard, spock)
    }
```
#### Play
Play a round against a computer opponent.

```POST: /play```

Request: application/json

```json
    {
    “player”: choice_id
    }
```


Result: application/json
  
```json
    {
    "results": string [12] (win, lose, tie),
    “player”: choice_id,
    “computer”: choice_id
    }
```
### ScoreboardEndpoit
#### Tenmostrecent
Ten Most Recent Results.

```GET /tenmostrecent```


Result: application/json

```json
[
	{
		"result": "loose",
		"player": 5,
		"computer": 4,
		"time": "Sunday, 18 February 2024"
	}
]
```
#### Reset Scoreboard
Delete all scoreboard entries.

```DELETE /reset```
```json
Result:
