namespace LMS.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Status Status { get; set; }
    }
}
