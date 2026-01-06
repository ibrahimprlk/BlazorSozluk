namespace BlozorSozluk.Api.Domain.Models
{
    public class EmailConfirmation : BaseEntity
    {
        public string? NewEmailAddress { get; set; }
        public string? OldEmailAddress { get; set; }
    }
}
