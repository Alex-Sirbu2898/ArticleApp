Article App

I have created a small app which manages the basic CRUD operations for managing Articles such as giving us the possibilty to create and update articles as well as retrive them from a database.
For this project i chose to use PostgreSQL due to it being friendly enough for even a beginner in it's setup as well as to have a scalable framework in case there was a need to add other tables other than the article one. 
The creation of the table was done through a code-first approach through EF Core and as such the data model and the configuration file are present in the solution.
The migrations were done through the NPM console and the postgres database was run locally.
I chose to use CQRS with the MediatR pattern since it gives a clean look to the code and allows me to be able to spot more easily where something might go wrong in the code as well as segregating the read, update and create operations.
The create and update commands also have validations implemented through FluentValidation and all operations give out the appropiate http status codes based on wether they were successful or not. The MediatR pattern was used through dependency injection.
A basic authorization mechanism was added with the mention that I chose to not create a separate table for the user and instead went for a mock repository since i only wanted to showcase the functionality (one valid user for testing the authorization is joydip with 
password joydip123). The authorization was only used for retrieving usernames and for the create and update article operations since I felt that retrieving the articles was something that can usually be done without authorization.
Other than basic CRUD operation I have also added a GET endpoint with basic pagination.
Some design choices were made for pure curiosity and not necessarily with performance in mind as there might be better approaches for such cases.
