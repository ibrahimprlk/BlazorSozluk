namespace BlozorSozluk.Common.ViewModels.Queries
{
    public class GetEntriesViewModel
    {
        public Guid Id { get; set; } // Tiklaninca gidecegi adres icin Id'yi aliyoruz
        public string Subject { get; set; }
        public int CommentCount { get; set; }
    }
}