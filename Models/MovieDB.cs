namespace MovieApiLab.Models
{
    public class MovieDB
    {
        public List<Movie> Movies { get; set; }
        public MovieDB()
        {
            Movies = new List<Movie>()
            {
                new Movie(0,"The Princess Bride", "Adventure"),
                new Movie(1,"Interstellar 5555", "Anime"),
                new Movie(2,"Spirited Away", "Anime"),
                new Movie(3,"Army of Darkness", "Comedy"),
                new Movie(4,"Gummo", "Comedy"),
            };
        }
    }
}
