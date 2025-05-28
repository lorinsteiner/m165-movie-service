IMovieService movieService = new MovieService();

string databases = String.Join(", ", movieService.GetDatabases());
ConsoleHelper.PrintExercise("A", $"Databases: {databases}");

string collections = String.Join(", ", movieService.GetCollections());
ConsoleHelper.PrintExercise("B", collections);

