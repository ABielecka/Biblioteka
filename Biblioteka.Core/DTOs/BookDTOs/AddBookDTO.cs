namespace Biblioteka.Core
{
    public class AddBookDTO
    {
        public int BookIndexNumber { get; set; }
        public string Title { get; set; }
        public string YearofPublishment { get; set; }
        public string Language { get; set; }
        public bool isReturned { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CountryName { get; set; }

        public string Type { get; set; }
    }
}
