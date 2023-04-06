namespace MVCBookMgtSystem.Models
{
    public class UpdateViewModels
    {
        public Guid BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
