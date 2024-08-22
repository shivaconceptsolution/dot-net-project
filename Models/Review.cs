namespace Productreview.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }
        public int ProductId { get; set; } // Foreign Key

        public Product Product { get; set; } // Navigation Property
    }
}
