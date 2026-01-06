namespace BlozorSozluk.Api.Domain.Models
{
    public class Entry:BaseEntity
    {
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public virtual ICollection<EntryComment> EntryComments { get; set; }
        public virtual ICollection<EntryVote> EntryVotes { get; set; }
        public virtual ICollection<EntryFavorite> EntryFavorites { get; set; }
    }
}
