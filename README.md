# CrystaLaw

This project is meant to provide transparency in the laws and how the legislators vote for each of them

## Table of contents (optional)

- Requirements
- How to run
- About the exercise

## Requirements (required)

This projects requires the [.NET 6.0 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) to be built

## How to run

The project should be ran using by the following line

dotnet run

## About the exercise

This section anwser the questions about the exercise:

1. Discuss your solution’s time complexity. What tradeoffs did you make?
### The solution was built aiming on an Onion architecture to keep the layers well defined and to provide extensibiity adding an API, for example, even tho the exercise was made with an console application.
Homever, to keep the things isolated I've build different service and repositories, so for each file requested in the deliverables one call was made to obtain the needed data, but in the 2nd question some of the data was already read in the 1st cache.
So, it could be improved to use some sort of cache.
I don't have much experience about time complexity, but considering the datasets involved I would guess that it's, at minimum, O(n^2).

3. How would you change your solution to account forfuture columns that might be
requested, such as “Bill Voted On Date” or“Co-Sponsors”?
### I should add these columns phisically on the code in three places: On the entities, DTOs and at the place that one's converted to other (in this case, for simplicity, on the CSV repositories creating manually the DTO's).
A more complex solution could require something like AutoMapper to makes things easier.
One good thing about it is that I've followed an convention and implemented to automatically translate the properties names (in PascalCase) to headers in CSV (in snake_case).

5. How would you change your solution if instead ofreceiving CSVs of data, you were given a
list of legislators or bills that you should generate a CSV for?
### I would create an overload of the methods that generate the data to accept a collection of items (DTO's or entities) and another method that would parse the CSV and just call the first one passing the collection. The first one could be called from another place passing the list itself.

7. How long did you spend working on the assignment?
### From 3 to 4 hours. I had some difficulties dealing with the CSV's specifically with the columns, so I had to search some solutions to dynamically translate the column headers from PascalCase to snake_case and from snake_case to PascalCase.
I started with TDD and building from the core (the domain project) and as the requirements to anwser weren't so complex, I created the services and repositories thinking on something like a SQL database, which I could solve the questions directly with an EF query, without need of manual computation, so the repository itself would return the resulting DTO, but after I implemented with the CSV's I didn't liked so much that to keep this contracts I had to access multiple CSV's inside one repository, so with time I would like to improve this.
