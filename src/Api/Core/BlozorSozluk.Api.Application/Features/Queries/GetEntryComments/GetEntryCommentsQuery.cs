using BlozorSozluk.Common.ViewModels.Page;
using BlozorSozluk.Common.ViewModels.Queries;
using MediatR;

namespace BlozorSozluk.Api.Application.Features.Queries.GetEntryComments
{

    public class GetEntryCommentsQuery : BasePagedQuery, IRequest<PagedViewModel<GetEntryCommentsViewModel>> // Birisi bu query'i cagirdiginda sayfalama yapisi icinde GetEntryCommentsViewModel'i dondurucek
    {
        public GetEntryCommentsQuery(Guid entryId, Guid? userId, int page, int pageSize) : base(page, pageSize)
        {
            EntryId = entryId;
            UserId = userId;
        }

        public Guid EntryId { get; set; }
        public Guid? UserId { get; set; }
    }
}