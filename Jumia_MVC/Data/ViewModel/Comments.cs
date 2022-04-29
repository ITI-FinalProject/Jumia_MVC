namespace Jumia_MVC.Data.ViewModel
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
    }
}
