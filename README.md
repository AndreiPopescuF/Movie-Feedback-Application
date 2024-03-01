The application contains a login form as you start it, after you have introduced your account, you can acces multiple movies within the database aswell as interogations made using SQL to retrieve key informations that a user will find useful such as:searching for the most recent movies,searching for a movie title introduced by the user,showing the movies classified by the movie type etc.
The user is allowed to modify the database adding,deleting and updating movies aswell as rating them.

Tables and Relationships Description

We will use tables for: User, Movies, Reviews, Genres, Director, and a linking table between the Movies table and Genres table named Movies_Genres.
For the specified tables, the following fields are introduced:

User: UserID (PK), First Name, Last Name, Email Address, Password.
Movies: MovieID (PK), Movie Name, GenreID (Foreign key to the Genres table), Release Year, DirectorID (Foreign key to the Director table).
Reviews: ReviewID (PK), UserID (Foreign key to the User table), MovieID (Foreign key to the Movies table), Review, Review Date.
Genres: GenreID (PK), Genre Name.
Director: DirectorID (PK), First Name, Last Name.
Movies_Genres: GenreID (Foreign key to the Genres table), MovieID (Foreign key to the Movies table).
The following relationships have been established between tables:

Many-to-Many between the Movies table and the Genres table through the Movies_Genres table.
One-to-Many between the Reviews table and the Movies table, between the Director table and the Movies table.
Many-to-One between the User table and the Reviews table.
Application Functionality
The application is written using Visual Studio in the C# programming language.
The application's opening window prompts you to enter your username and password to access the main menu.

In the main menu, we can choose whether to access the movie database or the director database.

If we select the Movies option, a new window will open displaying all existing movies in the database.

The Insert, Delete, and Update buttons help us make modifications to the database directly from the application, with functionalities suggested by their names.

Simple queries:
The "Comedy," "Horror," "Action," and "Drama" buttons help us filter existing movies by their genre.

The button labeled "Search for the Movie Director" allows us to enter the name of a movie in the text box and displays the director of that movie.

Complex queries:
The "Recent Movies" button displays the latest 5 movies.
The "Number of Movies for Each Genre" button displays the number of movies for each genre in the database.

The "Search for Movies by Genre and Year" button allows the user to filter movies by a specific genre and production year entered by them.

In the main menu, if we select the Director option, all existing directors in the database will be displayed.

The "Directors' Movies" button displays the number of movies for all directors in the database.
The "Display Movies" button allows the user to select a row representing the director and then display the movies directed by them.
