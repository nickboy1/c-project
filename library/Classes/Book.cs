namespace LibraryManager.Models
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime ReleaseDate { get; set; }

     
        /// Initializes a new instance of the <see cref="Book"/> class
      

        /// <param name="title">The title of the book</param>
        /// <param name="author">The author of the book</param>
        /// <param name="releaseDate">The release date of the book</param>
        public Book(string title, Author author, DateTime releaseDate) 
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
        }


        /// Returns a string that represents the current book

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Release Date: {ReleaseDate.ToShortDateString()}";
        }
    }
}
