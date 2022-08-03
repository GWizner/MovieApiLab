namespace MovieApiLab.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public Movie(int id, string title, string category)
        {
            ID = id;
            Title = title;
            Category = category;
        }
    }
}
