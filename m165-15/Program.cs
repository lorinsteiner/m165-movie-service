IMovieService movieService = new MovieService();

string databases = String.Join(", ", movieService.GetDatabases());
ConsoleHelper.PrintExercise("A", $"Databases: {databases}");

string collections = String.Join(", ", movieService.GetCollections());
ConsoleHelper.PrintExercise("B", collections);

string? firstMovieFrom2012 = movieService.GetMovieEquals(movie => movie.Year, 2012)?.Title;
ConsoleHelper.PrintExercise("C", $"Filme aus Jahr 2012 (FirstOrDefault): {firstMovieFrom2012}");
Console.WriteLine(movieService.GetMovies(movie => movie.Year == 2012).First().Title);

ConsoleHelper.PrintExercise("D",
            "Filme mit Pierce Brosnan (Liste)",
            [.. movieService.GetMoviesContainActor(["Pierce Brosnan"])
            .Select(movie => movie.Title)]);

Movie newMovie = new ("The Da Vinci Code", 2006, "So dunkel ist der Betrug an der Menschheit", ["Tom Hanks", "Audrey Tatou"]);
movieService.InsertMovie(newMovie);
ConsoleHelper.PrintExercise("E", $"Movie Inserted: {newMovie.Title} {newMovie.Id}");

List<Movie> newMovies = [new ("Ocean's Eleven", 2001, "Bist du drin oder draussen?", ["George Clooney", "Brad Pitt", "Julia Roberts"]),
                        new ("Ocean's Twelve", 2004, "Die Elf sind jetzt Zwölf.", ["George Clooney", "Brad Pitt", "Julia Roberts", "Andy Garcia"])];
movieService.InsertMovies(newMovies);
ConsoleHelper.PrintExercise("F", "Movies Inserted", [.. newMovies.Select(movie => $"{movie.Title} {movie.Id}")]);

long numberOfUpdated = movieService.UpdateMovies(movie => movie.Title == "Skyfall - 007", "title", "Skyfall");
ConsoleHelper.PrintExercise("G", $"Update 'Skyfall - 007 -> 'Skyfall' (Anzahl): {numberOfUpdated}");

long numberOfDeleted = movieService.DeleteMovies(movie => movie.Year <= 1995);
ConsoleHelper.PrintExercise("H", $"Delete Year <= 1995 (Anzahl): {numberOfDeleted}");

// ImmutableSortedDictionary<int?, int> groupedMovies = movieService.GetNumberOfMoviesPerYear(_ => true);
// ConsoleHelper.PrintExercise("I (Zusatzaufgabe):", "Filme pro Jahr ab 2000", [.. groupedMovies.Select(pair => $"{pair.Key} {pair.Value}")]);

