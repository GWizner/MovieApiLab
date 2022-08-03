using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApiLab.Models;

namespace MockAssessment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        MovieDB DB = new MovieDB();

        [Route("AllMovies")]
        public Movie[] GetAllMovies()
        {
          return DB.Movies.OrderBy(x => x.Title).ToArray();
            
        }

        [Route("MoviesOfCategory")]
        public ApiResponse<Movie[]> GetAllMoviesOfCategory(string movieCategory)
        {
            var apiResponse = new ApiResponse<Movie[]>();
            apiResponse.succeeded = false;
            try
            {
                Movie targetMovieCategory = null;
                var myList = new List<Movie>();
                foreach (var currMovie in DB.Movies)
                {
                    if (currMovie.Category.Equals(movieCategory, StringComparison.CurrentCultureIgnoreCase))
                    {
                        myList.Add(currMovie);
                    }
                }
                if (myList.Count > 0)
                {
                    apiResponse.data = myList.ToArray();
                    apiResponse.succeeded = true;
                }
                else
                {
                    apiResponse.errorMessage = $"Could not find a movie category called {movieCategory}";
                    apiResponse.errorCode = 2;
                }
            }
            catch
            {
                // Ignore
            }
            return apiResponse;
        }

        [Route("RandomMovie")]
        public Movie[] GetRandomMovie()
        {
            var rnd = new Random();
            var randomMovie = DB.Movies.OrderBy(x => rnd.Next()).Take(1);
            return randomMovie.ToArray();
        }

        [Route("RandomMoviePick")]
        public ApiResponse<Movie[]> GetRandomMovieOfCategory(string movieCategory)
        {
            var apiResponse = new ApiResponse<Movie[]>();
            apiResponse.succeeded = false;
            try
            {
                Movie targetMovieCategory = null;
                var myList = new List<Movie>();
                foreach (var currMovie in DB.Movies)
                {
                    if (currMovie.Category.Equals(movieCategory, StringComparison.CurrentCultureIgnoreCase))
                    {
                        myList.Add(currMovie);
                    }
                }
                if (myList.Count > 0)
                {
                    var rnd = new Random();
                    var randomMovie = myList.OrderBy(x => rnd.Next()).Take(1);
                    apiResponse.data = randomMovie.ToArray();
                    apiResponse.succeeded = true;
                }
                else
                {
                    apiResponse.errorMessage = $"Could not find a movie category called {movieCategory}";
                    apiResponse.errorCode = 2;
                }
            }
            catch
            {
                // Ignore
            }
            return apiResponse;
        }

        [Route("RandomMovieList")]
        public Movie[] GetRandomMovieList(int NoOfMovies)
        {
            var rnd = new Random();
            var randomMovieList = DB.Movies.OrderBy(x => rnd.Next()).Take(NoOfMovies);
            return randomMovieList.ToArray();
        }


        [Route("AllCategories")]
        public Movie[] GetAllMovieCategories(string thisCategory)
        {
            var categoriesList = new List<Movie>();
            
            foreach (var currCategory in DB.Movies)
            {
                if (currCategory.Category == thisCategory) 
                    categoriesList.Add(currCategory);
            }
            return categoriesList.ToArray();
        }
        [Route("SpecificMovie")]
        public ApiResponse<Movie[]> GetSpecificMovie(string thisMovie)
        {
            var apiResponse = new ApiResponse<Movie[]>();
            apiResponse.succeeded = false;
            try
            {
                var myList = new List<Movie>();
                foreach (var currMovie in DB.Movies)
                {
                    if (currMovie.Title.Equals(thisMovie, StringComparison.CurrentCultureIgnoreCase))
                    {
                        myList.Add(currMovie);
                        break;
                    }
                }
                if (myList.Count > 0)
                {
                    apiResponse.data = myList.ToArray();
                    apiResponse.succeeded = true;
                }
                else
                {
                    apiResponse.errorMessage = $"Could not find a movie called {thisMovie}";
                    apiResponse.errorCode = 2;
                }
            }
            catch
            {
                // Ignore
            }
            return apiResponse;
        }

        [Route("MoviesWithName")]
        public ApiResponse<Movie[]> GetAllMoviesWithName(string movieName)
        {
            var apiResponse = new ApiResponse<Movie[]>();
            apiResponse.succeeded = false;
            try
            {
                Movie targetMovieName = null;
                var myList = new List<Movie>();
                foreach (var currMovie in DB.Movies)
                {
                    if (currMovie.Title.Contains(movieName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        myList.Add(currMovie);
                    }
                }
                if (myList.Count > 0)
                {
                    apiResponse.data = myList.ToArray();
                    apiResponse.succeeded = true;
                }
                else
                {
                    apiResponse.errorMessage = $"No movie titles contain {movieName}";
                    apiResponse.errorCode = 2;
                }
            }
            catch
            {
                // Ignore
            }
            return apiResponse;
        }
        public class ApiResponse<T>
        {
            public bool succeeded { get; set; }
            public int errorCode { get; set; }
            public string errorMessage { get; set; }
            public T data { get; set; }
        }
    }
}